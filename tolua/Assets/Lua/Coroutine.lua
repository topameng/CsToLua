-- 扩展lua协同为c#协同形式

function coroutine.start(f, ...)		
	local co = coroutine.create(f)
	local flag, msg = coroutine.resume(co, ...)
	
	if not flag then
		error(msg)
	end
	
	return co
end

function coroutine.wait(t, ...)
	local args = {...}
	local co = coroutine.running()
	
	local action = function()		
		local flag, msg = coroutine.resume(co, unpack(args))
		
		if not flag then
			error(msg)			
		end
	end
	
	local timer = CoTimer.New(action, t, 1)
	timer:Start()
	coroutine.yield()
end

function coroutine.step(t, ...)
	local args = {...}
	local co = coroutine.running()		
	
	local action = function()							
		local flag, msg = coroutine.resume(co, unpack(args))
	
		if not flag then
			error(msg)		
		end		
	end
			
	local timer = FrameTimer.New(action, t or 1, 1)
	timer:Start()
	coroutine.yield()
end

