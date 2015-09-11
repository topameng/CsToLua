--------------------------------------------------------------------------------
--      Copyright (c) 2015 , 蒙占志(topameng) topameng@gmail.com
--      All rights reserved.
--
--      Use, modification and distribution are subject to the "New BSD License"
--      as listed at <url: http://www.opensource.org/licenses/bsd-license.php >.
--------------------------------------------------------------------------------

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

function coroutine.wait(time, co, ...)
	local args = {...}
	co = co or running()		
		
	local action = function()		
		local flag, msg = resume(co, unpack(args))
		
		if not flag then	
			msg = debug.traceback(co, msg)				
			Debugger.LogError("coroutine error:{0}", msg)		
			return
		end
	end
	
	local timer = CoTimer.New(action, time, 1)
	timer:Start()
	return yield()
end

function coroutine.www(www, co)	
	co = co or running()	
	local timer = nil	
	
	local action = function()		
		if not www.isDone then
			return
		end

		timer:Stop()
		local flag, msg = resume(co)
	
		if not flag then				
			msg = debug.traceback(co, msg)				
			Debugger.LogError("coroutine error:{0}", msg)		
			return	
		end		
	end
			
	timer = FrameTimer.New(action, 1, -1)
	timer:Start()
	return yield()
end

function coroutine.step(count, co, ...)
	local args = {...}
	co = co or running()		
	
	local action = function()							
		local flag, msg = resume(co, unpack(args))
	
		if not flag then				
			msg = debug.traceback(co, msg)				
			Debugger.LogError("coroutine error:{0}", msg)		
			return	
		end		
	end
			
	local timer = FrameTimer.New(action, count or 1, 1)
	timer:Start()
	return yield()
end
