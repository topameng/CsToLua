
function Test(transform)
	local t = Time.realtimeSinceStartup;
	local v = Vector3.one

	for i=1,100000 do
		transform.position = v
	end

	print("lua cost time: " .. (Time.realtimeSinceStartup - t));

	local v1 = Vector3.New(1,2,3)
	v1 = v1 + v
	print(tostring(v1))
end

function waitSeconds(t)
	local timeStamp = Time.realtimeSinceStartup
	timeStamp = timeStamp + t
		while Time.realtimeSinceStartup < timeStamp do
			coroutine.yield()
		end
end

function fib(n)
	local a, b = 0, 1
	while n > 0 do
		a, b = b, a + b
		n = n - 1
	end

	return a
end

function myFunc()
	print('Coroutine started')
	local i = 0
		for i = 1, 5, 1 do
			print(fib(i))
			waitSeconds(1)
		end
    print('Coroutine ended')
end

local curve = AnimationCurve.New(Keyframe.New(1,2), Keyframe.New(1,2))

local Test = TestToLua.New("hello")
local Test1 = TestToLua.New("hello", "123")
Test:Test4(4,"123")



