#define __NOGEN__

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace LuaInterface
{
    /*
     * Type checking and conversion functions.
     *
     * Author: Fabio Mascarenhas
     * Version: 1.0
     */
    class CheckType
    {
        private ObjectTranslator translator;

        ExtractValue extractNetObject;
        Dictionary<long, ExtractValue> extractValues = new Dictionary<long, ExtractValue>();

        public CheckType(ObjectTranslator translator)
        {
            this.translator = translator;

            extractValues.Add(typeof(object).TypeHandle.Value.ToInt64(), new ExtractValue(getAsObject));
            extractValues.Add(typeof(sbyte).TypeHandle.Value.ToInt64(), new ExtractValue(getAsSbyte));
            extractValues.Add(typeof(byte).TypeHandle.Value.ToInt64(), new ExtractValue(getAsByte));
            extractValues.Add(typeof(short).TypeHandle.Value.ToInt64(), new ExtractValue(getAsShort));
            extractValues.Add(typeof(ushort).TypeHandle.Value.ToInt64(), new ExtractValue(getAsUshort));
            extractValues.Add(typeof(int).TypeHandle.Value.ToInt64(), new ExtractValue(getAsInt));
            extractValues.Add(typeof(uint).TypeHandle.Value.ToInt64(), new ExtractValue(getAsUint));
            extractValues.Add(typeof(long).TypeHandle.Value.ToInt64(), new ExtractValue(getAsLong));
            extractValues.Add(typeof(ulong).TypeHandle.Value.ToInt64(), new ExtractValue(getAsUlong));
            extractValues.Add(typeof(double).TypeHandle.Value.ToInt64(), new ExtractValue(getAsDouble));
            extractValues.Add(typeof(char).TypeHandle.Value.ToInt64(), new ExtractValue(getAsChar));
            extractValues.Add(typeof(float).TypeHandle.Value.ToInt64(), new ExtractValue(getAsFloat));
            extractValues.Add(typeof(decimal).TypeHandle.Value.ToInt64(), new ExtractValue(getAsDecimal));
            extractValues.Add(typeof(bool).TypeHandle.Value.ToInt64(), new ExtractValue(getAsBoolean));
            extractValues.Add(typeof(string).TypeHandle.Value.ToInt64(), new ExtractValue(getAsString));
            extractValues.Add(typeof(LuaFunction).TypeHandle.Value.ToInt64(), new ExtractValue(getAsFunction));
            extractValues.Add(typeof(LuaTable).TypeHandle.Value.ToInt64(), new ExtractValue(getAsTable));            

            extractValues.Add(typeof(Vector3).TypeHandle.Value.ToInt64(), new ExtractValue(getAsVector3));

            extractValues.Add(typeof(Vector2).TypeHandle.Value.ToInt64(), new ExtractValue(getAsVector2));
            extractValues.Add(typeof(Quaternion).TypeHandle.Value.ToInt64(), new ExtractValue(getAsQuaternion));
            extractValues.Add(typeof(Color).TypeHandle.Value.ToInt64(), new ExtractValue(getAsColor));
            extractValues.Add(typeof(Vector4).TypeHandle.Value.ToInt64(), new ExtractValue(getAsVector4));
            extractValues.Add(typeof(Ray).TypeHandle.Value.ToInt64(), new ExtractValue(getAsRay));
            extractValues.Add(typeof(Bounds).TypeHandle.Value.ToInt64(), new ExtractValue(getAsBounds));
                    

            extractNetObject = new ExtractValue(getAsNetObject);
        }

        /*
         * Checks if the value at Lua stack index stackPos matches paramType,
         * returning a conversion function if it does and null otherwise.
         */
        internal ExtractValue getExtractor(IReflect paramType)
        {
            return getExtractor(paramType.UnderlyingSystemType);
        }
        internal ExtractValue getExtractor(Type paramType)
        {
            if(paramType.IsByRef) paramType=paramType.GetElementType();

            long runtimeHandleValue = paramType.TypeHandle.Value.ToInt64();

            if(extractValues.ContainsKey(runtimeHandleValue))
                return extractValues[runtimeHandleValue];
            else
                return extractNetObject;
        }

        internal ExtractValue checkType(IntPtr luaState,int stackPos,Type paramType)
        {
            LuaTypes luatype = LuaDLL.lua_type(luaState, stackPos);

            if(paramType.IsByRef) paramType=paramType.GetElementType();

            Type underlyingType = Nullable.GetUnderlyingType(paramType);
            if (underlyingType != null)
            {
                paramType = underlyingType;     // Silently convert nullable types to their non null requics
            }

            long runtimeHandleValue = paramType.TypeHandle.Value.ToInt64();

            if (paramType.Equals(typeof(object)))
                return extractValues[runtimeHandleValue];

            //CP: Added support for generic parameters
            if (paramType.IsGenericParameter)
            {
                if (luatype == LuaTypes.LUA_TBOOLEAN)
                    return extractValues[typeof(bool).TypeHandle.Value.ToInt64()];
                else if (luatype == LuaTypes.LUA_TSTRING)
                    return extractValues[typeof(string).TypeHandle.Value.ToInt64()];
                else if (luatype == LuaTypes.LUA_TTABLE)
                    return extractValues[typeof(LuaTable).TypeHandle.Value.ToInt64()];
                else if (luatype == LuaTypes.LUA_TUSERDATA)
                    return extractValues[typeof(object).TypeHandle.Value.ToInt64()];
                else if (luatype == LuaTypes.LUA_TFUNCTION)
                    return extractValues[typeof(LuaFunction).TypeHandle.Value.ToInt64()];
                else if (luatype == LuaTypes.LUA_TNUMBER)
                    return extractValues[typeof(double).TypeHandle.Value.ToInt64()];
                //else // suppress CS0642
                    ;//an unsupported type was encountered
            }

            if (paramType.IsValueType && luatype == LuaTypes.LUA_TTABLE)
            {
                int oldTop = LuaDLL.lua_gettop(luaState);
                ExtractValue ret = null;
                LuaDLL.lua_pushvalue(luaState, stackPos);
                LuaDLL.lua_pushstring(luaState, "class");
                LuaDLL.lua_gettable(luaState, -2);

                if (!LuaDLL.lua_isnil(luaState, -1))
                {
                    string cls = LuaDLL.lua_tostring(luaState, -1);

                    if (cls == "Vector3" && paramType == typeof(Vector3))
                    {
                        ret = extractValues[typeof(Vector3).TypeHandle.Value.ToInt64()];
                    }
                    else if (cls == "Vector2" && paramType == typeof(Vector2))
                    {
                        ret = extractValues[typeof(Vector2).TypeHandle.Value.ToInt64()];
                    }
                    else if (cls == "Quaternion" && paramType == typeof(Quaternion))
                    {
                        ret = extractValues[typeof(Quaternion).TypeHandle.Value.ToInt64()];
                    }
                    else if (cls == "Color" && paramType == typeof(Color))
                    {
                        ret = extractValues[typeof(Color).TypeHandle.Value.ToInt64()];
                    }
                    else if (cls == "Vector4" && paramType == typeof(Vector4))
                    {
                        ret = extractValues[typeof(Vector4).TypeHandle.Value.ToInt64()];
                    }
                    else if (cls == "Ray" && paramType == typeof(Ray))
                    {
                        ret = extractValues[typeof(Ray).TypeHandle.Value.ToInt64()];
                    }
                    else
                    {
                        ret = null;
                    }
                }

                LuaDLL.lua_settop(luaState, oldTop);

                if (ret != null) return ret;
            }

            if (LuaDLL.lua_isnumber(luaState, stackPos))
                return extractValues[runtimeHandleValue];

            if (paramType == typeof(bool))
            {
                if (LuaDLL.lua_isboolean(luaState, stackPos))
                    return extractValues[runtimeHandleValue];
            }
            else if (paramType == typeof(string))
            {
                if (LuaDLL.lua_isstring(luaState, stackPos))
                    return extractValues[runtimeHandleValue];
                else if (luatype == LuaTypes.LUA_TNIL)
                    return extractNetObject; // kevinh - silently convert nil to a null string pointer
            }
            else if (paramType == typeof(LuaTable))
            {
                if (luatype == LuaTypes.LUA_TTABLE)
                    return extractValues[runtimeHandleValue];
            }
            else if (paramType == typeof(LuaFunction))
            {
                if (luatype == LuaTypes.LUA_TFUNCTION)
                    return extractValues[runtimeHandleValue];
            }
            else if (typeof(Delegate).IsAssignableFrom(paramType) && luatype == LuaTypes.LUA_TFUNCTION)
            {
#if __NOGEN__
				translator.throwError(luaState,"Delegates not implemnented");
#else
                return new ExtractValue(new DelegateGenerator(translator, paramType).extractGenerated);
#endif
            }
            else if (paramType.IsInterface && luatype == LuaTypes.LUA_TTABLE)
            {
#if __NOGEN__
				translator.throwError(luaState,"Interfaces not implemnented");
#else
                return new ExtractValue(new ClassGenerator(translator, paramType).extractGenerated);
#endif
            }
            else if ((paramType.IsInterface || paramType.IsClass) && luatype == LuaTypes.LUA_TNIL)
            {
                // kevinh - allow nil to be silently converted to null - extractNetObject will return null when the item ain't found
                return extractNetObject;
            }
            else if (LuaDLL.lua_type(luaState, stackPos) == LuaTypes.LUA_TTABLE)
            {
                if (LuaTypes.LUA_TNIL != LuaDLL.luaL_getmetafield(luaState, stackPos, "__index"))
                {
                    object obj = translator.getNetObject(luaState, -1);
                    LuaDLL.lua_settop(luaState, -2);
                    if (obj != null && paramType.IsAssignableFrom(obj.GetType()))
                        return extractNetObject;
                }
            }
            else
            {
                //object obj = translator.getNetObject(luaState, stackPos);  //topameng 修改这里使支持注册到c#的lua类
                object obj = translator.getRawNetObject(luaState, stackPos);
                if (obj != null && paramType.IsAssignableFrom(obj.GetType()))
                    return extractNetObject;
            }

            return null;
        }

        /*
         * The following functions return the value in the Lua stack
         * index stackPos as the desired type if it can, or null
         * otherwise.
         */
        private object getAsSbyte(IntPtr luaState,int stackPos)
        {
            sbyte retVal=(sbyte)LuaDLL.lua_tonumber(luaState,stackPos);
            if(retVal==0 && !LuaDLL.lua_isnumber(luaState,stackPos)) return null;
            return retVal;
        }

        private object getAsByte(IntPtr luaState,int stackPos)
        {
            byte retVal=(byte)LuaDLL.lua_tonumber(luaState,stackPos);
            if(retVal==0 && !LuaDLL.lua_isnumber(luaState,stackPos)) return null;
            return retVal;
        }

        private object getAsShort(IntPtr luaState,int stackPos)
        {
            short retVal=(short)LuaDLL.lua_tonumber(luaState,stackPos);
            if(retVal==0 && !LuaDLL.lua_isnumber(luaState,stackPos)) return null;
            return retVal;
        }

        private object getAsUshort(IntPtr luaState,int stackPos)
        {
            ushort retVal=(ushort)LuaDLL.lua_tonumber(luaState,stackPos);
            if(retVal==0 && !LuaDLL.lua_isnumber(luaState,stackPos)) return null;
            return retVal;
        }

        private object getAsInt(IntPtr luaState,int stackPos)
        {
            int retVal=(int)LuaDLL.lua_tonumber(luaState,stackPos);
            if(retVal==0 && !LuaDLL.lua_isnumber(luaState,stackPos)) return null;
            return retVal;
        }

        private object getAsUint(IntPtr luaState,int stackPos)
        {
            uint retVal=(uint)LuaDLL.lua_tonumber(luaState,stackPos);
            if(retVal==0 && !LuaDLL.lua_isnumber(luaState,stackPos)) return null;
            return retVal;
        }

        private object getAsLong(IntPtr luaState,int stackPos)
        {
            long retVal=(long)LuaDLL.lua_tonumber(luaState,stackPos);
            if(retVal==0 && !LuaDLL.lua_isnumber(luaState,stackPos)) return null;
            return retVal;
        }

        private object getAsUlong(IntPtr luaState,int stackPos)
        {
            ulong retVal=(ulong)LuaDLL.lua_tonumber(luaState,stackPos);
            if(retVal==0 && !LuaDLL.lua_isnumber(luaState,stackPos)) return null;
            return retVal;
        }

        private object getAsDouble(IntPtr luaState,int stackPos)
        {
            double retVal=LuaDLL.lua_tonumber(luaState,stackPos);
            if(retVal==0 && !LuaDLL.lua_isnumber(luaState,stackPos)) return null;
            return retVal;
        }

        private object getAsChar(IntPtr luaState,int stackPos)
        {
            char retVal=(char)LuaDLL.lua_tonumber(luaState,stackPos);
            if(retVal==0 && !LuaDLL.lua_isnumber(luaState,stackPos)) return null;
            return retVal;
        }

        private object getAsFloat(IntPtr luaState,int stackPos)
        {
            float retVal=(float)LuaDLL.lua_tonumber(luaState,stackPos);
            if(retVal==0 && !LuaDLL.lua_isnumber(luaState,stackPos)) return null;
            return retVal;
        }

        private object getAsDecimal(IntPtr luaState,int stackPos)
        {
            decimal retVal=(decimal)LuaDLL.lua_tonumber(luaState,stackPos);
            if(retVal==0 && !LuaDLL.lua_isnumber(luaState,stackPos)) return null;
            return retVal;
        }

        private object getAsBoolean(IntPtr luaState,int stackPos)
        {
            return LuaDLL.lua_toboolean(luaState,stackPos);
        }

        private object getAsString(IntPtr luaState,int stackPos)
        {
            string retVal=LuaDLL.lua_tostring(luaState,stackPos);
            if(retVal=="" && !LuaDLL.lua_isstring(luaState,stackPos)) return null;
            return retVal;
        }

        private object getAsTable(IntPtr luaState,int stackPos)
        {
            return translator.getTable(luaState,stackPos);
        }

        private object getAsFunction(IntPtr luaState,int stackPos)
        {
            return translator.getFunction(luaState,stackPos);
        }

        public object getAsObject(IntPtr luaState,int stackPos)
        {
            if(LuaDLL.lua_type(luaState,stackPos)==LuaTypes.LUA_TTABLE)
            {
                if(LuaTypes.LUA_TNIL != LuaDLL.luaL_getmetafield(luaState,stackPos,"__index"))
                {
                    if(LuaDLL.luaL_checkmetatable(luaState,-1))
                    {
                        LuaDLL.lua_insert(luaState,stackPos);
                        LuaDLL.lua_remove(luaState,stackPos+1);
                    }
                    else
                    {
                        LuaDLL.lua_settop(luaState,-2);
                    }
                }
            }
            object obj=translator.getObject(luaState,stackPos);
            return obj;
        }

        public object getAsNetObject(IntPtr luaState,int stackPos)
        {
            //object obj=translator.getNetObject(luaState,stackPos);    //同上 topameng
            object obj = translator.getRawNetObject(luaState, stackPos);
            if(obj==null && LuaDLL.lua_type(luaState,stackPos)==LuaTypes.LUA_TTABLE)
            {
                if (LuaTypes.LUA_TNIL != LuaDLL.luaL_getmetafield(luaState, stackPos, "__index"))
                {
                    if(LuaDLL.luaL_checkmetatable(luaState,-1))
                    {
                        LuaDLL.lua_insert(luaState,stackPos);
                        LuaDLL.lua_remove(luaState,stackPos+1);
                        obj=translator.getNetObject(luaState,stackPos);
                    }
                    else
                    {
                        LuaDLL.lua_settop(luaState,-2);
                    }
                }
            }
            return obj;
        }

        public object getAsVector3(IntPtr L, int stackPos)
        {
            return LuaScriptMgr.GetVector3(L, stackPos);
        }

        public object getAsVector2(IntPtr L, int stackPos)
        {
            return LuaScriptMgr.GetVector2(L, stackPos);
        }

        public object getAsQuaternion(IntPtr L, int stackPos)
        {
            return LuaScriptMgr.GetQuaternion(L, stackPos);
        }

        public object getAsColor(IntPtr L, int stackPos)
        {
            return LuaScriptMgr.GetColor(L, stackPos);
        }

        public object getAsVector4(IntPtr L, int stackPos)
        {
            return LuaScriptMgr.GetVector4(L, stackPos);
        }

        public object getAsRay(IntPtr L, int stackPos)
        {
            return LuaScriptMgr.GetRay(L, stackPos);
        }

        public object getAsBounds(IntPtr L, int stackPos)
        {
            return LuaScriptMgr.GetBounds(L, stackPos);
        }
    }
}
