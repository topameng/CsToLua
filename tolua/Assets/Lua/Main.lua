UpdateBeat = Event("Update", true)
LateUpdateBeat = Event("LateUpdate", true)
CoUpdateBeat = Event("CoUpdate", true)
FixedUpdateBeat = Event("FixedUpdate", true)

function TestCo2()
	local go = GameObject.Find("/Cube")
	local render = go.renderer
	local mat = render.material
	local i = 1
	
	while true do
		mat.color = Color.red
		coroutine.wait(0.2)		
		mat.color = Color.white
		coroutine.wait(0.2)		
	end
	
	print("coroutine2 over:", i)
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


function Main()
	Time:Init()
	
	--测试协同
	--coroutine.start(TestCo)
	--coroutine.start(TestCo2)
end

function Update(deltatime, unscaledDeltaTime)
	Time:SetDeltaTime(deltatime, unscaledDeltaTime)
	UpdateBeat()
end

function LateUpdate()
	LateUpdateBeat()
	CoUpdateBeat()
end

function FixedUpdate(fixedTime)
	Time:SetFixedDelta(fixedTime)
	FixedUpdateBeat()
end

function OnLevelWasLoaded(level)
	Time.timeSinceLevelLoad = 0
end