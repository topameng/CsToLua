
--module("LuaClient", package.seaall)

local updateList = {}

function Update()
	for k,v in pairs(updateList) do
		k()
	end
end

function LateUpdate()
end

function AddUpdater(f)
	if (updateList[f] == nil) then
		updateList[f] = #updateList + 1
	end
end


function RemoveUpdater(f)
	updateList[f] = nil
end

print(os.clock())
