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
