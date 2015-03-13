Touch = 
{
	fingerId 		= 0,
	position	 	= nil,
	rawPosition	 	= nil,
	deltaPostion 	= nil,
	deltaTime 		= 0,
	tapCount 		= 0,
	phase 			= nil,		
}

local mt = {}
mt.__index = Touch

function Touch.New(fingerId, position, rawPosition, deltaPostion, deltaTime, tapCount, phase)
	local touch = {}
	setmetatable(touch, mt)
	touch.fingerId = fingerId
	touch.position = position
	touch.rawPosition = rawPosition
	touch.deltaPosition = deltaPostion
	touch.deltaTime = deltaTime
	touch.tapCount = tapCount
	touch.phase = phase
	return touch
end

function Touch:Destroy()
	self.position 		= nil
	self.rawPosition	= nil
	self.deltaPostion 	= nil
	self.phase			= nil
end


