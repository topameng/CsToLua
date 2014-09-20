uLua 1.02
==========================
- Added UTF-8 Support
- Added Coroutine example
- Added Lua 'require' explanation
- Minor Fixes

uLua 1.01
==========================
- Fixed iOS build (was using out of date scripts which were causing AOT errors as well as not finding the symbols in some cases)

uLua 1.0 (Initial Release)
==========================

Lua + LuaJIT + LuaInterface

Supported Platforms: iOS, Android, Windows, Mac (x86 only), Linux

Features:

- Lua 5.1.4 for all supported platforms
- Amazing Lua performance thanks to LuaJIT
- LuaInterface based for powerful C# integration
- Additional LuaInterface features: Lua Coroutines, Unity error handling, more Lua API functions
- Prebuilt Lua plugin

See readme for usage.

ulua-support@polynationgames.com

E-mail me for support if anything is not working. I'll try my best to help!

I can add more examples on request.

Please do not request the source code, I'll say no.

USAGE
=====

Copy all (or relevant) plugins from 'uLua/Plugins/' to your project Plugins directory.

Add LuaInterface namespace to your script and you're good to go.

Check out the examples for some basic usage. The main code is quite readable (Lua.cs) and the LuaInterface manual included is relevant.

EXAMPLES
========

01_HelloWorld
02_CreateGameObject
03_AccessingLuaVariables
04_ScriptsFromFile
05_CallLuaFunction
06_LuaCoroutines

Lua 'require' or 'dofile'
=============

In order to import a file with require and/or dofile you must have the text asset placed within 'Assets/Resources' of your root project directory and it must be named '*.lua.txt'.

For example: 
'Assets/Resources/MyDir/myscript.lua.txt'

And then in your Lua code it can be required with: 
'require("MyDir/myscript.lua")'

MacOS
======

Due to build requirements of LuaJIT, only the x86 build will work. This is because in order to link with LuaJIT specific linker settings are required for the Unity engine, which I have no control over.

In future I'm considering a Non-JIT alternative set of Lua plugins, if you're not as worried about performance and still need the different versions.

iOS
===

iOS does not support dynamic assemblies and some features of LuaInterface (namely delegate generation from Lua) depend on it. As such there is a 
flag for disabling this support. Simply define __NOGEN__ and all your platforms will be restricted in the same way.

If you're just developing for iOS Only, it will automatically disable this for iOS specifically.
