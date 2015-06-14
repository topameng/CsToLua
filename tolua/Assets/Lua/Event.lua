--------------------------------------------------------------------------------
--      Copyright (c) 2010 , 蒙占志(topameng) topameng@gmail.com
--      All rights reserved.
--
--      Use, modification and distribution are subject to the "New BSD License"
--      as listed at <url: http://www.opensource.org/licenses/bsd-license.php >.
--------------------------------------------------------------------------------

function slot(func, obj)
	local slot	= {}
	slot.func	= func
	slot.obj	= obj
	slot.class	= "functor"
	setmetatable(slot, slot)	
	
	slot.__call	= function(self, ...)
		local flag 	= true	
		local msg = nil	

		if nil == self.obj then
			self.func(...)						
		else		
			self.func(self.obj, ...)
		end
	end
	
	return slot
end


function functor(func, obj)
	local slot	= {}
	slot.func	= func
	slot.obj	= obj
	slot.class	= "functor"
	setmetatable(slot, slot)	
	
	slot.__call	= function(self, ...)
		local flag 	= true	
		local msg = nil	

		if nil == self.obj then
			flag, msg = xpcall(self.func, traceback, ...)						
		else		
			flag, msg = xpcall(self.func, traceback, self.obj, ...)		
		end

		--luac 请使用这段替换上面的，因为xpcall luajit 不同于 luac
		--[[local args = {...}
		
		if nil == self.obj then
			local func = function() self.func(unpack(args)) end
			flag, msg = xpcall(func, traceback)						
		else		
			local func = function() self.func(self.obj, unpack(args)) end
			flag, msg = xpcall(func, traceback)		
		end]]--for luac
	
		
		--[[if not flag then						
			Debugger.LogError(msg)
		end	--]]
	
		return flag, msg
	end
	
	return slot
end


function Event(name, safe)
	local ev = {}

	ev.name 	= name	
	ev.rmList	= List:New()
	ev.lock		= false
	ev.list		= List:New()
	ev.keepSafe	= safe
	setmetatable(ev, ev)	
	
	ev.Add = function(self, func, obj)
		 if nil == func then
			error("Add a nil function to event ".. self.name or "")
			return
		end
				
		local slot = functor(func, obj)
		self.list:PushBack(slot)						
	end

	ev.Remove = function(self, func, obj)
		if nil == func then
			return
		end
	
		if self.lock then
			self.rmList:PushBack(functor(func, obj))
		else
			for slot, iter in rilist(self.list) do
				if slot.func == func and slot.obj == obj then
					self.list:Erase(iter)
					return
				end 
			end
		end
	end
	
	ev.Count = function(self)
		return self.list:Size()
	end	
	
	ev.__call = function(self, ...)
		local lock = self.lock
		self.lock = true

		for i in ilist(self.rmList) do
			for slot, iter in ilist(self.list) do
				if slot == i or (slot.func == i.func and slot.obj == i.obj) then
					self.list:Erase(iter)
					break
				end 
			end
		end

		self.rmList:Clear()

		for slot in ilist(self.list) do					
			local flag,msg = slot(...)
			if not flag and self.keepSafe then
				self.rmList:PushBack(slot)					
				self.lock = lock		
				error(msg)
			end
		end

		self.lock = lock			
	end
	
	return ev
end