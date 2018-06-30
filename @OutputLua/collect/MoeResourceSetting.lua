
MoeResourceSetting = {}

MoeResourceSetting.configs = {
	
	[101001] = {
		id = 101001,
		resType = 101,
		lv = 1,
		amount = 1000,
		speed = 10,
		currencyType = "MONEY",
		landViewId = 30005,
	},

	[101002] = {
		id = 101002,
		resType = 101,
		lv = 2,
		amount = 2000,
		speed = 15,
		currencyType = "MONEY",
		landViewId = 30005,
	},

	[101003] = {
		id = 101003,
		resType = 101,
		lv = 3,
		amount = 3000,
		speed = 20,
		currencyType = "MONEY",
		landViewId = 30005,
	},

	[101004] = {
		id = 101004,
		resType = 101,
		lv = 4,
		amount = 4000,
		speed = 25,
		currencyType = "MONEY",
		landViewId = 30005,
	},

	[101005] = {
		id = 101005,
		resType = 101,
		lv = 5,
		amount = 5000,
		speed = 30,
		currencyType = "MONEY",
		landViewId = 30005,
	},

	[102001] = {
		id = 102001,
		resType = 102,
		lv = 1,
		amount = 1000,
		speed = 10,
		currencyType = "DIAMOND",
		landViewId = 30003,
	},

	[102002] = {
		id = 102002,
		resType = 102,
		lv = 2,
		amount = 2000,
		speed = 15,
		currencyType = "DIAMOND",
		landViewId = 30003,
	},

	[102003] = {
		id = 102003,
		resType = 102,
		lv = 3,
		amount = 3000,
		speed = 20,
		currencyType = "DIAMOND",
		landViewId = 30003,
	},

	[102004] = {
		id = 102004,
		resType = 102,
		lv = 4,
		amount = 4000,
		speed = 25,
		currencyType = "DIAMOND",
		landViewId = 30003,
	},

	[102005] = {
		id = 102005,
		resType = 102,
		lv = 5,
		amount = 5000,
		speed = 30,
		currencyType = "DIAMOND",
		landViewId = 30003,
	},

	[103001] = {
		id = 103001,
		resType = 103,
		lv = 1,
		amount = 1000,
		speed = 10,
		currencyType = "FOOD",
		landViewId = 30001,
	},

	[103002] = {
		id = 103002,
		resType = 103,
		lv = 2,
		amount = 2000,
		speed = 15,
		currencyType = "FOOD",
		landViewId = 30001,
	},

	[103003] = {
		id = 103003,
		resType = 103,
		lv = 3,
		amount = 3000,
		speed = 20,
		currencyType = "FOOD",
		landViewId = 30001,
	},

	[103004] = {
		id = 103004,
		resType = 103,
		lv = 4,
		amount = 4000,
		speed = 25,
		currencyType = "FOOD",
		landViewId = 30001,
	},

	[103005] = {
		id = 103005,
		resType = 103,
		lv = 5,
		amount = 5000,
		speed = 30,
		currencyType = "FOOD",
		landViewId = 30001,
	},

	[104001] = {
		id = 104001,
		resType = 104,
		lv = 1,
		amount = 1000,
		speed = 10,
		currencyType = "STONE",
		landViewId = 30002,
	},

	[104002] = {
		id = 104002,
		resType = 104,
		lv = 2,
		amount = 2000,
		speed = 15,
		currencyType = "STONE",
		landViewId = 30002,
	},

	[104003] = {
		id = 104003,
		resType = 104,
		lv = 3,
		amount = 3000,
		speed = 20,
		currencyType = "STONE",
		landViewId = 30002,
	},

	[104004] = {
		id = 104004,
		resType = 104,
		lv = 4,
		amount = 4000,
		speed = 25,
		currencyType = "STONE",
		landViewId = 30002,
	},

	[104005] = {
		id = 104005,
		resType = 104,
		lv = 5,
		amount = 5000,
		speed = 30,
		currencyType = "STONE",
		landViewId = 30002,
	},

	[105001] = {
		id = 105001,
		resType = 105,
		lv = 1,
		amount = 1000,
		speed = 10,
		currencyType = "IRON",
		landViewId = 30004,
	},

	[105002] = {
		id = 105002,
		resType = 105,
		lv = 2,
		amount = 2000,
		speed = 15,
		currencyType = "IRON",
		landViewId = 30004,
	},

	[105003] = {
		id = 105003,
		resType = 105,
		lv = 3,
		amount = 3000,
		speed = 20,
		currencyType = "IRON",
		landViewId = 30004,
	},

	[105004] = {
		id = 105004,
		resType = 105,
		lv = 4,
		amount = 4000,
		speed = 25,
		currencyType = "IRON",
		landViewId = 30004,
	},

	[105005] = {
		id = 105005,
		resType = 105,
		lv = 5,
		amount = 5000,
		speed = 30,
		currencyType = "IRON",
		landViewId = 30004,
	},



}

MoeResourceSetting.dataCount = 25


function MoeResourceSetting:LoadFile()

end


-- 查找单个key
function MoeResourceSetting:Find (key)
    return MoeResourceSetting.configs[key]
end


--获取子表数量
function MoeResourceSetting:GetTablePageCount()
    return 0
end


--获取表数据数量
function MoeResourceSetting:GetDataCount()
    return MoeResourceSetting.dataCount
end

return MoeResourceSetting