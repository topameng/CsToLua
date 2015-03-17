--------------------------------------------------------------------------------
--      Copyright (c) 2015 , 蒙占志(topameng) topameng@gmail.com
--      All rights reserved.
--
--      Use, modification and distribution are subject to the "New BSD License"
--      as listed at <url: http://www.opensource.org/licenses/bsd-license.php >.
--------------------------------------------------------------------------------

local sin 	= math.sin
local cos 	= math.cos
local acos 	= math.acos
local asin 	= math.asin
local sqrt 	= math.sqrt
local min	= math.min
local max 	= math.max
local sign	= math.sign
local atan2 = math.atan2
local clamp = math.clamp
local abs	= math.abs

local rad2Deg = math.rad2Deg
local halfDegToRad = 0.5 * math.deg2Rad

Quaternion = 
{
	x = 0,
	y = 0,
	z = 0,
	w = 0,	

	class = "Quaternion",
}

setmetatable(Quaternion, Quaternion)

Quaternion.__index = function(t, name)		
	local var = rawget(Quaternion, name)
	
	if var then
		return var	
	end
	
	if name == "identity" then
		return Quaternion.New(0, 0, 0, 1)
	elseif name == "eulerAngles" then
		return t:ToEulerAngles()
	end
	
	return nil
end

Quaternion.__newindex = function(t, name, k)	
	if name == "eulerAngles" then
		t:SetEuler(k)
	else
		rawset(t, name, k)
	end	
end

function Quaternion.New(x, y, z, w)
	local quat = {}	
	setmetatable(quat, Quaternion)
	quat:Set(x,y,z,w)
	return quat
end

function Quaternion:Set(x,y,z,w)
	self.x = x or 0
	self.y = y or 0
	self.z = z or 0
	self.w = w or 0
end

function Quaternion:Clone()
	return Quaternion.New(self.x, self.y, self.z, self.w)
end

function Quaternion:Get()
	return self.x, self.y, self.z, self.w
end

function Quaternion.Dot(a, b)
	return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w
end

function Quaternion.Angle(a, b)
	return acos(min(abs(Quaternion.Dot(a, b)), 1)) * 2 * 57.29578	
end

function Quaternion.AngleAxis(angle, axis)
	local normAxis = axis:Normalize()
    angle = angle * halfDegToRad
    local sinAngle = sin(angle)
    local cosAngle = cos(angle)
    
    local w = cosAngle
    local x = normAxis.x * sinAngle
    local y = normAxis.y * sinAngle
    local z = normAxis.z * sinAngle
	
	return Quaternion.New(x,y,z,w)
end

function Quaternion.Equals(a, b)
	return a.x == b.x and a.y == b.y and a.z == b.z and a.w == b.w
end

function Quaternion.Euler(x, y, z)		
	local quat = Quaternion.New()	
	quat:SetEuler(x,y,z)
	return quat
end

function Quaternion:SetEuler(x, y, z)		
	if y == nil and z == nil then
		x = x.x
		y = x.y
		z = z.z	
	end
		
	x = x * halfDegToRad
    y = y * halfDegToRad
    z = z * halfDegToRad
	
	local sinX = sin(x)
    local cosX = cos(x)
    local sinY = sin(y)
    local cosY = cos(y)
    local sinZ = sin(z)
    local cosZ = cos(z)
    
    self.w = cosY * cosX * cosZ + sinY * sinX * sinZ
    self.x = cosY * sinX * cosZ + sinY * cosX * sinZ
    self.y = sinY * cosX * cosZ - cosY * sinX * sinZ
    self.z = cosY * cosX * sinZ - sinY * sinX * cosZ
	
	return self
end

function Quaternion:Normalize()
	local quat = self:Clone()
	quat:SetNormalize()
	return quat
end

function Quaternion:SetNormalize()
	local n = self.x * self.x + self.y * self.y + self.z * self.z + self.w * self.w
	
	if n ~= 1 and n > 0 then
		n = 1 / sqrt(n)
		self.x = self.x * n
		self.y = self.y * n
		self.z = self.z * n
		self.w = self.w * n		
	end
