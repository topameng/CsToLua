cd /d %~dp0
cd out
del /s *.txt
del /s *.bytes
cd..
for %%i in (*.lua) do luajit -b %%i out\%%i
cd out
ren *.lua *.lua.bytes
cd..