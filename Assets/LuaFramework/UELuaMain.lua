--[[
C#调用Lua的主入口
--]]

local _M = LuaMain or {}
LuaMain = _M

function GetLuaMain()
	return _M;
end

function _M.HotUpdate(filename)
	if package.loaded[filename] then
		package.loaded[filename] = nil;
		require(filename);
	else
		print(" lua file never loaded: ", filename);
	end
end