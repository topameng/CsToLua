using System;
using System.Collections.Generic;
using System.Text;

namespace LuaInterface
{
    public class LuaFunction : LuaBase
    {        
        internal LuaCSFunction function;                
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
            L = l;
            translator = ObjectTranslator.FromState(L);
            _Interpreter = translator.interpreter;            
        }

        /*
         * Calls the function casting return values to the types
         * in returnTypes
         */
        internal object[] call(object[] args, Type[] returnTypes)
        {            
            int nArgs = 0;
            LuaDLL.lua_getglobal(L, "traceback");            
            int oldTop = LuaDLL.lua_gettop(L);

            if (!LuaDLL.lua_checkstack(L, args.Length + 6))
            {
                LuaDLL.lua_pop(L, 1);
                throw new LuaException("Lua stack overflow");
            }
               
            push(L);

            if (args != null)
            {
                nArgs = args.Length;

                for (int i = 0; i < args.Length; i++)
                {                    
                    PushArgs(L, args[i]);
                }
            }

            int error = LuaDLL.lua_pcall(L, nArgs, -1, -nArgs-2);            

            if (error != 0)
            {
                string err = LuaDLL.lua_tostring(L, -1);
                LuaDLL.lua_settop(L, oldTop);                
                LuaDLL.lua_pop(L, 1);
                if (err == null) err = "Unknown Lua Error";
                throw new LuaScriptException(err.ToString(), "");                              
            }

            object[] ret = returnTypes != null ? translator.popValues(L, oldTop, returnTypes) : translator.popValues(L, oldTop);
            LuaDLL.lua_pop(L, 1);            
            return ret;
        }       

        /*
         * Calls the function and returns its return values inside
         * an array
         */
        public object[] Call(params object[] args)
        {
            return call(args, null);
        }

        public object[] Call()
        {
            int oldTop = BeginPCall();

            if (PCall(oldTop, 0))
            {
                return EndPCall(oldTop);
            }

            return null;
        }

        public object[] Call(double arg1)
        {
            int oldTop = BeginPCall();
            LuaScriptMgr.Push(L, arg1);

            if (PCall(oldTop, 1))
            {
                return EndPCall(oldTop);
            }

            return null;
        }

        public int BeginPCall()
        {            
            LuaScriptMgr.PushTraceBack(L);
            int oldTop = LuaDLL.lua_gettop(L);
            push(L);
            return oldTop;
        }

        public bool PCall(int oldTop, int args)
        {
            if (LuaDLL.lua_pcall(L, args, -1, -args - 2) != 0)
            {
                string err = LuaDLL.lua_tostring(L, -1);
                LuaDLL.lua_settop(L, oldTop);
                LuaDLL.lua_pop(L, 1);
                if (err == null) err = "Unknown Lua Error";
                throw new LuaScriptException(err.ToString(), "");
            }

            return true;
        }

        public object[] EndPCall(int oldTop)
        {
            object[] ret = translator.popValues(L, oldTop);
            LuaDLL.lua_pop(L, 1);
            return ret;
        }

        public void EndPCall()
        {
            LuaDLL.lua_pop(L, 1);
        }
        
        public IntPtr GetLuaState()
        {
            return L;
        }


        //public object[] Call<T1>(T1 t1)
        //{
        //    int oldTop = BeginPCall();

        //    PushArgs1(L, t1);

        //    if (PCall(oldTop, 1))
        //    {
        //        return EndPCall(oldTop);
        //    }

        //    return null;
        //}


        //public object[] Call<T1, T2, T3>(T1 t1, T2 t2, T3 t3)
        //{
        //    int oldTop = BeginPCall();

        //    PushArgs(L, t1);
        //    PushArgs(L, t2);
        //    PushArgs(L, t3);

        //    if (PCall(oldTop, 3))
        //    {
        //        return EndPCall(oldTop);
        //    }

        //    return null;
        //}

        //public object[] Call<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4)
        //{
        //    int oldTop = BeginPCall();

        //    PushArgs(L, t1);
        //    PushArgs(L, t2);
        //    PushArgs(L, t3);
        //    PushArgs(L, t4);

        //    if (PCall(oldTop, 4))
        //    {
        //        return EndPCall(oldTop);
        //    }

        //    return null;
        //}

        //public object[] Call<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        //{
        //    int oldTop = BeginPCall();

        //    PushArgs(L, t1);
        //    PushArgs(L, t2);
        //    PushArgs(L, t3);
        //    PushArgs(L, t4);
        //    PushArgs(L, t5);

        //    if (PCall(oldTop, 5))
        //    {
        //        return EndPCall(oldTop);
        //    }

        //    return null;
        //}

        /*
         * Pushes the function into the Lua stack
         */
        internal void push(IntPtr luaState)
        {            
            if (_Reference != 0)
            {
                LuaDLL.lua_getref(luaState, _Reference);
            }
            else
            {
                _Interpreter.pushCSFunction(function);
            }
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
