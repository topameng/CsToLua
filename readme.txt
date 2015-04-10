2015.4.10
加入了过滤列表，扔掉无用的函数和属性（感谢Master shifu提供），有点懒一直没加这个。造成了反复的提问。
也感谢骏擎的耐心回答
修改了GetUnityObject和GetTrackedObject函数，临时修改总是伴随bug. sigh
修正了LuaFunction 获取问题，不影响协同中使用回调函数。感谢最后的骄傲提供的方法

2015.4.2
加入两个新的函数GetUnityObject和GetTrackedObject用于生成wrap文件
解决lua访问的对象在c#端已经被删除也能提示lua代码错误位置

2015.3.16
解决Unity 空对象并非真的.net null 问题, 解决ulua对象池Unity空对象匹配bug
加入protobuf proto-gen-lua 导入导出支持
修改ulua使用GCHandle 64位问题
修改LuaBase多state下释放bug (c# gc多线程问题)
LuaFunction 增加辅助函数，辅助实现Call()函数优化（使用可变参数会有GC Alloc）
LuaTable 增加获取函数
ObjectTranslator 正确压入为null的UnityEngine.Object派生对象和TrackedReference派生对象（u3d这些对象不是真正的null）。
加入Delegate导入类型，委托可以调用Add,Remove等函数
加入Enum导入类型，优化枚举存储
加入string导入类型，可以把常用lua string 转为c# string保存（如动画名称等），避免GC Alloc
支持Update, LateUpdate, FixedUpdate等调用。
扩展lua协同，可以完美模拟c#协程
加入lua Timer 支持定时器
加入lua Event 模拟c#委托操作, 全逻辑基于lua事件不需要c#委托
加入lua Vector3, Vector2, Vector4, Quaternion, Color, Touch, RaycastHit, Ray, LayerMask等值类型支持
修改了自动生成wrap文件中的Type[] 数组，减少GC Alloc
修改了lua支持c#包裹类的 __index和__newindex 函数。加入枚举类型 __index 函数
完美支持多state.包括多state协同等问题
更完善的出错信息
对于函数参数的out类型参数，在lua端可以使用nil匹配函数输入参数，如：
local flag, hit = Physics.Raycast(self.transform.position, self.dir, nil, 1, self.layerMask)

加入了class, list, set 等数据结构
加入 Plane.lua 用来进行平面射线检测
扩展了lua math 数学库，加入部分u3d mathf 功能


2014.12.22
通过扫描wrap文件名，自动产生LuaBinder.cs文件
CheckType 优化
u3d Object 类转 system Object. null 变量问题

感谢晚餐同学发现的2个Bug
Lua 对象gc多线程问题
uLua objectsBackMap u3d Object匹配错误问题

2014.11.26
luajit升级为2.0.3版本,pc需要vs2012运行库
加入枚举相等判断
加入Table名称构造函数，如local go = GameObject("Light")
修改了导出方式，现在可以只写一个类型就能导出类了
导出了unity所有的类，有一些扔掉了，具体参见BindLua.cs文件
删除了某些影响build函数，应该是属于内部或者编辑器相关函数
修改了注册方式，现在所有类型注册顺序无关，
注意如果某个基类没有导出，派生类访问基类函数会出错
加入了lua xml库.
加入namespace控制，如GameObject位于UnityEngine空间
修复了LuaBase派生类的lua ref泄漏问题.

2014.11.10
向lua压入数组参数潜在的内存泄漏问题
GetNetObject 对读取的lua参数进行类型匹配检测
加入GetTypeObject读取Type类型
把压入到lua的枚举变量转变为userdata,现在重载函数完美区分double和enum类型
枚举类型加入 IntToEnum 函数，把一个int值转换为当前类型枚举
加入模版类型导出支持，如导出Dictionary<int,string>类型

2014.11.3
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
4. 更好的控制c#函数可见性
5. 可以修改包裹类，更快的回收内存
6. 可以支持数组参数。可以在lua端用table传递传递数组参数
7. 处理二义性。如lua number参数类型可以对应很多c#函数，自动选取精度最高的函数
8. 支持重载函数
9. 类型强匹配，如果某个参数在lua传递nil,可通过重载函数支持，或者使用object参数
10. 解决重载函数参数匹配优先级问题。对于object之类类型最后匹配，优先使用更精确的匹配
11. 严格区分枚举类型和int值，避免造成某些u3d重载函数混淆
12. 支持导出模板类。可以作为自定义类型导出到lua中。不建议使用（使用lua table）

目前不支持的导出：
1. 泛型模版函数
2. 不支持默认参数, 可以自己通过重载函数解决
3. 数组操作符，可以用set_Item, get_Item函数取代

