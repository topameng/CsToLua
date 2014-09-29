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
7. 处理c#二义性。如lua number类型可以对应c#很多函数
8. 类数组操作符. 这个可能在下个版本扔掉。

目前不支持的导出：
1. 泛型模版函数。
2. 不支持默认参数

