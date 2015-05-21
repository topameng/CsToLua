using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace LuaInterface
{
    /*
     * Wrapper class for Lua tables
     *
     * Author: Fabio Mascarenhas
     * Version: 1.0
     */
    public class LuaTable : LuaBase
    {                
        public LuaTable(int reference, LuaState interpreter)
        {
            _Reference = reference;
            _Interpreter = interpreter;
            translator = interpreter.translator;
        }

        public LuaTable(int reference, IntPtr L)
        {            
            _Reference = reference;
            translator = ObjectTranslator.FromState(L);
            _Interpreter = translator.interpreter;            
        }

        /*
         * Indexer for string fields of the table
         */
        public object this[string field]
        {
            get
            {
                return _Interpreter.getObject(_Reference, field);
            }
            set
            {
                _Interpreter.setObject(_Reference, field, value);
            }
        }
        /*
         * Indexer for numeric fields of the table
         */
        public object this[object field]
        {
            get
            {
                return _Interpreter.getObject(_Reference, field);
            }
            set
            {
                _Interpreter.setObject(_Reference, field, value);
            }
        }


        public System.Collections.IDictionaryEnumerator GetEnumerator()
        {
            return _Interpreter.GetTableDict(this).GetEnumerator();
        }

        public int Count
        {
            get
            {
                //push(_Interpreter.L);
                //LuaDLL.lua_objlen(_Interpreter.L, -1);
                return _Interpreter.GetTableDict(this).Count;
            }
        }

        public ICollection Keys
        {
            get { return _Interpreter.GetTableDict(this).Keys; }
        }

        public ICollection Values
        {
            get { return _Interpreter.GetTableDict(this).Values; }
        }
		
		public void SetMetaTable(LuaTable metaTable)
		{
			push(_Interpreter.L);
			metaTable.push(_Interpreter.L);
			LuaDLL.lua_setmetatable(_Interpreter.L, -2);
			LuaDLL.lua_pop(_Interpreter.L, 1);
		}

        public T[] ToArray<T>()
        {
            IntPtr L = _Interpreter.L;            
            push(L);
            return LuaScriptMgr.GetArrayObject<T>(L, -1);            
        }

        public void Set(string key, object o)
        {
            IntPtr L = _Interpreter.L;
            push(L);
            LuaDLL.lua_pushstring(L, key);
            PushArgs(L, o);
            LuaDLL.lua_rawset(L, -3);
            LuaDLL.lua_settop(L, 0);
        }

        /*
         * Gets an string fields of a table ignoring its metatable,
         * if it exists
         */
        internal object rawget(string field)
        {
            return _Interpreter.rawGetObject(_Reference, field);
        }

        internal object rawgetFunction(string field)
        {
            object obj = _Interpreter.rawGetObject(_Reference, field);

            if (obj is LuaCSFunction)
                return new LuaFunction((LuaCSFunction)obj, _Interpreter);
            else
                return obj;
        }

        public LuaFunction RawGetFunc(string field)
        {            
            IntPtr L = _Interpreter.L;
            LuaTypes type = LuaTypes.LUA_TNONE;
            LuaFunction func = null;

            int oldTop = LuaDLL.lua_gettop(L);
            LuaDLL.lua_getref(L, _Reference);
            LuaDLL.lua_pushstring(L, field);
            LuaDLL.lua_gettable(L, -2);

            type = LuaDLL.lua_type(L, -1);

            if (type == LuaTypes.LUA_TFUNCTION)
            {
                func = new LuaFunction(LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX), L);                
            }

            LuaDLL.lua_settop(L, oldTop);
            return func;
        }

        /*
         * Pushes this table into the Lua stack
        // */
        internal void push(IntPtr luaState)
        {
            LuaDLL.lua_getref(luaState, _Reference);
        }     

        public override string ToString()
        {
            return "table";
        }
    }
}
