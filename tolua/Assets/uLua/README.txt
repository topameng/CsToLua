2015.6.25 1.9.9
函数参数支持lua function 转 event
加入几个例子程序
在c#中初始化 layer
lua文件使用utf8编码

2015.6.11 1.9.8
修复泛型类导出时Enumerator问题
数组属性支持table数组赋值
添加例子程序。

2015.6.3 1.9.7
重载函数生成代码优化，减少不必要的类型检查。速度略有提升
支持类型特殊化处理。可自己扩展导出函数，也可扔掉自己不想用的函数。暂时只支持函数。
减少绑定文件占用的内存 （感谢钟纬测试反馈）
启动时自动导出类型（感谢大C提醒，虽然加的晚了点）
Base类型没有注册时将有警告提醒。
可以扔掉毫无用处的类比如 Motion
fix LuaFunction 返回值bug
fix pb.c ios arm 边界对齐问题

因为支持了特化处理，不在需要手动修改几个基类导出代码了。
so 启动会自动生成一部分常用代码。当然你还可以通过菜单来生成，或者把你天才的想法加入到特化处理里面

2015.5.29 1.9.6
修正bindlua名称空间bug.
Vector3, Quaternion 功能修正，行为同unity3d一致。
(修正Vector3 RotateTowards, MoveToward, Quaternion.SetEuler, ToEulerAngles, SetFromToRotation, LookRotation等).
Quaternion 加入Forward 函数，如果提取了Tranform.rotation, 可从旋转直接取forward， 而不需要跨语言从Transform提取。
减少一次跨语言交互
优化print函数

2015.5.21 1.9.5
加入了Bounds值类型
优化了LuaInterface创建userdata速度
部分函数写入c中包括index，newindex函数等，可提升手机上效率（pc由于jit非凡表现差距不大）
优化了PushTouch效率。
优化了枚举效率，枚举在lua唯一性（不是与int值区别，这个早有了）。
加入了委托变量可以赋值 LuaFunction，并且没有gc alloc (如果需要支持委托 + 操作，需要另外导出委托)感谢kingowl提供
修改了Quaternion.Lerp 的bug
修正一个了ios反射编译问题, 感谢Quon
协同出错时，stack信息更详细, 感谢最后的骄傲提醒

以前关于LuaStringBuffer一部分内容丢失了，补上（感谢端火锅的猫提醒）
加入了检测基类是否wrap的提醒

2015.4.13 1.9.3
修正Vector2.lua 和 Vectoe4.lua 部分bug
Object 和object Equals判断支持null对象
IndexArray 支持所有类型（感谢钟纬提醒）

2015.4.13 1.9.1
修正Params数组参数在重载函数中的排序问题(放在最后面，感谢BeTheOne发现)
修正Color.lua参数问题

2015.4.13 1.9.0
优化 Quaternion Slerp函数。
修正GetArrayObject (感谢敏敏特木耳提醒) 和 GetVarTable bug
CheckType支持LuaTable值类型

2015.4.10
加入了过滤列表，扔掉无用的函数和属性（感谢Master shifu提供），有点懒一直没加这个。造成了反复的提问。
也感谢骏擎的耐心回答
修改了GetUnityObject和GetTrackedObject函数，临时修改总是伴随bug. sigh
修正协同中LuaFunction 获取问题，不影响协同中使用回调函数。感谢最后的骄傲提供的方法
修正协同中LuaTable获取问题

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
CheckType 优化(感谢晚餐的提醒)
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

Lua + LuaJIT + LuaInterface

Supported Platforms: iOS, Android, Windows, Mac (x86 only), Linux
