
MoeArmySetting = {}

MoeArmySetting.configs = {
	
	[1] = {
		armyId = 1,
		costs = {
			[1] = {
				type = "CURRENCY",
				code = 1,
				amount = 100
			}
		},
		weight = 5,
		speed = 0.4,
		languageId = 110001,
	},

	[2] = {
		armyId = 2,
		costs = {
			[1] = {
				type = "CURRENCY",
				code = 1,
				amount = 100
			}
		},
		weight = 6,
		speed = 0.4,
		languageId = 110005,
	},

	[3] = {
		armyId = 3,
		costs = {
			[1] = {
				type = "CURRENCY",
				code = 1,
				amount = 100
			}
		},
		weight = 7,
		speed = 0.4,
		languageId = 110009,
	},

	[4] = {
		armyId = 4,
		costs = {
			[1] = {
				type = "CURRENCY",
				code = 1,
				amount = 100
			}
		},
		weight = 8,
		speed = 0.4,
		languageId = 110013,
	},

	[5] = {
		armyId = 5,
		costs = {
			[1] = {
				type = "CURRENCY",
				code = 1,
				amount = 100
			}
		},
		weight = 9,
		speed = 0.4,
		languageId = 110003,
	},



}

MoeArmySetting.dataCount = 5


function MoeArmySetting:LoadFile()

end


-- 查找单个key
function MoeArmySetting:Find (key)
    return MoeArmySetting.configs[key]
end


--获取子表数量
function MoeArmySetting:GetTablePageCount()
    return 0
end


--获取表数据数量
function MoeArmySetting:GetDataCount()
    return MoeArmySetting.dataCount
end

return MoeArmySetting