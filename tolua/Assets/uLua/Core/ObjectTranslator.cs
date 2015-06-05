namespace LuaInterface
{
    using System;
    using System.IO;
    using System.Collections;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    //using System.Diagnostics;

    /*
     * Passes objects from the CLR to Lua and vice-versa
     *
     * Author: Fabio Mascarenhas
     * Version: 1.0
     */
    public class ObjectTranslator
    {
        //fix ÄäÃûÎ¯ÍÐ equals ÅÐ¶Ï³ö´íbug, by topameng
        private class CompareObject : IEqualityComparer<object>
        {
            public new bool Equals(object x, object y)
            {
                return x == y;
            }

            public int GetHashCode(object obj)
            {
                if (obj != null)
                {
                    return obj.GetHashCode();
                }

                return 0;
            }
        }

        internal CheckType typeChecker;

        // object # to object (FIXME - it should be possible to get object address as an object #)
        public readonly Dictionary<int, object> objects = new Dictionary<int, object>();
        //public readonly LuaObjectMap objects = new LuaObjectMap();        
        // object to object #
        public readonly Dictionary<object, int> objectsBackMap = new Dictionary<object, int>(new CompareObject());

        static Dictionary<Type, int> typeMetaMap = new Dictionary<Type, int>();

        internal LuaState interpreter;
        public MetaFunctions metaFunctions;
        public List<Assembly> assemblies;
        private LuaCSFunction registerTableFunction, unregisterTableFunction, getMethodSigFunction,
        getConstructorSigFunction, importTypeFunction, loadAssemblyFunction, ctypeFunction, enumFromIntFunction;

        internal EventHandlerContainer pendingEvents = new EventHandlerContainer();

        static List<ObjectTranslator> list = new List<ObjectTranslator>();
        static int indexTranslator = 0;

        public int weakTableRef
        {
            get;
            private set;
        }

        public static ObjectTranslator FromState(IntPtr luaState)
        {
            //LuaDLL.lua_getglobal(luaState, "_translator");
            //IntPtr thisptr = LuaDLL.lua_touserdata(luaState, -1);

            //GCHandle handle = GCHandle.FromIntPtr(thisptr);
            //ObjectTranslator translator = (ObjectTranslator)handle.Target;
            //LuaDLL.lua_pop(luaState, 1);
            //return translator;

            LuaDLL.lua_getglobal(luaState, "_translator");
            int pos = (int)LuaDLL.lua_tonumber(luaState, -1);
            LuaDLL.lua_pop(luaState, 1);
            return list[pos];
        }

        public void PushTranslator(IntPtr L)
        {
            list.Add(this);
            LuaDLL.lua_pushnumber(L, indexTranslator);
            LuaDLL.lua_setglobal(L, "_translator");
            ++indexTranslator;
        }

        public ObjectTranslator(LuaState interpreter, IntPtr luaState)
        {
            this.interpreter = interpreter;
            weakTableRef = -1;
            typeChecker = new CheckType(this);
            metaFunctions = new MetaFunctions(this);
            assemblies = new List<Assembly>();
            assemblies.Add(Assembly.GetExecutingAssembly());

            importTypeFunction = new LuaCSFunction(importType);
            loadAssemblyFunction = new LuaCSFunction(loadAssembly);
            registerTableFunction = new LuaCSFunction(registerTable);
            unregisterTableFunction = new LuaCSFunction(unregisterTable);
            getMethodSigFunction = new LuaCSFunction(getMethodSignature);
            getConstructorSigFunction = new LuaCSFunction(getConstructorSignature);

            ctypeFunction = new LuaCSFunction(ctype);
            enumFromIntFunction = new LuaCSFunction(enumFromInt);

            createLuaObjectList(luaState);
            createIndexingMetaFunction(luaState);
            createBaseClassMetatable(luaState);
            createClassMetatable(luaState);
            createFunctionMetatable(luaState);
            setGlobalFunctions(luaState);
        }

        public void Destroy()
        {
            IntPtr L = interpreter.L;

            foreach (KeyValuePair<Type, int> kv in typeMetaMap)
            {
                int reference = kv.Value;
                LuaDLL.lua_unref(L, reference);
            }

            LuaDLL.lua_unref(L, weakTableRef);
            typeMetaMap.Clear();
        }

        /*
         * Sets up the list of objects in the Lua side
         */
        private void createLuaObjectList(IntPtr luaState)
        {
            LuaDLL.lua_pushstring(luaState, "luaNet_objects");
            LuaDLL.lua_newtable(luaState);
            LuaDLL.lua_pushvalue(luaState, -1);
            weakTableRef = LuaDLL.luaL_ref(luaState, LuaIndexes.LUA_REGISTRYINDEX);
            LuaDLL.lua_pushvalue(luaState, -1);
            LuaDLL.lua_setmetatable(luaState, -2);
            LuaDLL.lua_pushstring(luaState, "__mode");
            LuaDLL.lua_pushstring(luaState, "v");
            LuaDLL.lua_settable(luaState, -3);
            //LuaDLL.lua_setmetatable(luaState,-2);
            LuaDLL.lua_settable(luaState, (int)LuaIndexes.LUA_REGISTRYINDEX);
        }
        /*
         * Registers the indexing function of CLR objects
         * passed to Lua
         */
        private void createIndexingMetaFunction(IntPtr luaState)
        {
            LuaDLL.lua_pushstring(luaState, "luaNet_indexfunction");
            LuaDLL.luaL_dostring(luaState, MetaFunctions.luaIndexFunction);
            //LuaDLL.lua_pushstdcallcfunction(luaState,indexFunction);
            LuaDLL.lua_rawset(luaState, (int)LuaIndexes.LUA_REGISTRYINDEX);
        }
        /*
         * Creates the metatable for superclasses (the base
         * field of registered tables)
         */
        private void createBaseClassMetatable(IntPtr luaState)
        {
            LuaDLL.luaL_newmetatable(luaState, "luaNet_searchbase");
            LuaDLL.lua_pushstring(luaState, "__gc");
            LuaDLL.lua_pushstdcallcfunction(luaState, metaFunctions.gcFunction);
            LuaDLL.lua_settable(luaState, -3);
            LuaDLL.lua_pushstring(luaState, "__tostring");
            LuaDLL.lua_pushstdcallcfunction(luaState, metaFunctions.toStringFunction);
            LuaDLL.lua_settable(luaState, -3);
            LuaDLL.lua_pushstring(luaState, "__index");
            LuaDLL.lua_pushstdcallcfunction(luaState, metaFunctions.baseIndexFunction);
            LuaDLL.lua_settable(luaState, -3);
            LuaDLL.lua_pushstring(luaState, "__newindex");
            LuaDLL.lua_pushstdcallcfunction(luaState, metaFunctions.newindexFunction);
            LuaDLL.lua_settable(luaState, -3);
            LuaDLL.lua_settop(luaState, -2);
        }
        /*
         * Creates the metatable for type references
         */
        private void createClassMetatable(IntPtr luaState)
        {
            LuaDLL.luaL_newmetatable(luaState, "luaNet_class");
            LuaDLL.lua_pushstring(luaState, "__gc");
            LuaDLL.lua_pushstdcallcfunction(luaState, metaFunctions.gcFunction);
            LuaDLL.lua_settable(luaState, -3);
            LuaDLL.lua_pushstring(luaState, "__tostring");
            LuaDLL.lua_pushstdcallcfunction(luaState, metaFunctions.toStringFunction);
            LuaDLL.lua_settable(luaState, -3);
            LuaDLL.lua_pushstring(luaState, "__index");
            LuaDLL.lua_pushstdcallcfunction(luaState, metaFunctions.classIndexFunction);
            LuaDLL.lua_settable(luaState, -3);
            LuaDLL.lua_pushstring(luaState, "__newindex");
            LuaDLL.lua_pushstdcallcfunction(luaState, metaFunctions.classNewindexFunction);
            LuaDLL.lua_settable(luaState, -3);
            LuaDLL.lua_pushstring(luaState, "__call");
            LuaDLL.lua_pushstdcallcfunction(luaState, metaFunctions.callConstructorFunction);
            LuaDLL.lua_settable(luaState, -3);
            LuaDLL.lua_settop(luaState, -2);
        }
        /*
         * Registers the global functions used by LuaInterface
         */
        private void setGlobalFunctions(IntPtr luaState)
        {
            LuaDLL.lua_pushstdcallcfunction(luaState, metaFunctions.indexFunction);
            LuaDLL.lua_setglobal(luaState, "get_object_member");
            LuaDLL.lua_pushstdcallcfunction(luaState, importTypeFunction);
            LuaDLL.lua_setglobal(luaState, "import_type");
            LuaDLL.lua_pushstdcallcfunction(luaState, loadAssemblyFunction);
            LuaDLL.lua_setglobal(luaState, "load_assembly");
            LuaDLL.lua_pushstdcallcfunction(luaState, registerTableFunction);
            LuaDLL.lua_setglobal(luaState, "make_object");
            LuaDLL.lua_pushstdcallcfunction(luaState, unregisterTableFunction);
            LuaDLL.lua_setglobal(luaState, "free_object");
            LuaDLL.lua_pushstdcallcfunction(luaState, getMethodSigFunction);
            LuaDLL.lua_setglobal(luaState, "get_method_bysig");
            LuaDLL.lua_pushstdcallcfunction(luaState, getConstructorSigFunction);
            LuaDLL.lua_setglobal(luaState, "get_constructor_bysig");
            LuaDLL.lua_pushstdcallcfunction(luaState, ctypeFunction);
            LuaDLL.lua_setglobal(luaState, "ctype");
            LuaDLL.lua_pushstdcallcfunction(luaState, enumFromIntFunction);
            LuaDLL.lua_setglobal(luaState, "enum");

        }

        /*
         * Creates the metatable for delegates
         */
        private void createFunctionMetatable(IntPtr luaState)
        {
            LuaDLL.luaL_newmetatable(luaState, "luaNet_function");
            LuaDLL.lua_pushstring(luaState, "__gc");
            LuaDLL.lua_pushstdcallcfunction(luaState, metaFunctions.gcFunction);
            LuaDLL.lua_settable(luaState, -3);
            LuaDLL.lua_pushstring(luaState, "__call");
            LuaDLL.lua_pushstdcallcfunction(luaState, metaFunctions.execDelegateFunction);
            LuaDLL.lua_settable(luaState, -3);
            LuaDLL.lua_settop(luaState, -2);
        }
        /*
         * Passes errors (argument e) to the Lua interpreter
         */
        internal void throwError(IntPtr luaState, string message)
        {
            // We use this to remove anything pushed by luaL_where
            /*int oldTop = LuaDLL.lua_gettop(luaState);
			
            // Stack frame #1 is our C# wrapper, so not very interesting to the user
            // Stack frame #2 must be the lua code that called us, so that's what we want to use
            LuaDLL.luaL_where(luaState, 1);
            object[] curlev = popValues(luaState, oldTop);
			
            // Determine the position in the script where the exception was triggered
            string errLocation = "";
            if (curlev.Length > 0)
                errLocation = curlev[0].ToString();
			
            string message = e as string;
            if (message != null)
            {
                // Wrap Lua error (just a string) and store the error location
                e = new LuaScriptException(message, errLocation);
            }
            else
            {
                Exception ex = e as Exception;
                if (ex != null)
                {
                    // Wrap generic .NET exception as an InnerException and store the error location
                    e = new LuaScriptException(ex, errLocation);
                }
            }
			
            push(luaState, e);
            LuaDLL.lua_error(luaState);*/

            LuaDLL.luaL_error(luaState, message);
        }
        /*
         * Implementation of load_assembly. Throws an error
         * if the assembly is not found.
         */
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int loadAssembly(IntPtr luaState)
        {
            ObjectTranslator translator = ObjectTranslator.FromState(luaState);
            try
            {
                string assemblyName = LuaDLL.lua_tostring(luaState, 1);

                Assembly assembly = null;

                //assembly = Assembly.GetExecutingAssembly();

                try
                {
                    assembly = Assembly.Load(assemblyName);
                }
                catch (BadImageFormatException)
                {
                    // The assemblyName was invalid.  It is most likely a path.
                }

                if (assembly == null)
                {
                    assembly = Assembly.Load(AssemblyName.GetAssemblyName(assemblyName));
                }

                if (assembly != null && !translator.assemblies.Contains(assembly))
                {
                    translator.assemblies.Add(assembly);
                }
            }
            catch (Exception e)
            {
                translator.throwError(luaState, e.Message);
            }

            return 0;
        }

        internal Type FindType(string className)
        {
            foreach (Assembly assembly in assemblies)
            {
                Type klass = assembly.GetType(className);
                if (klass != null)
                {
                    return klass;
                }
            }
            return null;
        }

        /*
         * Implementation of import_type. Returns nil if the
         * type is not found.
         */
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int importType(IntPtr luaState)
        {
            ObjectTranslator translator = ObjectTranslator.FromState(luaState);
            string className = LuaDLL.lua_tostring(luaState, 1);
            Type klass = translator.FindType(className);
            if (klass != null)
                translator.pushType(luaState, klass);
            else
                LuaDLL.lua_pushnil(luaState);
            return 1;
        }
        /*
         * Implementation of make_object. Registers a table (first
         * argument in the stack) as an object subclassing the
         * type passed as second argument in the stack.
         */
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int registerTable(IntPtr luaState)
        {
#if __NOGEN__
			throwError(luaState,"Tables as Objects not implemnented");
#else
            ObjectTranslator translator = ObjectTranslator.FromState(luaState);
            if (LuaDLL.lua_type(luaState, 1) == LuaTypes.LUA_TTABLE)
            {
                LuaTable luaTable = translator.getTable(luaState, 1);
                string superclassName = LuaDLL.lua_tostring(luaState, 2);
                if (superclassName != null)
                {
                    Type klass = translator.FindType(superclassName);
                    if (klass != null)
                    {
                        // Creates and pushes the object in the stack, setting
                        // it as the  metatable of the first argument
                        object obj = CodeGeneration.Instance.GetClassInstance(klass, luaTable);
                        translator.pushObject(luaState, obj, "luaNet_metatable");
                        LuaDLL.lua_newtable(luaState);
                        LuaDLL.lua_pushstring(luaState, "__index");
                        LuaDLL.lua_pushvalue(luaState, -3);
                        LuaDLL.lua_settable(luaState, -3);
                        LuaDLL.lua_pushstring(luaState, "__newindex");
                        LuaDLL.lua_pushvalue(luaState, -3);
                        LuaDLL.lua_settable(luaState, -3);
                        LuaDLL.lua_setmetatable(luaState, 1);
                        // Pushes the object again, this time as the base field
                        // of the table and with the luaNet_searchbase metatable
                        LuaDLL.lua_pushstring(luaState, "base");
                        int index = translator.addObject(obj);
                        translator.pushNewObject(luaState, obj, index, "luaNet_searchbase");
                        LuaDLL.lua_rawset(luaState, 1);
                    }
                    else
                        translator.throwError(luaState, "register_table: can not find superclass '" + superclassName + "'");
                }
                else
                    translator.throwError(luaState, "register_table: superclass name can not be null");
            }
            else translator.throwError(luaState, "register_table: first arg is not a table");
#endif
            return 0;
        }
        /*
         * Implementation of free_object. Clears the metatable and the
         * base field, freeing the created object for garbage-collection
         */
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int unregisterTable(IntPtr luaState)
        {
            ObjectTranslator translator = ObjectTranslator.FromState(luaState);
            try
            {
                if (LuaDLL.lua_getmetatable(luaState, 1) != 0)
                {
                    LuaDLL.lua_pushstring(luaState, "__index");
                    LuaDLL.lua_gettable(luaState, -2);
                    object obj = translator.getRawNetObject(luaState, -1);
                    if (obj == null) translator.throwError(luaState, "unregister_table: arg is not valid table");
                    FieldInfo luaTableField = obj.GetType().GetField("__luaInterface_luaTable");
                    if (luaTableField == null) translator.throwError(luaState, "unregister_table: arg is not valid table");
                    luaTableField.SetValue(obj, null);
                    LuaDLL.lua_pushnil(luaState);
                    LuaDLL.lua_setmetatable(luaState, 1);
                    LuaDLL.lua_pushstring(luaState, "base");
                    LuaDLL.lua_pushnil(luaState);
                    LuaDLL.lua_settable(luaState, 1);
                }
                else translator.throwError(luaState, "unregister_table: arg is not valid table");
            }
            catch (Exception e)
            {
                translator.throwError(luaState, e.Message);
            }
            return 0;
        }
        /*
         * Implementation of get_method_bysig. Returns nil
         * if no matching method is not found.
         */
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int getMethodSignature(IntPtr luaState)
        {
            ObjectTranslator translator = ObjectTranslator.FromState(luaState);
            IReflect klass; object target;
            int udata = LuaDLL.luanet_checkudata(luaState, 1, "luaNet_class");
            if (udata != -1)
            {
                klass = (IReflect)translator.objects[udata];
                target = null;
            }
            else
            {
                target = translator.getRawNetObject(luaState, 1);
                if (target == null)
                {
                    translator.throwError(luaState, "get_method_bysig: first arg is not type or object reference");
                    LuaDLL.lua_pushnil(luaState);
                    return 1;
                }
                klass = target.GetType();
            }
            string methodName = LuaDLL.lua_tostring(luaState, 2);
            Type[] signature = new Type[LuaDLL.lua_gettop(luaState) - 2];
            for (int i = 0; i < signature.Length; i++)
                signature[i] = translator.FindType(LuaDLL.lua_tostring(luaState, i + 3));
            try
            {
                //CP: Added ignore case
                MethodInfo method = klass.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static |
                                                  BindingFlags.Instance | BindingFlags.FlattenHierarchy | BindingFlags.IgnoreCase, null, signature, null);
                translator.pushFunction(luaState, new LuaCSFunction((new LuaMethodWrapper(translator, target, klass, method)).call));
            }
            catch (Exception e)
            {
                translator.throwError(luaState, e.Message);
                LuaDLL.lua_pushnil(luaState);
            }
            return 1;
        }
        /*
         * Implementation of get_constructor_bysig. Returns nil
         * if no matching constructor is found.
         */
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int getConstructorSignature(IntPtr luaState)
        {
            ObjectTranslator translator = ObjectTranslator.FromState(luaState);
            IReflect klass = null;
            int udata = LuaDLL.luanet_checkudata(luaState, 1, "luaNet_class");
            if (udata != -1)
            {
                klass = (IReflect)translator.objects[udata];
            }
            if (klass == null)
            {
                translator.throwError(luaState, "get_constructor_bysig: first arg is invalid type reference");
            }
            Type[] signature = new Type[LuaDLL.lua_gettop(luaState) - 1];
            for (int i = 0; i < signature.Length; i++)
                signature[i] = translator.FindType(LuaDLL.lua_tostring(luaState, i + 2));
            try
            {
                ConstructorInfo constructor = klass.UnderlyingSystemType.GetConstructor(signature);
                translator.pushFunction(luaState, new LuaCSFunction((new LuaMethodWrapper(translator, null, klass, constructor)).call));
            }
            catch (Exception e)
            {
                translator.throwError(luaState, e.Message);
                LuaDLL.lua_pushnil(luaState);
            }
            return 1;
        }

        private Type typeOf(IntPtr luaState, int idx)
        {
            int udata = LuaDLL.luanet_checkudata(luaState, 1, "luaNet_class");
            if (udata == -1)
            {
                return null;
            }
            else
            {
                ProxyType pt = (ProxyType)objects[udata];
                return pt.UnderlyingSystemType;
            }
        }

        public int pushError(IntPtr luaState, string msg)
        {
            LuaDLL.lua_pushnil(luaState);
            LuaDLL.lua_pushstring(luaState, msg);
            return 2;
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int ctype(IntPtr luaState)
        {
            ObjectTranslator translator = ObjectTranslator.FromState(luaState);
            Type t = translator.typeOf(luaState, 1);
            if (t == null)
            {
                return translator.pushError(luaState, "not a CLR class");
            }
            translator.pushObject(luaState, t, "luaNet_metatable");
            return 1;
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int enumFromInt(IntPtr luaState)
        {
            ObjectTranslator translator = ObjectTranslator.FromState(luaState);
            Type t = translator.typeOf(luaState, 1);
            if (t == null || !t.IsEnum)
            {
                return translator.pushError(luaState, "not an enum");
            }
            object res = null;
            LuaTypes lt = LuaDLL.lua_type(luaState, 2);
            if (lt == LuaTypes.LUA_TNUMBER)
            {
                int ival = (int)LuaDLL.lua_tonumber(luaState, 2);
                res = Enum.ToObject(t, ival);
            }
            else
                if (lt == LuaTypes.LUA_TSTRING)
                {
                    string sflags = LuaDLL.lua_tostring(luaState, 2);
                    string err = null;
                    try
                    {
                        res = Enum.Parse(t, sflags);
                    }
                    catch (ArgumentException e)
                    {
                        err = e.Message;
                    }
                    if (err != null)
                    {
                        return translator.pushError(luaState, err);
                    }
                }
                else
                {
                    return translator.pushError(luaState, "second argument must be a integer or a string");
                }
            translator.pushObject(luaState, res, "luaNet_metatable");
            return 1;
        }

        /*
         * Pushes a type reference into the stack
         */
        internal void pushType(IntPtr luaState, Type t)
        {
            pushObject(luaState, new ProxyType(t), "luaNet_class");
        }
        /*
         * Pushes a delegate into the stack
         */
        internal void pushFunction(IntPtr luaState, LuaCSFunction func)
        {
            pushObject(luaState, func, "luaNet_function");
        }

        static Dictionary<Type, bool> valueTypeMap = new Dictionary<Type, bool>();

        bool IsValueType(Type t)
        {
            bool isValue = false;

            if (!valueTypeMap.TryGetValue(t, out isValue))
            {
                isValue = t.IsValueType;
                valueTypeMap.Add(t, isValue);
            }

            return isValue;
        }

        /*
         * Pushes a CLR object into the Lua stack as an userdata
         * with the provided metatable
         */
        public void pushObject(IntPtr luaState, object o, string metatable)
        {
            if (o == null)
            {
                LuaDLL.lua_pushnil(luaState);
                return;
            }

            int index = -1;
            // Object already in the list of Lua objects? Push the stored reference.
            bool beValueType = o.GetType().IsValueType;

            if (!beValueType && objectsBackMap.TryGetValue(o, out index))
            {
                if (LuaDLL.tolua_pushudata(luaState, weakTableRef, index))
                {
                    return;
                }

                // Note: starting with lua5.1 the garbage collector may remove weak reference items (such as our luaNet_objects values) when the initial GC sweep
                // occurs, but the actual call of the __gc finalizer for that object may not happen until a little while later.  During that window we might call
                // this routine and find the element missing from luaNet_objects, but collectObject() has not yet been called.  In that case, we go ahead and call collect
                // object here
                // did we find a non nil object in our table? if not, we need to call collect object             
                // Remove from both our tables and fall out to get a new ID
                collectObject(o, index);
            }

            index = addObject(o, beValueType);
            pushNewObject(luaState, o, index, metatable);
        }

        static void PushMetaTable(IntPtr L, Type t)
        {
            int reference = -1;

            if (!typeMetaMap.TryGetValue(t, out reference))
            {
                LuaDLL.luaL_getmetatable(L, t.AssemblyQualifiedName);

                if (!LuaDLL.lua_isnil(L, -1))
                {
                    LuaDLL.lua_pushvalue(L, -1);
                    reference = LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
                    typeMetaMap.Add(t, reference);
                }
            }
            else
            {
                LuaDLL.lua_getref(L, reference);
            }
        }

        /*
         * Pushes a new object into the Lua stack with the provided
         * metatable
         */
        private void pushNewObject(IntPtr luaState, object o, int index, string metatable)
        {
            //LuaDLL.luaL_getmetatable(luaState, "luaNet_objects");
            LuaDLL.lua_getref(luaState, weakTableRef);
            LuaDLL.luanet_newudata(luaState, index);

            if (metatable == "luaNet_metatable")
            {
                // Gets or creates the metatable for the object's type
                //string meta = t.AssemblyQualifiedName
                //LuaDLL.luaL_getmetatable(luaState, meta);
                Type t = o.GetType();
                PushMetaTable(luaState, o.GetType());

                if (LuaDLL.lua_isnil(luaState, -1))
                {
                    string meta = t.AssemblyQualifiedName;
                    Debugger.LogWarning("Create not wrap ulua type:" + meta);
                    LuaDLL.lua_settop(luaState, -2);
                    LuaDLL.luaL_newmetatable(luaState, meta);
                    LuaDLL.lua_pushstring(luaState, "cache");
                    LuaDLL.lua_newtable(luaState);
                    LuaDLL.lua_rawset(luaState, -3);
                    LuaDLL.lua_pushlightuserdata(luaState, LuaDLL.luanet_gettag());
                    LuaDLL.lua_pushnumber(luaState, 1);
                    LuaDLL.lua_rawset(luaState, -3);
                    LuaDLL.lua_pushstring(luaState, "__index");
                    LuaDLL.lua_pushstring(luaState, "luaNet_indexfunction");
                    LuaDLL.lua_rawget(luaState, (int)LuaIndexes.LUA_REGISTRYINDEX);
                    LuaDLL.lua_rawset(luaState, -3);
                    LuaDLL.lua_pushstring(luaState, "__gc");
                    LuaDLL.lua_pushstdcallcfunction(luaState, metaFunctions.gcFunction);
                    LuaDLL.lua_rawset(luaState, -3);
                    LuaDLL.lua_pushstring(luaState, "__tostring");
                    LuaDLL.lua_pushstdcallcfunction(luaState, metaFunctions.toStringFunction);
                    LuaDLL.lua_rawset(luaState, -3);
                    LuaDLL.lua_pushstring(luaState, "__newindex");
                    LuaDLL.lua_pushstdcallcfunction(luaState, metaFunctions.newindexFunction);
                    LuaDLL.lua_rawset(luaState, -3);
                }
            }
            else
            {
                LuaDLL.luaL_getmetatable(luaState, metatable);
            }

            LuaDLL.lua_setmetatable(luaState, -2);
            LuaDLL.lua_pushvalue(luaState, -1);
            LuaDLL.lua_rawseti(luaState, -3, index);
            LuaDLL.lua_remove(luaState, -2);
        }

        public void PushNewValueObject(IntPtr luaState, object o, int index)
        {
            LuaDLL.luanet_newudata(luaState, index);

            //string meta = GetAQName(o.GetType());
            //LuaDLL.luaL_getmetatable(luaState, meta);
            Type t = o.GetType();
            PushMetaTable(luaState, o.GetType());

            if (LuaDLL.lua_isnil(luaState, -1))
            {
                string meta = t.AssemblyQualifiedName;
                Debugger.LogWarning("Create not wrap ulua type:" + meta);
                LuaDLL.lua_settop(luaState, -2);
                LuaDLL.luaL_newmetatable(luaState, meta);
                LuaDLL.lua_pushstring(luaState, "cache");
                LuaDLL.lua_newtable(luaState);
                LuaDLL.lua_rawset(luaState, -3);
                LuaDLL.lua_pushlightuserdata(luaState, LuaDLL.luanet_gettag());
                LuaDLL.lua_pushnumber(luaState, 1);
                LuaDLL.lua_rawset(luaState, -3);
                LuaDLL.lua_pushstring(luaState, "__index");
                LuaDLL.lua_pushstring(luaState, "luaNet_indexfunction");
                LuaDLL.lua_rawget(luaState, (int)LuaIndexes.LUA_REGISTRYINDEX);
                LuaDLL.lua_rawset(luaState, -3);
                LuaDLL.lua_pushstring(luaState, "__gc");
                LuaDLL.lua_pushstdcallcfunction(luaState, metaFunctions.gcFunction);
                LuaDLL.lua_rawset(luaState, -3);
                LuaDLL.lua_pushstring(luaState, "__tostring");
                LuaDLL.lua_pushstdcallcfunction(luaState, metaFunctions.toStringFunction);
                LuaDLL.lua_rawset(luaState, -3);
                LuaDLL.lua_pushstring(luaState, "__newindex");
                LuaDLL.lua_pushstdcallcfunction(luaState, metaFunctions.newindexFunction);
                LuaDLL.lua_rawset(luaState, -3);
            }

            LuaDLL.lua_setmetatable(luaState, -2);
        }

        /*
         * Gets an object from the Lua stack with the desired type, if it matches, otherwise
         * returns null.
         */
        internal object getAsType(IntPtr luaState, int stackPos, Type paramType)
        {
            ExtractValue extractor = typeChecker.checkType(luaState, stackPos, paramType);
            if (extractor != null) return extractor(luaState, stackPos);
            return null;
        }


        /// <summary>
        /// Given the Lua int ID for an object remove it from our maps
        /// </summary>
        /// <param name="udata"></param>        

        internal void collectObject(int udata)
        {
            object o;
            bool found = objects.TryGetValue(udata, out o);

            // The other variant of collectObject might have gotten here first, in that case we will silently ignore the missing entry
            if (found)
            {
                objects.Remove(udata);

                if (o != null && !o.GetType().IsValueType)
                {
                    objectsBackMap.Remove(o);
                }
            }
        }


        /// <summary>
        /// Given an object reference, remove it from our maps
        /// </summary>
        /// <param name="udata"></param>
        void collectObject(object o, int udata)
        {
            objectsBackMap.Remove(o);
            objects.Remove(udata);
        }


        /// <summary>
        /// We want to ensure that objects always have a unique ID
        /// </summary>
        int nextObj = 0;

        public int addObject(object obj)
        {
            // New object: inserts it in the list
            int index = nextObj++;
            objects[index] = obj;

            //int index = objects.Add(obj);            

            if (!obj.GetType().IsValueType)
            {
                objectsBackMap[obj] = index;
            }

            return index;
        }

        public int addObject(object obj, bool isValueType)
        {
            // New object: inserts it in the list
            int index = nextObj++;
            objects[index] = obj;

            //int index = objects.Add(obj);            

            if (!isValueType)
            {
                objectsBackMap[obj] = index;
            }

            return index;
        }

        /*
         * Gets an object from the Lua stack according to its Lua type.
         */
        public object getObject(IntPtr luaState, int index)
        {
            return LuaScriptMgr.GetVarObject(luaState, index);
        }
        /*
         * Gets the table in the index positon of the Lua stack.
         */
        internal LuaTable getTable(IntPtr luaState, int index)
        {
            LuaDLL.lua_pushvalue(luaState, index);
            return new LuaTable(LuaDLL.luaL_ref(luaState, LuaIndexes.LUA_REGISTRYINDEX), interpreter);
        }
        /*
         * Gets the function in the index positon of the Lua stack.
         */
        internal LuaFunction getFunction(IntPtr luaState, int index)
        {
            LuaDLL.lua_pushvalue(luaState, index);
            return new LuaFunction(LuaDLL.luaL_ref(luaState, LuaIndexes.LUA_REGISTRYINDEX), interpreter);
        }
        /*
         * Gets the CLR object in the index positon of the Lua stack. Returns
         * delegates as Lua functions.
         */
        internal object getNetObject(IntPtr luaState, int index)
        {
            int idx = LuaDLL.luanet_tonetobject(luaState, index);

            if (idx != -1)
                return objects[idx];
            else
                return null;
        }
        /*
         * Gets the CLR object in the index positon of the Lua stack. Returns
         * delegates as is.
         */
        internal object getRawNetObject(IntPtr luaState, int index)
        {
            int udata = LuaDLL.luanet_rawnetobj(luaState, index);
            object obj = null;
            objects.TryGetValue(udata, out obj);
            return obj;
        }

        public void SetValueObject(IntPtr luaState, int stackPos, object obj)
        {
            int udata = LuaDLL.luanet_rawnetobj(luaState, stackPos);

            if (udata != -1)
            {
                objects[udata] = obj;
            }
        }

        /*
         * Pushes the entire array into the Lua stack and returns the number
         * of elements pushed.
         */
        internal int returnValues(IntPtr luaState, object[] returnValues)
        {
            if (LuaDLL.lua_checkstack(luaState, returnValues.Length + 5))
            {
                for (int i = 0; i < returnValues.Length; i++)
                {
                    push(luaState, returnValues[i]);
                }
                return returnValues.Length;
            }
            else
                return 0;
        }
        /*
         * Gets the values from the provided index to
         * the top of the stack and returns them in an array.
         */
        internal object[] popValues(IntPtr luaState, int oldTop)
        {
            int newTop = LuaDLL.lua_gettop(luaState);

            if (oldTop == newTop)
            {
                return null;
            }
            else
            {
                List<object> returnValues = new List<object>();

                for (int i = oldTop + 1; i <= newTop; i++)
                {
                    returnValues.Add(getObject(luaState, i));
                }

                LuaDLL.lua_settop(luaState, oldTop);
                return returnValues.ToArray();
            }
        }
        /*
         * Gets the values from the provided index to
         * the top of the stack and returns them in an array, casting
         * them to the provided types.
         */
        internal object[] popValues(IntPtr luaState, int oldTop, Type[] popTypes)
        {
            int newTop = LuaDLL.lua_gettop(luaState);
            if (oldTop == newTop)
            {
                return null;
            }
            else
            {
                int iTypes;
                List<object> returnValues = new List<object>();
                if (popTypes[0] == typeof(void))
                    iTypes = 1;
                else
                    iTypes = 0;
                for (int i = oldTop + 1; i <= newTop; i++)
                {
                    returnValues.Add(getAsType(luaState, i, popTypes[iTypes]));
                    iTypes++;
                }
                LuaDLL.lua_settop(luaState, oldTop);
                return returnValues.ToArray();
            }
        }

        // kevinh - the following line doesn't work for remoting proxies - they always return a match for 'is'
        // else if(o is ILuaGeneratedType)
        static bool IsILua(object o)
        {
#if ! __NOGEN__
            if (o is ILuaGeneratedType)
            {
                // Make sure we are _really_ ILuaGenerated
                Type typ = o.GetType();
                return (typ.GetInterface("ILuaGeneratedType") != null);
            }
            else
#endif
                return false;
        }

        /*
         * Pushes the object into the Lua stack according to its type.
         */
        internal void push(IntPtr luaState, object o)
        {                        
            LuaScriptMgr.PushVarObject(luaState, o);
        }

        internal void PushValueResult(IntPtr lua, object o)
        {
            int index = addObject(o, true);
            PushNewValueObject(lua, o, index);
        }

        /*
         * Checks if the method matches the arguments in the Lua stack, getting
         * the arguments if it does.
         */
        internal bool matchParameters(IntPtr luaState, MethodBase method, ref MethodCache methodCache)
        {
            return metaFunctions.matchParameters(luaState, method, ref methodCache);
        }

        internal Array tableToArray(object luaParamValue, Type paramArrayType)
        {
            return metaFunctions.TableToArray(luaParamValue, paramArrayType);
        }
    }
}