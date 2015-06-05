namespace LuaInterface
{
	using System;
	using System.IO;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.Specialized;
	using System.Reflection;
	using System.Threading;
    using System.Text;
	using UnityEngine;

    public delegate byte[] ReadLuaFile(string name);
	
	public static class LuaStatic
	{
        public static ReadLuaFile Load = null;
        //private static int trace = 0;

        static LuaStatic()
        {
            Load = DefaultLoader;
        }

        //public static void InitTraceback(IntPtr L)
        //{
        //    int oldTop = LuaDLL.lua_gettop(L);
        //    LuaDLL.lua_getglobal(L, "debug");
        //    LuaDLL.lua_getfield(L, -1, "traceback");
        //    trace = LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
        //    LuaDLL.lua_settop(L, oldTop);
        //}

        //默认函数不改路径， luamgr 再走统一目录
        static byte[] DefaultLoader(string path)
        {
            byte[] str = null;
            
            if (File.Exists(path))
            {
                str = File.ReadAllBytes(path);
            }

            return str;
        }

		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		public static int panic(IntPtr L)
		{
			string reason = String.Format("unprotected error in call to Lua API ({0})", LuaDLL.lua_tostring(L, -1));
            LuaDLL.lua_pop(L, 1);
			throw new LuaException(reason);
		}

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int traceback(IntPtr L)
        {            
            LuaDLL.lua_getglobal(L, "debug");
            LuaDLL.lua_getfield(L, -1, "traceback");            
            LuaDLL.lua_pushvalue(L, 1);
            LuaDLL.lua_pushnumber(L, 2);
            LuaDLL.lua_call(L, 2, 1);                        
            return 1;
        }

		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		public static int print(IntPtr L)
		{
			// For each argument we'll 'tostring' it
			int n = LuaDLL.lua_gettop(L);
			string s = String.Empty;

            //LuaDLL.lua_getglobal(L, "debug");
            //LuaDLL.lua_getfield(L, -1, "traceback");
            //LuaDLL.lua_pushvalue(L, 1);
            //LuaDLL.lua_pushnumber(L, 2);
            //LuaDLL.lua_call(L, 2, 1);
            //n = LuaDLL.lua_gettop(L);
			
			LuaDLL.lua_getglobal(L, "tostring");
			
			for( int i = 1; i <= n; i++ ) 
			{
				LuaDLL.lua_pushvalue(L, -1);  /* function to be called */
				LuaDLL.lua_pushvalue(L, i);   /* value to print */
				LuaDLL.lua_call(L, 1, 1);
				s += LuaDLL.lua_tostring(L, -1);
				
				if( i > 1 ) 
				{
					s += "\t";
				}
				
				LuaDLL.lua_pop(L, 1);  /* pop result */
				
				Debug.Log("LUA: " + s);

                //LuaDLL.PrintCmd(s);
			}

		    
			return 0;
		}
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		public static int loader(IntPtr L)
		{            
			// Get script to load
			string fileName = String.Empty;
			fileName = LuaDLL.lua_tostring(L, 1);
			fileName = fileName.Replace('.', '/');
			fileName += ".lua";
			
			// Load with Unity3D resources			
            byte[] text = Load(fileName);

			if( text == null )
			{
				return 0;
			}
			
			LuaDLL.luaL_loadbuffer(L, text, text.Length, fileName);
			
			return 1;
		}
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		public static int dofile(IntPtr L)
		{            
			// Get script to load
			string fileName = String.Empty;
			fileName = LuaDLL.lua_tostring(L, 1);
			fileName.Replace('.', '/');
			fileName += ".lua";
			
			int n = LuaDLL.lua_gettop(L);
			
			// Load with Unity3D resources			
            byte[] text = Load(fileName);

			if( text == null )
			{
				return LuaDLL.lua_gettop(L) - n;
			}

            if (LuaDLL.luaL_loadbuffer(L, text, text.Length, fileName) == 0)
            {
                LuaDLL.lua_call(L, 0, LuaDLL.LUA_MULTRET);
            }
			
			return LuaDLL.lua_gettop(L) - n;
		}
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		public static int loadfile(IntPtr L)
		{
			return loader(L);
		}

        public static string init_luanet =
            @"local metatable = {}
            local rawget = rawget
            local debug = debug
            local import_type = luanet.import_type
            local load_assembly = luanet.load_assembly
            luanet.error, luanet.type = error, type
            -- Lookup a .NET identifier component.
            function metatable:__index(key) -- key is e.g. 'Form'
            -- Get the fully-qualified name, e.g. 'System.Windows.Forms.Form'
            local fqn = rawget(self,'.fqn')
            fqn = ((fqn and fqn .. '.') or '') .. key

            -- Try to find either a luanet function or a CLR type
            local obj = rawget(luanet,key) or import_type(fqn)

            -- If key is neither a luanet function or a CLR type, then it is simply
            -- an identifier component.
            if obj == nil then
                -- It might be an assembly, so we load it too.
                    pcall(load_assembly,fqn)
                    obj = { ['.fqn'] = fqn }
            setmetatable(obj, metatable)
            end

            -- Cache this lookup
            rawset(self, key, obj)
            return obj
            end

            -- A non-type has been called; e.g. foo = System.Foo()
            function metatable:__call(...)
            error('No such type: ' .. rawget(self,'.fqn'), 2)
            end

            -- This is the root of the .NET namespace
            luanet['.fqn'] = false
            setmetatable(luanet, metatable)

            -- Preload the mscorlib assembly
            luanet.load_assembly('mscorlib')

            function traceback(msg)                
                return debug.traceback(msg, 1)                
            end";
	}
}
