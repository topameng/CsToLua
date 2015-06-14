Raycast = 
{
}

local mt = {}
mt.__index = Raycast

function Raycast.New(collider, distance, normal, point, rigidbody, transform)
	local hit = {}
	setmetatable(hit, mt)
	hit:Init(collider, distance, normal, point, rigidbody, transform)
	return hit
end

function Raycast:Init(collider, distance, normal, point, rigidbody, transform)
	self.collider 	= collider
	self.distance 	= distance
	self.normal 	= normal
	self.point 		= point
	self.rigidbody 	= rigidbody
	self.transform 	= transform
end

function Raycast:Destroy()				
	self.collider 	= nil			
	self.rigidbody 	= nil					
	self.transform 	= nil		
end
