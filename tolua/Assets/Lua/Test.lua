--按namespace区分类型定义
require "Golbal"

--测试极端条件性能
function Test(transform)	
	local t = Time.time
	
	local v = Vector3.one
	local one = Vector3.one

	for i = 1,800000 do
		v = transform.position
		v:Add(one)
		transform.position = v
	end

	print("lua cost time: ", Time.time - t)
end

function Test2()	
	local t = Time.time	
	local v = Vector3.one
	local one = Vector3.one

	for i = 1,800000 do		
		v:Add(one)		
	end

	print("lua cost time: ", Time.time - t, v)
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
	print("a simple coroutine test")
	print("current time:"..Time.time)
	coroutine.wait(1)
	print("sleep time:"..Time.time)
	print("current frame:"..Time.frameCount)
	coroutine.step()
	print("yield frame:"..Time.frameCount)		
	print("coroutine over")
end

--测试协同
coroutine.start(TestCo)
