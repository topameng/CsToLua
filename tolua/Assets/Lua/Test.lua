--按namespace区分类型定义
require "Golbal"

--测试极端条件性能
local go = GameObject.New()
local node = go.transform

function Test()	
	local transform = node
	
	local t = os.clock()
	for i = 1,200000 do
		local v = transform.position
		--v:Add(one)
		transform.position = v
	end

	--避免print 内部先执行然后才计算时间
	t = os.clock() - t	
	print("lua cost time: ", t)
end

function Test6()	
	local t = os.clock()
	local v = Vector3.one
	local one = Vector3.one

	for i = 1,200000 do		
		v:Add(one)		
		--GameObject.New()
	end

	local t = os.clock() - t
	print("lua cost time: ", t)
end

function Test2()	
	local transform = node
	local up = Vector3.up
	
	local t = os.clock()
	for i = 1,200000 do
		transform:Rotate(Vector3.up, 1)	
	end
	local t = os.clock() - t
	print("lua cost time: ", t)
end

function Test3()	
	local t = os.clock()
	for i = 1,200000 do
		local v = Vector3.New(i, i, i)
	end
	local t = os.clock() - t
	print("lua cost time: ", t)
end

function Test4()
	local t = os.clock()	

	for i = 1,200000 do				
		local go = GameObject.New()
	end

	t = os.clock() - t
	print("lua cost time: ", t)
end

--少见
function Test5()	
	local t = os.clock()
	local tp = SkinnedMeshRenderer.GetClassType()

	for i = 1,20000 do				
		local go = GameObject.New()
		go:AddComponent(tp)
    	local c = go:GetComponent(tp)
    	c.castShadows=false
    	c.receiveShadows=false
	end

	t = os.clock() - t
	print("lua cost time: ", t)
end

--区分枚举和int
function Test6()
	local go = GameObject("Testenum")
	go.transform:Rotate(Vector3.up, Space.Self)
	go.transform:Rotate(Vector3.up, 1)
end

--常见
function Test7()
	local t = os.clock()
	for i = 1,200000 do		
		local t = Input.GetTouch(0)		
		local p = Input.mousePosition
		--Physics.RayCast
	end

	--避免print 内部先执行然后才计算时间
	t = os.clock() - t	
	print("lua cost time: ", t)
end

--测试操作符函数
print("Test Vector3 operator func")
local v1 = Vector3(1,2,3)
v1 = v1 + Vector3.one
print("Vector3 value is:" .. tostring(v1))

local go = GameObject("Light")
--方便的获取类型信息 表名.GetClassType
local lt = go:AddComponent(Light.GetClassType())
--把一个number类型转换为枚举
lt.type = LightType.IntToEnum(1)

--枚举比较
if lt.type == LightType.Directional then
	print("we have a directional light")
end



