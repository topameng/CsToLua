#!/bin/bash
#
# Windows 32-bit/64-bit

# Copyright (C) polynation games ltd - All Rights Reserved
# Unauthorized copying of this file, via any medium is strictly prohibited
# Proprietary and confidential
# Written by Christopher Redden, December 2013

# 62 Bit Version
mkdir -p tmp

cd luajit
mingw32-make clean

mingw32-make BUILDMODE=static CC="gcc -m64"
cp src/libluajit.a ../tmp/libluajit.a

cd ..

gcc lua_wrap.c -o Plugins/x86_64/ulua.dll -m64 -shared -Iluajit/src -Wl,--whole-archive tmp/libluajit.a -Wl,--no-whole-archive

# 32 Bit Version
cd luajit
mingw32-make clean

mingw32-make BUILDMODE=static CC="gcc -m32"
cp src/libluajit.a ../tmp/libluajit.a

cd ..

gcc lua_wrap.c -o Plugins/x86/ulua.dll -m32 -shared -Iluajit/src -Wl,--whole-archive tmp/libluajit.a -Wl,--no-whole-archive
