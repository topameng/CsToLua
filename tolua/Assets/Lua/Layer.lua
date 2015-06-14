
local Layer = 
{
	Default			= 0,
	TransparentFX 	= 1,
	Ignore_Raycast 	= 2,
	
	Water 		= 4,
	UI 			= 5,
	
	Player 		= 8,	
	Monster 	= 9,
	Ground		= 10,
	Obstacle	= 11,	
	Dead		= 12,
}

LayerMask = 
{
	value = 0,
}

setmetatable(LayerMask, LayerMask)

LayerMask.__call = function(t,v)
	return LayerMask.New(v)
end

function LayerMask.New(value)
	local layer = {}
	setmetatable(layer, LayerMask)
	value = value and value or 0
	layer.value = value
	return layer
end

function LayerMask.NameToLayer(name)
	return Layer[name]
end

function LayerMask.MultiLayer(...)
	local arg = {...}
	local value = 0	

	for i = 1, #arg do		
		value = value + bit.lshift(1, LayerMask.NameToLayer(arg[i]))				
	end	
		
	return value
end



