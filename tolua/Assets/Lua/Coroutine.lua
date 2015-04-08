--------------------------------------------------------------------------------
--      Copyright (c) 2015 , 蒙占志(topameng) topameng@gmail.com
--      All rights reserved.
--
--      Use, modification and distribution are subject to the "New BSD License"
--      as listed at <url: http://www.opensource.org/licenses/bsd-license.php >.
--------------------------------------------------------------------------------
-- 扩展lua协同为c#协同形式, 注意当协同挂起时，不能回调协同堆栈上的局部函数
-- 例如加载资源异步回调

function coroutine.start(f, ...)		
	local co = coroutine.create(f)
	
	if coroutine.running() == nil then
		local flag, msg = coroutine.resume(co, ...)
	
		if not flag then		
			error(msg)
		end		
	else
		local args = {...}
		
		local action = function()							
			local flag, msg = coroutine.resume(co, unpack(args))
	
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

