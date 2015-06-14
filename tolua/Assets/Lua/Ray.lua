Ray = 
{
}

local mt = {}
mt.__index = Ray

function Ray.New(direction, origin)
	local ray = {}
	setmetatable(ray, mt)
	ray.direction 	= direction:Normalize()
	ray.origin 		= origin
	return ray
end

function Ray:GetPoint(distance)
	local dir = self.direction * distance
	dir:Add(self.origin)
	return dir
end

function Ray:Get()
	local o = self.origin
	local d = self.direction
	return o.x, o.y, o.z, d.x, d.y, d.z
end

mt.__tostring = function(self)
	return string.format("Origin:(%f,%f,%f),Dir:(%f,%f, %f)", self.origin:Get(), self.direction:Get())
end
