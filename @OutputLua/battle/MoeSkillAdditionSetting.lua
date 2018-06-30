
MoeSkillAdditionSetting = {}

MoeSkillAdditionSetting.configs = {
	
	[1] = {
		skillId = 1,
	},

	[2] = {
		skillId = 2,
	},

	[4] = {
		skillId = 4,
	},

	[5] = {
		skillId = 5,
	},

	[6] = {
		skillId = 6,
	},

	[7] = {
		skillId = 7,
	},

	[8] = {
		skillId = 8,
	},

	[9] = {
		skillId = 9,
	},

	[10] = {
		skillId = 10,
	},

	[12] = {
		skillId = 12,
	},



}

MoeSkillAdditionSetting.dataCount = 10


function MoeSkillAdditionSetting:LoadFile()

end


-- 查找单个key
function MoeSkillAdditionSetting:Find (key)
    return MoeSkillAdditionSetting.configs[key]
end


--获取子表数量
function MoeSkillAdditionSetting:GetTablePageCount()
    return 0
end


--获取表数据数量
function MoeSkillAdditionSetting:GetDataCount()
    return MoeSkillAdditionSetting.dataCount
end

return MoeSkillAdditionSetting