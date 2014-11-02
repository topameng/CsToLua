
function Test(transform)
	local t = Time.realtimeSinceStartup;
	local v = Vector3.one

	for i=1,200000 do
		transform.position = v
	end

	print("lua cost time: " .. (Time.realtimeSinceStartup - t));
end


local curve = AnimationCurve.New(Keyframe.New(1,2), Keyframe.New(1,2))

local Test = TestToLua.New("hello")
local Test1 = TestToLua.New("hello", "123")
Test:Test4(4, myFunc, 123)

--local co = coroutine.create(myFunc)
--local v, ret = coroutine.resume(co)
--print(tostring(v)..ret)
--v, ret = coroutine.resume(co)

print("Test Vector3 operator func")
local v1 = Vector3.New(1,2,3)
v1 = v1 + Vector3.one
print(v1)

print("The enum class TestEnum.Two is:" .. TestEnum.Two)



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
