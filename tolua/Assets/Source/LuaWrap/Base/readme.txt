EnumWrap 手动加入了 __eq 函数
DelegateWrap 手动加入了 Add , +，- 操作符函数
IEnumeratorWrap 无修改
ObjectWrap Destroy类函数加入了主动gc
MsgPackWrap 修改了PushLuaString函数，用于压入协议buffer
NetObjectWrap 加入了IsNull 和 Destroy (用于及时回收)函数
