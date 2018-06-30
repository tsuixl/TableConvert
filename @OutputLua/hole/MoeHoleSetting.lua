
MoeHoleSetting = {}

MoeHoleSetting.configs = {
	
	[101001] = {
		id = 101001,
		holeType = 101,
		lv = 1,
	},

	[101002] = {
		id = 101002,
		holeType = 101,
		lv = 2,
	},

	[101003] = {
		id = 101003,
		holeType = 101,
		lv = 3,
	},

	[101004] = {
		id = 101004,
		holeType = 101,
		lv = 4,
	},

	[101005] = {
		id = 101005,
		holeType = 101,
		lv = 5,
	},

	[102001] = {
		id = 102001,
		holeType = 102,
		lv = 1,
	},

	[102002] = {
		id = 102002,
		holeType = 102,
		lv = 2,
	},

	[102003] = {
		id = 102003,
		holeType = 102,
		lv = 3,
	},

	[102004] = {
		id = 102004,
		holeType = 102,
		lv = 4,
	},

	[102005] = {
		id = 102005,
		holeType = 102,
		lv = 5,
	},

	[103001] = {
		id = 103001,
		holeType = 103,
		lv = 1,
	},

	[103002] = {
		id = 103002,
		holeType = 103,
		lv = 2,
	},

	[103003] = {
		id = 103003,
		holeType = 103,
		lv = 3,
	},

	[103004] = {
		id = 103004,
		holeType = 103,
		lv = 4,
	},

	[103005] = {
		id = 103005,
		holeType = 103,
		lv = 5,
	},

	[104001] = {
		id = 104001,
		holeType = 104,
		lv = 1,
	},

	[104002] = {
		id = 104002,
		holeType = 104,
		lv = 2,
	},

	[104003] = {
		id = 104003,
		holeType = 104,
		lv = 3,
	},

	[104004] = {
		id = 104004,
		holeType = 104,
		lv = 4,
	},

	[104005] = {
		id = 104005,
		holeType = 104,
		lv = 5,
	},

	[105001] = {
		id = 105001,
		holeType = 105,
		lv = 1,
	},

	[105002] = {
		id = 105002,
		holeType = 105,
		lv = 2,
	},

	[105003] = {
		id = 105003,
		holeType = 105,
		lv = 3,
	},

	[105004] = {
		id = 105004,
		holeType = 105,
		lv = 4,
	},

	[105005] = {
		id = 105005,
		holeType = 105,
		lv = 5,
	},



}

MoeHoleSetting.dataCount = 25


function MoeHoleSetting:LoadFile()

end


-- 查找单个key
function MoeHoleSetting:Find (key)
    return MoeHoleSetting.configs[key]
end


--获取子表数量
function MoeHoleSetting:GetTablePageCount()
    return 0
end


--获取表数据数量
function MoeHoleSetting:GetDataCount()
    return MoeHoleSetting.dataCount
end

return MoeHoleSetting