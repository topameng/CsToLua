#!/bin/bash
#
# OS X 32-bit
# Copyright (C) polynation games ltd - All Rights Reserved
# Unauthorized copying of this file, via any medium is strictly prohibited
# Proprietary and confidential
# Written by Christopher Redden, December 2013

cd luajit
make clean
make CC="gcc -m32" BUILDMODE=static
cp src/libluajit.a ../osx/libluajit_x86.a

make clean
make CC="gcc" BUILDMODE=static
cp src/libluajit.a ../osx/libluajit_x86_64.a

cd ../osx/
xcodebuild
cd ..

mkdir -p ./Plugins
cp -r ./osx/DerivedData/ulua/Build/Products/Release/ulua.bundle ./Plugins/
