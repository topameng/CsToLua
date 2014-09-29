using System;
using System.Collections.Generic;
using System.Text;

namespace LuaInterface
{
    public class LuaFunction : LuaBase
    {
        //private Lua interpreter;
        internal LuaCSFunction function;
        //internal int reference;
        ObjectTranslator translator = null;
        IntPtr L;

        public LuaFunction(int reference, LuaState interpreter)
        {
            _Reference = reference;
            this.function = null;
            _Interpreter = interpreter;
            L = _Interpreter.L;
            translator = _Interpreter.translator;
        }

        public LuaFunction(LuaCSFunction function, LuaState interpreter)
        {
            _Reference = 0;
            this.function = function;
            _Interpreter = interpreter;
            L = _Interpreter.L;
            translator = _Interpreter.translator;
        }

        public LuaFunction(int reference, IntPtr l)
        {
            _Reference = reference;
            this.function = null;                        
            translator = ObjectTranslator.FromState(l);
            _Interpreter = translator.interpreter;
            L = _Interpreter.L;
        }

        //~LuaFunction()
        //{
        //    if (reference != 0)
        //        interpreter.dispose(reference);
        //}

        //bool disposed = false;
        //~LuaFunction()
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


        /*
         * Calls the function casting return values to the types
         * in returnTypes
         */
        internal object[] call(object[] args, Type[] returnTypes)
        {
            //return _Interpreter.callFunction(this, args, returnTypes);
            int nArgs = 0;
            int oldTop = LuaDLL.lua_gettop(L);
            if (!LuaDLL.lua_checkstack(L, args.Length + 6))
                throw new LuaException("Lua stack overflow");
            translator.push(L, this);
            if (args != null)
            {
                nArgs = args.Length;
                for (int i = 0; i < args.Length; i++)
                {
                    translator.push(L, args[i]);
                }
            }
            int error = LuaDLL.lua_pcall(L, nArgs, -1, 0);
            if (error != 0)
                ThrowExceptionFromError(oldTop);

            if (returnTypes != null)
                return translator.popValues(L, oldTop, returnTypes);
            else
                return translator.popValues(L, oldTop);
        }

        internal void ThrowExceptionFromError(int oldTop)
        {
            object err = translator.getObject(L, -1);
            LuaDLL.lua_settop(L, oldTop);
            if (err == null) err = "Unknown Lua Error";
            throw new LuaScriptException(err.ToString(), "");
        }

        /*
         * Calls the function and returns its return values inside
         * an array
         */
        public object[] Call(params object[] args)
        {
            return call(args, null);
        }
        /*
         * Pushes the function into the Lua stack
         */
        internal void push(IntPtr luaState)
        {
            if (_Reference != 0)
                LuaDLL.lua_getref(luaState, _Reference);
            else
                _Interpreter.pushCSFunction(function);
        }
        public override string ToString()
        {
            return "function";
        }
        public override bool Equals(object o)
        {
            if (o is LuaFunction)
            {
                LuaFunction l = (LuaFunction)o;
                if (this._Reference != 0 && l._Reference != 0)
                    return _Interpreter.compareRef(l._Reference, this._Reference);
                else
                    return this.function == l.function;
            }
            else return false;
        }
        public override int GetHashCode()
        {
            if (_Reference != 0)
                return _Reference;
            else
                return function.GetHashCode();
        }
    }

}
