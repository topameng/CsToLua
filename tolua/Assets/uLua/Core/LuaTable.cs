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
        //internal int _Reference;
        //private Lua _Interpreter;
        public LuaTable(int reference, LuaState interpreter)
        {
            _Reference = reference;
            _Interpreter = interpreter;
        }

        public LuaTable(int reference, IntPtr L)
        {            
            _Reference = reference;
            ObjectTranslator translator = ObjectTranslator.FromState(L);
            _Interpreter = translator.interpreter;            
        }

        //bool disposed = false;
        //~LuaTable()
        //{
        //    Dispose(false);
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //public virtual void Dispose(bool disposeManagedResources)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposeManagedResources)
        //        {
        //            if (_Reference != 0)
        //                _Interpreter.dispose(_Reference);
        //        }

        //        disposed = true;
        //    }
        //}
        //~LuaTable()
        //{
        //    _Interpreter.dispose(_Reference);
        //}
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

        //把一个table func 放在栈顶
        /*public bool RawGetField(string field)
        {
            IntPtr L = _Interpreter.L;
            LuaTypes type = LuaTypes.LUA_TNONE;
            
            LuaDLL.lua_getref(L, _Reference);            
            LuaDLL.lua_pushstring(L, field);            
            LuaDLL.lua_rawget(L, -2);            

            if (LuaDLL.lua_isnil(L, -1))
            {
                LuaDLL.lua_pop(L, 1);
                
                if (LuaDLL.lua_getmetatable(L, -1) > 0)
                {
                    LuaDLL.lua_pushstring(L, field);                 
                    LuaDLL.lua_rawget(L, -2);
                }
            }
            
            type = LuaDLL.lua_type(L, -1);

            if (type == LuaTypes.LUA_TFUNCTION)
            {
                return true;
            }

            return false;
        }*/

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

        /*
         * Pushes this table into the Lua stack
         */
        internal void push(IntPtr luaState)
        {
            LuaDLL.lua_getref(luaState, _Reference);
        }
        public override string ToString()
        {
            return "table";
        }
        //public override bool Equals(object o)
        //{
        //    if (o is LuaTable)
        //    {
        //        LuaTable l = (LuaTable)o;
        //        return _Interpreter.compareRef(l._Reference, _Reference);
        //    }
        //    else return false;
        //}
        //public override int GetHashCode()
        //{
        //    return _Reference;
        //}
    }
}
