/* 
* This file is based on LuaInterface
*/

#include <string.h>
#include <malloc.h>
#include <stdbool.h>
#include "lua.h"


static int tag = 0;

LUALIB_API int luaL_checkmetatable(lua_State *L,int index) 
{
    int retVal=0;
    if(lua_getmetatable(L,index)!=0) {
        lua_pushlightuserdata(L,&tag);
        lua_rawget(L,-2);
        retVal=!lua_isnil(L,-1);
        lua_settop(L,-3);
    }
    return retVal;
}

LUALIB_API void *luanet_gettag() 
{
    return &tag;
}

LUALIB_API void *checkudata(lua_State *L, int ud, const char *tname)
{
  void *p = lua_touserdata(L, ud);

  if (p != NULL) 
  {  /* value is a userdata? */
    if (lua_getmetatable(L, ud))
	{
		int isEqual;

		/* does it have a metatable? */
		lua_getfield(L, LUA_REGISTRYINDEX, tname);  /* get correct metatable */

		isEqual = lua_rawequal(L, -1, -2);

		lua_pop(L, 2);  /* remove both metatables */

		if (isEqual)   /* does it have the correct mt? */
			return p;
	}
  }

  return NULL;
}


LUALIB_API int luanet_tonetobject(lua_State *L,int index) 
{
  int *udata;
  if(lua_type(L,index)==LUA_TUSERDATA) {
    if(luaL_checkmetatable(L,index)) {
      udata=(int*)lua_touserdata(L,index);
      if(udata!=NULL) return *udata;
    }
    udata=(int*)checkudata(L,index,"luaNet_class");
    if(udata!=NULL) return *udata;
    udata=(int*)checkudata(L,index,"luaNet_searchbase");
    if(udata!=NULL) return *udata;
    udata=(int*)checkudata(L,index,"luaNet_function");
    if(udata!=NULL) return *udata;
  }
  return -1;
}

LUALIB_API void luanet_newudata(lua_State *L,int val) 
{
  int* pointer=(int*)lua_newuserdata(L,sizeof(int));
  *pointer=val;
}

LUALIB_API int luanet_checkudata(lua_State *L,int index,const char *meta) 
{
  int *udata=(int*)checkudata(L,index,meta);
  if(udata!=NULL) return *udata;
  return -1;
}

LUALIB_API int luanet_rawnetobj(lua_State *L,int index) 
{
  int *udata = lua_touserdata(L,index);
  if(udata!=NULL) return *udata;
  return -1;
}

/*tolua extend functions*/

LUALIB_API const char* lua_tocbuffer(const char* csBuffer, int sz) 
{	
	char* buffer = (char*)malloc(sz + 1);
	memcpy(buffer, csBuffer, sz);
	buffer[sz]=0;			
	return buffer;
}

LUALIB_API void tolua_getvector3(lua_State* L, int ref, int pos, float* x, float* y, float* z)
{
  lua_rawgeti(L, LUA_REGISTRYINDEX, ref);
  lua_pushvalue(L, pos);
  lua_call(L, 1, -1);
  *x = (float)lua_tonumber(L, -3);
  *y = (float)lua_tonumber(L, -2);
  *z = (float)lua_tonumber(L, -1);
  lua_pop(L, 3);
}

LUALIB_API void tolua_pushvector3(lua_State* L, int ref, float x, float y, float z)
{
  lua_rawgeti(L, LUA_REGISTRYINDEX, ref);
  lua_pushnumber(L, x);
  lua_pushnumber(L, y);
  lua_pushnumber(L, z);
  lua_call(L, 3, -1);
}

int tolua_newIndex(lua_State* L)
{
  int top = lua_gettop(L);
  int ret = lua_getmetatable(L, 1);  
  
  while(ret != 0)
  {
    lua_pushvalue(L, 2);
    lua_rawget(L,-2);

    if (!lua_isnil(L, -1))
    {
      lua_rawgeti(L, -1, 2);

      if (!lua_isnil(L, -1))
      {
        lua_pushvalue(L, 1);
        lua_pushvalue(L, 2);
        lua_pushvalue(L, 3);
        lua_call(L, 3, 0);
        lua_settop(L, top);
        return 0;
      }
      else
      {
        break;
      }
    }
  }

  luaL_error(L, "field or property does not exist");
  return 0;
}

LUALIB_API void tolua_setnewindex(lua_State* L)
{
  lua_pushstring(L, "__newindex");
  lua_pushcclosure(L, tolua_newIndex, 0);
  lua_rawset(L, -3);
}

LUALIB_API bool tolua_pushudata(lua_State* L, int reference, int index)
{
  lua_rawgeti(L, LUA_REGISTRYINDEX, reference);
  lua_rawgeti(L, -1, index);

  if (!lua_isnil(L, -1))
  {
    lua_remove(L, -2);
    return true;
  }

  lua_pop(L, 2);
  return false;
}

LUALIB_API bool tolua_pushnewudata(lua_State* L, const char* meta, int reference, int index)
{
  lua_rawgeti(L, LUA_REGISTRYINDEX, reference);
  luanet_newudata(L, index);
  lua_getfield(L, LUA_REGISTRYINDEX, meta);

  if (lua_isnil(L, -1))
  {
    return false;
  }

  lua_setmetatable(L, -2);                 
  lua_pushvalue(L, -1);
  lua_rawseti(L, -3, index);
  lua_remove(L, -2);
  return true;
}