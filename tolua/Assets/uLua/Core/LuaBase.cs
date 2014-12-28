using System;
using System.Collections.Generic;
using System.Text;

namespace LuaInterface
{
    /// <summary>
    /// Base class to provide consistent disposal flow across lua objects. Uses code provided by Yves Duhoux and suggestions by Hans Schmeidenbacher and Qingrui Li
    /// </summary>
    public abstract class LuaBase : IDisposable
    {        
        private bool _Disposed;
        protected int _Reference;
        protected LuaState _Interpreter;

        public string name = null;
        private int count = 0;

        public LuaBase()
        {
            count = 1;
        }

        ~LuaBase()
        {            
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void AddRef()
        {
            ++count;
        }

        public void Release()
        {
            if (_Disposed || name == null)
            {
                return;
            }

            --count;

            if (count > 0)
            {
                return;
            }
            
            if (name != null)
            {
                LuaScriptMgr mgr = LuaScriptMgr.GetMgrFromLuaState(_Interpreter.L);

                if (mgr != null)
                {
                    mgr.RemoveLuaRes(name);
                }                
            }

            Dispose();
        }

        public virtual void Dispose(bool disposeManagedResources)
        {
            if (!_Disposed)
            {
                if (_Reference != 0 && _Interpreter != null)
                {
                    if (disposeManagedResources)
                    {
                        _Interpreter.dispose(_Reference);                        
                    }
                    else
                    {
                        LuaScriptMgr mgr = LuaScriptMgr.GetMgrFromLuaState(_Interpreter.L);
                        mgr.refGCList.Enqueue(_Reference);                        
                    }

                    _Reference = 0;
                }

                _Interpreter = null;
                _Disposed = true;
            }
        }

        public override bool Equals(object o)
        {
            if (o is LuaBase)
            {
                LuaBase l = (LuaBase)o;
                return _Interpreter.compareRef(l._Reference, _Reference);
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return _Reference;
        }
    }
}
