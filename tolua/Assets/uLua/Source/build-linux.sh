#!/bin/bash
#
# Linux 32-bit/64-bit

# Copyright (C) polynation games ltd - All Rights Reserved
# Unauthorized copying of this file, via any medium is strictly prohibited
# Proprietary and confidential
# Written by Christopher Redden, December 2013

# 62 Bit Version
mkdir -p linux

cd luajit
make clean

make BUILDMODE=static CC="gcc -fPIC"
cp src/libluajit.a ../linux/libluajit.a

cd ..

gcc -fPIC lua_wrap.c -o Plugins/x86_64/libulua.so -shared -Iluajit/src -Wl,--whole-archive linux/libluajit.a -Wl,--no-whole-archive

# 32 Bit Version
cd luajit
make clean

make BUILDMODE=static CC="gcc -fPIC -m32"
cp src/libluajit.a ../linux/libluajit.a

cd ..

gcc -fPIC lua_wrap.c -o Plugins/x86/libulua.so -shared -m32 -Iluajit/src -Wl,--whole-archive linux/libluajit.a -Wl,--no-whole-archive
