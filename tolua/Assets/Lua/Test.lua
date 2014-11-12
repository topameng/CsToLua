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
local v1 = Vector3.New(1,2,3)
v1 = v1 + Vector3.one
print(v1)


--local go = GameObject.New("Testenum")
--go.transform:Rotate(Vector3.one, Space.Self)

--local go = GameObject.New("123")
--local lt = go:AddComponent(Light.GetClassType())
--lt.type = LightType.IntToEnum(1)


--测试协同
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


local co = coroutine.create(TestCo)
coroutine.resume(co)
