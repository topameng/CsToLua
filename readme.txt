2012.11.10
向lua压入数组参数潜在的内存泄漏问题
GetNetObject 对读取的lua参数进行类型匹配检测
加入GetTypeObject读取Type类型
把压入到lua的枚举变量转变为userdata,现在重载函数完美区分double和enum类型
枚举类型加入 IntToEnum 函数，把一个int值转换为当前类型枚举
加入模版类型导出支持，如导出Dictionary<int,string>类型


2012.11.3
细分Push函数，对于数组提供一种通用的数组metatable，
减少ulua对于数组metatable个数泛滥问题
加入类c#协同支持，例子见Test.lua

2014.10.22
更细的切分LuaScriptMgr.Push 函数，主要针对System.object重载函数
消除此函数潜在的bug
所有类型加入GetClassType函数，现在可以非常便利的获取类型。
如：gameObject.GetComponent(UICamera.GetClassType())

2014.10.17
替换dll, 加入lua protobuf库

2014.10.8
加入枚举类型的导出
优化LuaScriptMgr PushResult函数。通过重载函数消除switch
重载函数中参数数量唯一的，string转换放宽

2014.9.30
string类型CheckType加上了userdata
非重载函数string可以匹配所有类型
重载函数必须自己用tostring转换为string类型.
因为object也可以转换所有类型，匹配容易出问题

2014.9.29
LuaFunction构造函数中luastate未赋值问题
感谢Chiuan提供

2014.9.28
加入了对构造函数可变参数的支持
加入了object可以转换所有参数问题。重载函数非object类型优先比较
修复了params参数为0的bug
count - 0 正确输入为 count

2014.9.26
修改了__index函数加快了索引过程,性能有很好的提升
修改了LuaScriptMgr支持多luastate
修复了协同堆栈不对的bug

感谢Chiuan、骏擎【CP】 同学的试用和反馈
2014.9.23
修复MonoBehaviour 继承类出现构造函数的问题
修复private set 属性被导出问题


tolua# 是一个类似于tolua++的工具
目的是为了快速导出unity3d类对象到lua中
依赖对象 luainterface 一个导出c#到lua的库
自己导出对象有各种好处如：

1. 极大的提升效率，luainterface采用反射调用c#函数，性能较差
2. 可以扩展操作符函数到lua中
3. 可以支持可变参数列表
4. 更好的控制c#函数可见性。
5. 可以修改包裹类，更快的回收内存
6. 可以支持数组参数。可以在lua端用table传递传递数组参数
7. 处理二义性。如lua number参数类型可以对应很多c#函数，自动选取精度最高的函数

目前不支持的导出：
1. 泛型模版函数
2. 不支持默认参数, 可以自己通过重载函数解决
3. 数组操作符

