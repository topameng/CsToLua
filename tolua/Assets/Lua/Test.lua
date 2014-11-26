--按namespace区分类型定义
object			= System.Object
Type			= System.Type
Time 			= UnityEngine.Time
GameObject 		= UnityEngine.GameObject
Light 			= UnityEngine.Light
LightType 		= UnityEngine.LightType
Transform 		= UnityEngine.Transform
Vector3			= UnityEngine.Vector3
MonoBehaviour 	= UnityEngine.MonoBehaviour
Space			= UnityEngine.Space

--测试极端条件性能
function Test(transform)
	local t = Time.realtimeSinceStartup;
	local v = Vector3.one

	for i=1,200000 do
		transform.position = v
	end

	print("lua cost time: " .. (Time.realtimeSinceStartup - t));
end


--测试操作符函数
print("Test Vector3 operator func")
local v1 = Vector3(1,2,3)
v1 = v1 + Vector3.one
print("Vector3 value is:" .. tostring(v1))

--支持table名称构造函数
local go = GameObject("Testenum")
--区分枚举和number值重载函数
go.transform:Rotate(Vector3.one, Space.Self)
go.transform:Rotate(Vector3.up, 12.5)

local go = GameObject("Light")
--方便的获取类型信息 表名.GetClassType
local lt = go:AddComponent(Light.GetClassType())
--把一个number类型转换为枚举
lt.type = LightType.IntToEnum(1)

--枚举比较
if lt.type == LightType.Directional then
	print("we have a directional light")
end


function TestCo()
	print("current time:"..Time.time)
	coroutine.waitforseconds(1)
	print("sleep time:"..Time.time)
	print("current frame:"..Time.frameCount)
	coroutine.yieldone()
	print("yield frame:"..Time.frameCount)
	print("end frame:"..Time.frameCount)
	coroutine.waitforendofframe()
	print("end frame:"..Time.frameCount)
	print("coroutine over")
end

--测试协同
local co = coroutine.create(TestCo)
coroutine.resume(co)
