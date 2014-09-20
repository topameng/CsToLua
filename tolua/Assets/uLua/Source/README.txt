uLua source code comes with no support guarantees, and is for advanced users who need to integrate their own work, or to debug the plugin.

The uLua source code and build scripts are proprietary and confidential. Unauthorized copying, via any medium is strictly prohibited.

LuaJIT
I did not write LuaJIT and therefore will not distribute the source code. uLua uses LuaJIT 2.0.2 which can be obtained from http://luajit.org/

BUILDING
- Place LuaJIT distribution in <source root>/luajit
- Run platform specific shell script to build uLua library
- Copy uLua library into relevant Unity plugins folder

WINDOWS
Windows build requires Mingw32 (64bit) in order to build with the given scripts.