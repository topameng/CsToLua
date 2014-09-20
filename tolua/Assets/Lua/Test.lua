
function Test(transform)
	local v = Vector3.one

	for i=1,10000 do
		transform.position = v
	end
end
