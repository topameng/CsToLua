/* 
* Copyright (C) polynation games ltd - All Rights Reserved
* Unauthorized copying of this file, via any medium is strictly prohibited
* Proprietary and confidential
* Written by Christopher Redden, December 2013
* This file is based off of MonoLuaInterface's wrapping: https://github.com/stevedonovan/MonoLuaInterface
*/

#include "lua.h"

/*  LUA INTERFACE SUPPORT  */
#ifndef _WIN32
#define __stdcall
#endif
typedef int (__stdcall *lua_stdcallCFunction) (lua_State *L);
static int tag = 0;

static int stdcall_closure(lua_State *L) 
{
    lua_stdcallCFunction fn = (lua_stdcallCFunction)lua_touserdata(L, lua_upvalueindex(1));
    int r = fn(L);
    return r;
}

LUALIB_API void lua_pushstdcallcfunction(lua_State *L, lua_stdcallCFunction fn) 
{
    lua_pushlightuserdata(L, fn);
    lua_pushcclosure(L, stdcall_closure, 1);
}

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
  int *udata=lua_touserdata(L,index);
  if(udata!=NULL) return *udata;
  return -1;
}

