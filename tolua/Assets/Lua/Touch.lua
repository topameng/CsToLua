--------------------------------------------------------------------------------
--      Copyright (c) 2015 , 蒙占志(topameng) topameng@gmail.com
--      All rights reserved.
--
--      Use, modification and distribution are subject to the "New BSD License"
--      as listed at <url: http://www.opensource.org/licenses/bsd-license.php >.
--------------------------------------------------------------------------------

local zero = Vector2.zero

TouchPhase =
{
	Began = 0,
	Moved = 1,
	Stationary = 2,
	Ended = 3,
	Canceled = 4,
}

Touch = 
{
	fingerId 		= 0,
	position	 	= zero,
	rawPosition	 	= zero,
	deltaPostion 	= zero,
	deltaTime 		= 0,
	tapCount 		= 0,
	phase 			= TouchPhase.Began,		
}

local mt = {}
mt.__index = Touch

function Touch.New(fingerId, position, rawPosition, deltaPostion, deltaTime, tapCount, phase)
	local touch = {fingerId = 0, position = zero, rawPosition = zero, deltaPostion = zero, deltaTime = 0, tapCount = 0, phase = 0}
	
	setmetatable(touch, mt)
	touch:Init(fingerId, position, rawPosition, deltaPostion, deltaTime, tapCount, phase)	
	return touch
end

function Touch:Init(fingerId, position, rawPosition, deltaPostion, deltaTime, tapCount, phase)
	self.fingerId = fingerId
	self.position = position
	self.rawPosition = rawPosition
	self.deltaPosition = deltaPostion
	self.deltaTime = deltaTime
	self.tapCount = tapCount
	self.phase = phase
end

function Touch:Destroy()
	self.position 		= nil
	self.rawPosition	= nil
	self.deltaPostion 	= nil
	self.phase			= nil
end


