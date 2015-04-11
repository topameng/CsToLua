--------------------------------------------------------------------------------
--      Copyright (c) 2015 , 蒙占志(topameng) topameng@gmail.com
--      All rights reserved.
--
--      Use, modification and distribution are subject to the "New BSD License"
--      as listed at <url: http://www.opensource.org/licenses/bsd-license.php >.
--------------------------------------------------------------------------------
-- 扩展lua协同为c#协同形式

local create = coroutine.create
local running = coroutine.running
local resume = coroutine.resume
local yield = coroutine.yield

function coroutine.start(f, ...)		
	local co = create(f)
	
	if running() == nil then
		local flag, msg = resume(co, ...)
	
		if not flag then		
			error(msg)
		end		
	else
		local args = {...}
		
		local action = function()							
			local flag, msg = resume(co, unpack(args))
	
			if not flag then				
				error(msg)		
			end		
		end
			
		local timer = FrameTimer.New(action, 0, 1)
		timer:Start()
	end
end

function coroutine.wait(t, ...)
	local args = {...}
	local co = running()
	
	local action = function()		
		local flag, msg = resume(co, unpack(args))
		
		if not flag then
			error(msg)			
		end
	end
	
	local timer = CoTimer.New(action, t, 1)
	timer:Start()
	return yield()
end

function coroutine.step(t, ...)
	local args = {...}
	local co = running()		
	
	local action = function()							
		local flag, msg = resume(co, unpack(args))
	
		if not flag then
			error(msg)		
		end		
	end
			
	local timer = FrameTimer.New(action, t or 1, 1)
	timer:Start()
	return yield()
end

