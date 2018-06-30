
MoeHuntingRewardSetting = {}

MoeHuntingRewardSetting.configs = {
	
	[101001] = {
		id = 101001,
	},

	[101002] = {
		id = 101002,
	},

	[101003] = {
		id = 101003,
	},

	[101004] = {
		id = 101004,
	},

	[101005] = {
		id = 101005,
	},

	[102001] = {
		id = 102001,
	},

	[102002] = {
		id = 102002,
	},

	[102003] = {
		id = 102003,
	},

	[102004] = {
		id = 102004,
	},

	[102005] = {
		id = 102005,
	},

	[103001] = {
		id = 103001,
	},

	[103002] = {
		id = 103002,
	},

	[103003] = {
		id = 103003,
	},

	[103004] = {
		id = 103004,
	},

	[103005] = {
		id = 103005,
	},

	[104001] = {
		id = 104001,
	},

	[104002] = {
		id = 104002,
	},

	[104003] = {
		id = 104003,
	},

	[104004] = {
		id = 104004,
	},

	[104005] = {
		id = 104005,
	},

	[105001] = {
		id = 105001,
	},

	[105002] = {
		id = 105002,
	},

	[105003] = {
		id = 105003,
	},

	[105004] = {
		id = 105004,
	},

	[105005] = {
		id = 105005,
	},



}

MoeHuntingRewardSetting.dataCount = 25


function MoeHuntingRewardSetting:LoadFile()

end


-- 查找单个key
function MoeHuntingRewardSetting:Find (key)
    return MoeHuntingRewardSetting.configs[key]
end


--获取子表数量
function MoeHuntingRewardSetting:GetTablePageCount()
    return 0
end


--获取表数据数量
function MoeHuntingRewardSetting:GetDataCount()
    return MoeHuntingRewardSetting.dataCount
end

return MoeHuntingRewardSetting