end

--产生一个新的从from到to的四元数
function Quaternion.FromToRotation(from, to)
	local quat = Quaternion.New()
	quat:SetFromToRotation(from, to)
	return quat
end

--设置当前四元数为 from 到 to的旋转, 注意from和to同 forward平行会同unity不一致
function Quaternion:SetFromToRotation(from, to)
	local v0 = from:Normalize()
	local v1 = to:Normalize()
	local d = Vector3.Dot(v0, v1)

	if d > -1 + 1e-6 then	
		local s = sqrt((1+d) * 2)
		local invs = 1 / s
		local c = Vector3.Cross(v0, v1) * invs
		self:Set(c.x, c.y, c.z, s * 0.5)	
	else
		local axis = Vector3.Cross(Vector3.right, v0)
		
		if axis:SqrMagnitude() < 1e-6 then
			axis = Vector3.Cross(Vector3.forward, v0)
		end

		self:Set(axis.x, axis.y, axis.z, 0)		
		return self
	end
	
	return self
end

function Quaternion:Inverse()
	local quat = Quaternion.New()
		
	quat.x = -self.x
	quat.y = -self.y
	quat.z = -self.z
	quat.w = self.w
	
	return quat
end

function Quaternion.Lerp(from, to, t)
	t = clamp(t, 0, 1)
	return Quaternion.New(from.x + ((to.x - from.x) * t), from.y + ((to.y - from.y) * t), from.z + ((to.z - from.z) * t), from.w + ((to.w - from.w) * t))
end

local vUp = Vector3.up

function Quaternion.LookRotation(forward, up)
	up = up or vUp			
	forward = forward:Normalize()
	local right = Vector3.Cross(up, forward)
	right:SetNormalize()    
    up = Vector3.Cross(forward, right)
    right = Vector3.Cross(up, forward)
    
	local w = sqrt(max(0, 1 + right.x + up.y + forward.z)) / 2
	local x = sqrt(max(0, 1 + right.x - up.y - forward.z)) / 2
	local y = sqrt(max(0, 1 - right.x + up.y - forward.z)) / 2
	local z = sqrt(max(0, 1 - right.x - up.y + forward.z)) / 2
	x = x * sign(x * (up.z - forward.y))
	y = y * sign(y * (forward.x - right.z))
	z = z * sign(z * (right.y - up.x))
	
	local ret = Quaternion.New(x, y, z, w)			
	return ret, forward, up
end

function Quaternion.Slerp(from, to, t)
	local cosAngle = Quaternion.Dot(from, to)
	t = clamp(t, 0, 1)
	
    if cosAngle < 0 then    
        cosAngle = -cosAngle
        to = -to
    end
    
    local angle 	= acos(cosAngle)
    local sinAngle 	= sin(angle)
    local t1, t2
    
    if sinAngle > 0.001 then    
        local invSinAngle = 1 / sinAngle
        t1 = sin((1 - t) * angle) * invSinAngle
        t2 = sin(t * angle) * invSinAngle    
    else    
        t1 = 1 - t
        t2 = t
    end
    
	local quat = Quaternion.New(from.x * t1 + to.x * t2, from.y * t1 + to.y * t2, from.z * t1 + to.z * t2, from.w * t1 + to.w * t2)
	quat:SetNormalize()
	return quat
end

function Quaternion:SetIdentity()
	self.x = 0
	self.y = 0
	self.z = 0
	self.w = 1
end

function Quaternion.RotateTowards(from, to, maxDegreesDelta)   	
	local cosAngle = Quaternion.Dot(from, to)
	local num = acos(abs(cosAngle)) * 2 * 57.29578
	
	if num == 0 then
		return to
	end
				
    if cosAngle < 0 then    
        cosAngle = -cosAngle
        to = -to
    end
    
	local t 		= min(1, maxDegreesDelta / num)	
    local angle 	= acos(cosAngle)
    local sinAngle 	= sin(angle)
    local t1, t2
    
    if sinAngle > 0.001 then    
        local invSinAngle = 1 / sinAngle
        t1 = sin((1 - t) * angle) * invSinAngle
        t2 = sin(t * angle) * invSinAngle    
    else    
        t1 = 1 - t
        t2 = t
    end
    
	local quat = Quaternion.New(from.x * t1 + to.x * t2, from.y * t1 + to.y * t2, from.z * t1 + to.z * t2, from.w * t1 + to.w * t2)
	quat:SetNormalize()
	
	return quat
