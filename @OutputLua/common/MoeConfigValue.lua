
MoeConfigValue = {}

MoeConfigValue.configs = {
	
	["LAND:EXCLUDE_SECTIONS"] = {
		id = "LAND:EXCLUDE_SECTIONS",
		content = {},
	},

	["LAND:EXCLUDE_POINTS"] = {
		id = "LAND:EXCLUDE_POINTS",
		content = {},
	},

	["LAND:MARCH_DISTANCE_LIMIT"] = {
		id = "LAND:MARCH_DISTANCE_LIMIT",
		content = {},
	},

	["LAND:MARCH_TYPE"] = {
		id = "LAND:MARCH_TYPE",
		content = {
			COLLECT = {
				landViewId = 10001
			},
			ATTACK = {
				landViewId = 10001
			},
			OCCUPY = {
				landViewId = 10001
			},
			RESOURCES = {
				landViewId = 10001
			},
			HUNTING = {
				landViewId = 10001
			},
			TRANSPPORT = {
				landViewId = 10001
			},
			ASSAULT_CITY = {
				landViewId = 10001
			},
			ASSAULT_STRONGHOLD = {
				landViewId = 10001
			},
			ASSAULT_HOLE = {
				landViewId = 10001
			}
		},
	},

	["LAND:FIGHT_BACK_DELAY"] = {
		id = "LAND:FIGHT_BACK_DELAY",
		content = 5,
	},

	["LAND:MARCH_LINE_SPEED_SCALE"] = {
		id = "LAND:MARCH_LINE_SPEED_SCALE",
		content = 0.04,
	},

	["LAND:MARCH_LINE_SPEED_MAX"] = {
		id = "LAND:MARCH_LINE_SPEED_MAX",
		content = 25,
	},



}

MoeConfigValue.dataCount = 7


function MoeConfigValue:LoadFile()

end


-- 查找单个key
function MoeConfigValue:Find (key)
    return MoeConfigValue.configs[key]
end


--获取子表数量
function MoeConfigValue:GetTablePageCount()
    return 0
end


--获取表数据数量
function MoeConfigValue:GetDataCount()
    return MoeConfigValue.dataCount
end

return MoeConfigValue