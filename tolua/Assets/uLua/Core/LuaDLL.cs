namespace LuaInterface
{
	using System;
	using System.Runtime.InteropServices;
	using System.Reflection;
	using System.Collections;
	using System.Text;
    using System.Security;

	#pragma warning disable 414
    public class MonoPInvokeCallbackAttribute : System.Attribute
    {
        private Type type;
        public MonoPInvokeCallbackAttribute(Type t) { type = t; }
    }
	#pragma warning restore 414
	
	public enum LuaTypes
	{
		LUA_TNONE=-1,
		LUA_TNIL=0,
		LUA_TNUMBER=3,
		LUA_TSTRING=4,
		LUA_TBOOLEAN=1,
		LUA_TTABLE=5,
		LUA_TFUNCTION=6,
		LUA_TUSERDATA=7,
		LUA_TTHREAD=8,
		LUA_TLIGHTUSERDATA=2
	}
	
	public enum LuaGCOptions
	{
		LUA_GCSTOP = 0,
		LUA_GCRESTART = 1,
		LUA_GCCOLLECT = 2,
		LUA_GCCOUNT = 3,
		LUA_GCCOUNTB = 4,
		LUA_GCSTEP = 5,
		LUA_GCSETPAUSE = 6,
		LUA_GCSETSTEPMUL = 7,
	}

    public enum LuaThreadStatus
    {
        LUA_YIELD       = 1,
        LUA_ERRRUN      = 2,
        LUA_ERRSYNTAX   = 3,
        LUA_ERRMEM      = 4,
        LUA_ERRERR      = 5,
    }

	sealed class LuaIndexes
	{
		public static int LUA_REGISTRYINDEX=-10000;
		public static int LUA_ENVIRONINDEX=-10001;
		public static int LUA_GLOBALSINDEX=-10002;
	}

	[StructLayout( LayoutKind.Sequential )]
	public struct ReaderInfo
	{
		public String chunkData;
		public bool finished;
	}

#if !UNITY_IPHONE
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
#endif
    public delegate int LuaCSFunction(IntPtr luaState);	

    public delegate string LuaChunkReader(IntPtr luaState,ref ReaderInfo data,ref uint size);

    public delegate int LuaFunctionCallback(IntPtr luaState);

#if !UNITY_IPHONE
    [SuppressUnmanagedCodeSecurity]
#endif
	public class LuaDLL
	{
        public static int LUA_MULTRET = -1;
#if UNITY_IPHONE
        const string LUADLL = "__Internal";
#else
        const string LUADLL = "ulua";
#endif              		
        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaopen_pb(IntPtr L);

        //[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        //public static extern int luaopen_LuaXML(IntPtr L);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaopen_ffi(IntPtr L);

        //[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        //public static extern int luaopen_pack(IntPtr L);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int tolua_openlibs(IntPtr L);        

        public static int lua_upvalueindex(int i)	
        {
            return LuaIndexes.LUA_GLOBALSINDEX - i;
        }

        // Thread Funcs
		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int lua_tothread(IntPtr L, int index);
		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int lua_xmove(IntPtr from, IntPtr to, int n);
		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int lua_yield(IntPtr L, int nresults);
		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr lua_newthread(IntPtr L);
		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int lua_resume(IntPtr L, int narg);
		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int lua_status(IntPtr L);

		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int lua_pushthread(IntPtr L);
		public static int luaL_getn(IntPtr luaState, int i)
		{
            return (int)LuaDLL.lua_objlen(luaState, i);
		}

		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int lua_gc(IntPtr luaState, LuaGCOptions what, int data);
		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern string lua_typename(IntPtr luaState, LuaTypes type);
		public static string luaL_typename(IntPtr luaState, int stackPos)
		{
			return LuaDLL.lua_typename(luaState, LuaDLL.lua_type(luaState, stackPos));
		}

		public static int lua_isfunction(IntPtr luaState, int stackPos)
		{
			return Convert.ToInt32(lua_type(luaState, stackPos) == LuaTypes.LUA_TFUNCTION);
		}

		public static int lua_islightuserdata(IntPtr luaState, int stackPos)
		{
			return Convert.ToInt32(lua_type(luaState, stackPos) == LuaTypes.LUA_TLIGHTUSERDATA);
		}

		public static int lua_istable(IntPtr luaState, int stackPos)
		{
			return Convert.ToInt32(lua_type(luaState, stackPos) == LuaTypes.LUA_TTABLE);
		}

		public static int lua_isthread(IntPtr luaState, int stackPos)
		{
			return Convert.ToInt32(lua_type(luaState, stackPos) == LuaTypes.LUA_TTHREAD);
		}

		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void luaL_error(IntPtr luaState, string message);
		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern string luaL_gsub(IntPtr luaState, string str, string pattern, string replacement);
		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void lua_getfenv(IntPtr luaState, int stackPos);


		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int lua_isuserdata(IntPtr luaState, int stackPos);
		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int lua_lessthan(IntPtr luaState, int stackPos1, int stackPos2);
		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int lua_rawequal(IntPtr luaState, int stackPos1, int stackPos2);
		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int lua_setfenv(IntPtr luaState, int stackPos);
		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void lua_setfield(IntPtr luaState, int stackPos, string name);
		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int luaL_callmeta(IntPtr luaState, int stackPos, string name);
		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr luaL_newstate();
		/// <summary>DEPRECATED - use luaL_newstate() instead!</summary>
		public static IntPtr lua_open()
		{
			return LuaDLL.luaL_newstate();
		}

		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void lua_close(IntPtr luaState);
		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void luaL_openlibs(IntPtr luaState);
		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int lua_objlen(IntPtr luaState, int stackPos);
		/// <summary>DEPRECATED - use lua_objlen(IntPtr luaState, int stackPos) instead!</summary>
		public static int lua_strlen(IntPtr luaState, int stackPos)
		{
			return lua_objlen(luaState, stackPos);
		}
		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int luaL_loadstring(IntPtr luaState, string chunk);
		public static int luaL_dostring(IntPtr luaState, string chunk)
		{
			int result = LuaDLL.luaL_loadstring(luaState, chunk);
			if (result != 0)
				return result;

			return LuaDLL.lua_pcall(luaState, 0, -1, 0);
		}
		/// <summary>DEPRECATED - use luaL_dostring(IntPtr luaState, string chunk) instead!</summary>
		public static int lua_dostring(IntPtr luaState, string chunk)
		{
			return LuaDLL.luaL_dostring(luaState, chunk);
		}

		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void lua_createtable(IntPtr luaState, int narr, int nrec);
		public static void lua_newtable(IntPtr luaState)
		{
			LuaDLL.lua_createtable(luaState, 0, 0);
		}
		public static int luaL_dofile(IntPtr luaState, string fileName)
		{
			int result = LuaDLL.luaL_loadfile(luaState, fileName);
			if (result != 0)
				return result;

			return LuaDLL.lua_pcall(luaState, 0, -1, 0);
		}
		public static void lua_getglobal(IntPtr luaState, string name)
		{
			LuaDLL.lua_pushstring(luaState,name);
			LuaDLL.lua_gettable(luaState,LuaIndexes.LUA_GLOBALSINDEX);
		}
		public static void lua_setglobal(IntPtr luaState, string name)
		{
			//LuaDLL.lua_pushstring(luaState,name);
			//LuaDLL.lua_insert(luaState,-2);
			//LuaDLL.lua_settable(luaState,LuaIndexes.LUA_GLOBALSINDEX);
            LuaDLL.lua_setfield(luaState, LuaIndexes.LUA_GLOBALSINDEX, name);
		}
        public static void lua_rawglobal(IntPtr luaState, string name)
        {
            LuaDLL.lua_pushstring(luaState, name);
            LuaDLL.lua_rawget(luaState, LuaIndexes.LUA_GLOBALSINDEX);
        }

		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern void lua_settop(IntPtr luaState, int newTop);
		public static void lua_pop(IntPtr luaState, int amount)
		{
			LuaDLL.lua_settop(luaState, -(amount) - 1);
		}
		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void lua_insert(IntPtr luaState, int newTop);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern void lua_remove(IntPtr luaState, int index);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern void lua_gettable(IntPtr luaState, int index);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern void lua_rawget(IntPtr luaState, int index);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern void lua_settable(IntPtr luaState, int index);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern void lua_rawset(IntPtr luaState, int index);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern void lua_setmetatable(IntPtr luaState, int objIndex);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern int lua_getmetatable(IntPtr luaState, int objIndex);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern int lua_equal(IntPtr luaState, int index1, int index2);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern void lua_pushvalue(IntPtr luaState, int index);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern void lua_replace(IntPtr luaState, int index);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern int lua_gettop(IntPtr luaState);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern LuaTypes lua_type(IntPtr luaState, int index);
		public static bool lua_isnil(IntPtr luaState, int index)
		{
			return (LuaDLL.lua_type(luaState,index)==LuaTypes.LUA_TNIL);
		}
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern bool lua_isnumber(IntPtr luaState, int index);
		public static bool lua_isboolean(IntPtr luaState, int index)
		{
			return LuaDLL.lua_type(luaState,index)==LuaTypes.LUA_TBOOLEAN;
		}
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern int luaL_ref(IntPtr luaState, int registryIndex);
		public static int lua_ref(IntPtr luaState, int lockRef)
		{
			if(lockRef!=0)
			{
				return LuaDLL.luaL_ref(luaState,LuaIndexes.LUA_REGISTRYINDEX);
			}
			else return 0;
		}
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern void lua_rawgeti(IntPtr luaState, int tableIndex, int index);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern void lua_rawseti(IntPtr luaState, int tableIndex, int index);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern IntPtr lua_newuserdata(IntPtr luaState, int size);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern IntPtr lua_touserdata(IntPtr luaState, int index);
		public static void lua_getref(IntPtr luaState, int reference)
		{
			LuaDLL.lua_rawgeti(luaState,LuaIndexes.LUA_REGISTRYINDEX,reference);
		}
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern void luaL_unref(IntPtr luaState, int registryIndex, int reference);
		public static void lua_unref(IntPtr luaState, int reference)
		{
			LuaDLL.luaL_unref(luaState,LuaIndexes.LUA_REGISTRYINDEX,reference);
		}
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern bool lua_isstring(IntPtr luaState, int index);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern bool lua_iscfunction(IntPtr luaState, int index);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern void lua_pushnil(IntPtr luaState);

		public static void lua_pushstdcallcfunction(IntPtr luaState, LuaCSFunction function, int n = 0)
		{
			IntPtr fn = Marshal.GetFunctionPointerForDelegate(function);			
            lua_pushcclosure(luaState, fn, n);           
		}        

		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern void lua_call(IntPtr luaState, int nArgs, int nResults);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern int lua_pcall(IntPtr luaState, int nArgs, int nResults, int errfunc);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern IntPtr lua_tocfunction(IntPtr luaState, int index);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern double lua_tonumber(IntPtr luaState, int index);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern bool lua_toboolean(IntPtr luaState, int index);

		[DllImport(LUADLL,CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr lua_tolstring(IntPtr luaState, int index, out int strLen);

        static string AnsiToUnicode(IntPtr source, int strlen)
        {
            byte[] buffer = new byte[strlen];
            Marshal.Copy(source, buffer, 0, strlen);            
            string str = Encoding.UTF8.GetString(buffer);
            return str;    
        }

		public static string lua_tostring(IntPtr luaState, int index)
		{
            int strlen;
            IntPtr str = lua_tolstring(luaState, index, out strlen);   

            if (str != IntPtr.Zero)
			{
                string ss = Marshal.PtrToStringAnsi(str, strlen);

                //当从c传出中文时会转换失败， topameng
                if (ss == null)
                {
                    return AnsiToUnicode(str, strlen);
                }

                return ss;
			}
            else
			{
                return null;
			}
		}

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void lua_atpanic(IntPtr luaState, LuaCSFunction panicf);

		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern void lua_pushnumber(IntPtr luaState, double number);
        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushinteger(IntPtr luaState, int number);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern void lua_pushboolean(IntPtr luaState, bool value);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern void lua_pushlstring(IntPtr luaState, byte[] str, int size);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern void lua_pushstring(IntPtr luaState, string str);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern int luaL_newmetatable(IntPtr luaState, string meta);
		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void lua_getfield(IntPtr luaState, int stackPos, string meta);
		public static void luaL_getmetatable(IntPtr luaState, string meta)
		{
			LuaDLL.lua_getfield(luaState, LuaIndexes.LUA_REGISTRYINDEX, meta);
		}
		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr luaL_checkudata(IntPtr luaState, int stackPos, string meta);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
        public static extern LuaTypes luaL_getmetafield(IntPtr luaState, int stackPos, string field);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern int lua_load(IntPtr luaState, LuaChunkReader chunkReader, ref ReaderInfo data, string chunkName);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern int luaL_loadbuffer(IntPtr luaState, byte[] buff, int size, string name);        
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern int luaL_loadfile(IntPtr luaState, string filename);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern bool luaL_checkmetatable(IntPtr luaState,int obj);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern int luanet_tonetobject(IntPtr luaState,int obj);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern void luanet_newudata(IntPtr luaState,int val);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern int luanet_rawnetobj(IntPtr luaState,int obj);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern int luanet_checkudata(IntPtr luaState,int obj,string meta);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern void lua_error(IntPtr luaState);
		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool lua_checkstack(IntPtr luaState,int extra);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern int lua_next(IntPtr luaState,int index);
		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern void lua_pushlightuserdata(IntPtr luaState, IntPtr udata);
 		[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern IntPtr luanet_gettag();
        [DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
        public static extern void luaL_where (IntPtr luaState, int level);                

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushcclosure(IntPtr luaState, IntPtr fn, int n);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern string lua_getupvalue(IntPtr L, int funcindex, int n);

        //[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        //public static extern IntPtr lua_tocbuffer(byte[] bytes, int n);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaL_typerror(IntPtr luaState, int narg, string tname);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaL_argerror (IntPtr luaState, int narg, string extramsg);

        //[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        //public static extern int luaopen_socket_core(IntPtr luaState);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void tolua_getfloat2(IntPtr luaState, int reference, int stack, ref float x, ref float y);
        
        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void tolua_getfloat3(IntPtr luaState, int reference, int stack, ref float x, ref float y, ref float z);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void tolua_getfloat4(IntPtr luaState, int reference, int stack, ref float x, ref float y, ref float z, ref float w);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void tolua_getfloat6(IntPtr luaState, int reference, int stack, ref float x, ref float y, ref float z, ref float x1, ref float y1, ref float z1);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void tolua_pushfloat2(IntPtr luaState, int reference, float x, float y);
        
        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void tolua_pushfloat3(IntPtr luaState, int reference, float x, float y, float z);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void tolua_pushfloat4(IntPtr luaState, int reference, float x, float y, float z, float w);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool tolua_pushudata(IntPtr L, int reference, int index);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool tolua_pushnewudata(IntPtr L, int metaRef, int weakTableRef, int index);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void tolua_setindex(IntPtr L);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void tolua_setnewindex(IntPtr L);                
	}
}
