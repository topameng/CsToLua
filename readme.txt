tolua# 是一个类似于tolua++的工具
目的是为了快速导出unity3d类对象到lua中
依赖对象 luainterface 一个导出c#到lua的库
自己导出对象有各种好处如：

1. 极大的提升效率，luainterface采用反射调用c#函数，性能较差
2. 可以提供操作符函数到lua中
3. 可以支持可变参数列表
4. 更好的控制c#函数可见性

git 太难用了!!!