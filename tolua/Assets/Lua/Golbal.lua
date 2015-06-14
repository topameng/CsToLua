luanet.load_assembly("UnityEngine")

object			= System.Object
Type			= System.Type
Object          = UnityEngine.Object
GameObject 		= UnityEngine.GameObject
Transform 		= UnityEngine.Transform
MonoBehaviour 	= UnityEngine.MonoBehaviour
Component		= UnityEngine.Component
Application		= UnityEngine.Application
SystemInfo		= UnityEngine.SystemInfo
Screen			= UnityEngine.Screen
Camera			= UnityEngine.Camera
Material 		= UnityEngine.Material
Renderer 		= UnityEngine.Renderer
AsyncOperation	= UnityEngine.AsyncOperation

CharacterController = UnityEngine.CharacterController
SkinnedMeshRenderer = UnityEngine.SkinnedMeshRenderer
Animation		= UnityEngine.Animation
AnimationClip	= UnityEngine.AnimationClip
AnimationEvent	= UnityEngine.AnimationEvent
AnimationState	= UnityEngine.AnimationState
Input			= UnityEngine.Input
KeyCode			= UnityEngine.KeyCode
AudioClip		= UnityEngine.AudioClip
AudioSource		= UnityEngine.AudioSource
Physics			= UnityEngine.Physics
Light			= UnityEngine.Light
LightType		= UnityEngine.LightType
ParticleEmitter	= UnityEngine.ParticleEmitter
Space			= UnityEngine.Space
CameraClearFlags= UnityEngine.CameraClearFlags
RenderSettings  = UnityEngine.RenderSettings
MeshRenderer	= UnityEngine.MeshRenderer
WrapMode		= UnityEngine.WrapMode
QueueMode		= UnityEngine.QueueMode
PlayMode		= UnityEngine.PlayMode
ParticleAnimator= UnityEngine.ParticleAnimator
TouchPhase 		= UnityEngine.TouchPhase
AnimationBlendMode = UnityEngine.AnimationBlendMode

function print(...)	
	local arg = {...}	
	local t = {}	
	
	for i,k in ipairs(arg) do
		table.insert(t, tostring(k))
	end
	
	local str = table.concat(t)	
	Debugger.Log(str)
end

function printf(format, ...)
	Debugger.Log(string.format(format, ...))
end


--require "strict"  -- luajit2.0.4 编码后有问题
--require "memory"
require "class"
require "Math"
require "Layer"
require "List"
require "Time"
require "Event"
--require	"sqlite"
require "Timer"

require "Vector3"
require "Vector2"
require "Quaternion"
require "Vector4"
require "Raycast"
require "Color"
require "Touch"
require "Ray"
require "Plane"
require "Bounds"

require "Coroutine"


function traceback(msg)
	msg = debug.traceback(msg, 2)
	return msg
end

function LuaGC()
  local c = collectgarbage("count")
  Debugger.Log("Begin gc count = {0} kb", c)
  collectgarbage("collect")
  c = collectgarbage("count")
  Debugger.Log("End gc count = {0} kb", c)
end

--[[function ShowUI(name, OnLoad)
	UIBase.LoadUI(name, OnLoad)
end--]]

function RemoveTableItem(list, item, removeAll)
    local rmCount = 0

    for i = 1, #list do
        if list[i - rmCount] == item then
            table.remove(list, i - rmCount)

            if removeAll then
                rmCount = rmCount + 1
            else
                break
            end
        end
    end
end

--unity 对象判断为空, 如果你有些对象是在c#删掉了，lua 不知道
--判断这种对象为空时可以用下面这个函数。
function IsNil(uobj)
	return uobj == nil or uobj:Equals(nil)
end

-- isnan
function isnan(number)
	return not (number == number)
end

--[[function FindNode(transform, name)
	if transform == nil then
		error("invalide arguments to FindNode transform is nil")
		return nil
	elseif name == nil then
		error("invalide arguments to FindNode name is nil")
		return nil
	end
	
	local node = UnGfx.FindNode(transform, name)
	
	if node == nil then
		error(string.format("transform %s does not have child %s", transform.name, name))
	end
	
	return node
end--]]


function string:split(sep)
	local sep, fields = sep or ",", {}
	local pattern = string.format("([^%s]+)", sep)
	self:gsub(pattern, function(c) table.insert(fields, c) end)
	return fields
end

function GetDir(path)
	return string.match(fullpath, ".*/")
end

function GetFileName(path)
	return string.match(fullpath, ".*/(.*)")
end

-- Courtesy of lua-users.org
--[[function string:split(pat)
   local t = {}
   local fpat = "(.-)" .. pat
   local last_end = 1
   local s, e, cap = string.find(str, fpat, 1)

   while s do
      if s ~= 1 or cap ~= "" then
          table.insert(t,cap)
       end
      last_end = e+1
      s, e, cap = string.find(str, fpat, last_end)
   end

   if last_end <= string.len(str) then
      cap = string.sub(str, last_end)
      table.insert(t, cap)
   end

   return t
end]]

function table.contains(table, element)
  if table == nil then
        return false
  end

  for _, value in pairs(table) do
    if value == element then
      return true
    end
  end
  return false
end

function table.getCount(self)
	local count = 0
	
	for k, v in pairs(self) do
		count = count + 1	
	end
	
	return count
end

function DumpTable(t)
	for k,v in pairs(t) do
		if v ~= nil then
			Debugger.Log("Key: {0}, Value: {1}", tostring(k), tostring(v))
		else
			Debugger.Log("Key: {0}, Value nil", tostring(k))
		end
	end
end

 function PrintTable(tab)
    local str = {}

    local function internal(tab, str, indent)
        for k,v in pairs(tab) do
            if type(v) == "table" then
                table.insert(str, indent..tostring(k)..":\n")
                internal(v, str, indent..' ')
            else
                table.insert(str, indent..tostring(k)..": "..tostring(v).."\n")
            end
        end
    end

    internal(tab, str, '')
    return table.concat(str, '')
end

function PrintLua(name, lib)
	local m
	lib = lib or _G

	for w in string.gmatch(name, "%w+") do
       lib = lib[w]
     end

	 m = lib

	if (m == nil) then
		Debugger.Log("Lua Module {0} not exists", name)
		return
	end

	Debugger.Log("-----------------Dump Table {0}-----------------",name)
	if (type(m) == "table") then
		for k,v in pairs(m) do
			Debugger.Log("Key: {0}, Value: {1}", k, tostring(v))
		end
	end

	local meta = getmetatable(m)
	Debugger.Log("-----------------Dump meta {0}-----------------",name)

	while meta ~= nil and meta ~= m do
		for k,v in pairs(meta) do
			if k ~= nil then
			Debugger.Log("Key: {0}, Value: {1}", tostring(k), tostring(v))
			end

		end

		meta = getmetatable(meta)
	end

	Debugger.Log("-----------------Dump meta Over-----------------")
	Debugger.Log("-----------------Dump Table Over-----------------")
end