end

function Quaternion:ToAngleAxis()	
	local scale = sqrt(self.x * self.x + self.y * self.y + self.z * self.z)
	local w = clamp(self.w / scale, -1, 1)
	
	--怀疑u3d这里写错了 w < -1 也应该在这里
	if scale < 1e-6 and w > 1 then		
		return 0, Vector3.New(1, 0, 0)		
	end
	
	scale = 1/scale
	local angle = 2 * rad2Deg * acos(w)
	local axis = Vector3.New(self.x * scale, self.y * scale, self.z * scale)		
	return angle, axis
end

function Quaternion:ToEulerAngles()			
	local n = self.x * self.x + self.y * self.y + self.z * self.z + self.w * self.w
	n = 1 / sqrt(n)
		
	local x = self.x * n
	local y = self.y * n
	local z = self.z * n
	local w = self.w * n
	
	local check = 2 * (-y * z + w * x)
    	
    if check < -0.999999 then    
        return Vector3.New(-90, -atan2(2 * (x * z - w * y), 1 - 2 * (y * y + z * z)) * rad2Deg, 0)    
    elseif (check > 0.999999) then    
        return Vector3.New(90, -atan2(2 * (x * z - w * y), 1 - 2 * (y * y + z * z)) * rad2Deg, 0)    
    else    
        return Vector3.New(asin(check) * rad2Deg,
            atan2(2 * (x * z + w * y), 1 - 2 * (x * x + y * y)) * rad2Deg,
            atan2(2 * (x * y + w * z), 1 - 2 * (x * x + z * z)) * rad2Deg)
    end
end


function Quaternion.MulVec3(self, point)
	local vec = Vector3.New()
    
	local num 	= self.x * 2
	local num2 	= self.y * 2
	local num3 	= self.z * 2
	local num4 	= self.x * num
	local num5 	= self.y * num2
	local num6 	= self.z * num3
	local num7 	= self.x * num2
	local num8 	= self.x * num3
	local num9 	= self.y * num3
	local num10 = self.w * num
	local num11 = self.w * num2
	local num12 = self.w * num3
	
	vec.x = (((1 - (num5 + num6)) * point.x) + ((num7 - num12) * point.y)) + ((num8 + num11) * point.z)
	vec.y = (((num7 + num12) * point.x) + ((1 - (num4 + num6)) * point.y)) + ((num9 - num10) * point.z)
	vec.z = (((num8 - num11) * point.x) + ((num9 + num10) * point.y)) + ((1 - (num4 + num5)) * point.z)
	
	return vec
end

Quaternion.__mul = function(lhs, rhs)
	if rhs.class == Quaternion.class then
		return Quaternion.New((((lhs.w * rhs.x) + (lhs.x * rhs.w)) + (lhs.y * rhs.z)) - (lhs.z * rhs.y), (((lhs.w * rhs.y) + (lhs.y * rhs.w)) + (lhs.z * rhs.x)) - (lhs.x * rhs.z), (((lhs.w * rhs.z) + (lhs.z * rhs.w)) + (lhs.x * rhs.y)) - (lhs.y * rhs.x), (((lhs.w * rhs.w) - (lhs.x * rhs.x)) - (lhs.y * rhs.y)) - (lhs.z * rhs.z))	
	elseif rhs.class == Vector3.class then
		return lhs:MulVec3(rhs)
	end
end

Quaternion.__unm = function(q)
	return Quaternion.New(-q.x, -q.y, -q.z, -q.w)
end

Quaternion.__eq = function(lhs,rhs)
	return Quaternion.Dot(lhs, rhs) > 0.999999
end

Quaternion.__tostring = function(self)
	return string.format("[%f,%f,%f,%f]", self.x, self.y, self.z, self.w)
end
