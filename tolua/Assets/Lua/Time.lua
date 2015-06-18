local beginTime = os.clock()
local unscaledTime = tolua.gettime()

Time = 
{
	fixedDeltaTime 	= 0,
	deltaTime 		= 0,
	frameCount 		= 1,
	timeScale		= 1,
	timeSinceLevelLoad 	= 0,
	unscaledDeltaTime	= 0,		
}

local mt = {}
mt.__index = function(obj, name)
	if name == "time" or name == "realtimeSinceStartup" then
		return os.clock() - beginTime
	elseif name == "unscaledTime" then
		return tolua.gettime() - unscaledTime
	else
		return rawget(obj, name)		
	end
end

function Time:Init()
	self.frameCount	= UnityEngine.Time.frameCount
	self.fixedTime	= UnityEngine.Time.fixedTime 
	self.timeScale	= UnityEngine.Time.timeScale
	self.deltaTime = 0	
	setmetatable(self, mt)
end

function Time:SetDeltaTime(deltaTime, unscaledDeltaTime)
	self.deltaTime = deltaTime
	self.frameCount = self.frameCount + 1
	self.timeSinceLevelLoad = self.timeSinceLevelLoad + deltaTime
	self.unscaledDeltaTime = unscaledDeltaTime
end

function Time:SetFixedDelta(time)
	self.fixedDeltaTime = time
	self.deltaTime = time
end

function Time:SetTimeScale(scale)
	self.timeScale = scale
	UnityEngine.Time.timeScale = scale
end