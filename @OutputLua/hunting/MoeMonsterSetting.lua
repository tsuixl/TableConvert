
MoeMonsterSetting = {}

MoeMonsterSetting.configs = {
	
	[101001] = {
		id = 101001,
		monsterType = 101,
		lv = 1,
		hp = 1000000,
		landViewId = 20001,
	},

	[101002] = {
		id = 101002,
		monsterType = 101,
		lv = 2,
		hp = 2000000,
		landViewId = 20001,
	},

	[101003] = {
		id = 101003,
		monsterType = 101,
		lv = 3,
		hp = 3000000,
		landViewId = 20001,
	},

	[101004] = {
		id = 101004,
		monsterType = 101,
		lv = 4,
		hp = 4000000,
		landViewId = 20001,
	},

	[101005] = {
		id = 101005,
		monsterType = 101,
		lv = 5,
		hp = 5000000,
		landViewId = 20001,
	},

	[102001] = {
		id = 102001,
		monsterType = 102,
		lv = 1,
		hp = 1000000,
		landViewId = 20002,
	},

	[102002] = {
		id = 102002,
		monsterType = 102,
		lv = 2,
		hp = 2000000,
		landViewId = 20002,
	},

	[102003] = {
		id = 102003,
		monsterType = 102,
		lv = 3,
		hp = 3000000,
		landViewId = 20002,
	},

	[102004] = {
		id = 102004,
		monsterType = 102,
		lv = 4,
		hp = 4000000,
		landViewId = 20002,
	},

	[102005] = {
		id = 102005,
		monsterType = 102,
		lv = 5,
		hp = 5000000,
		landViewId = 20002,
	},

	[103001] = {
		id = 103001,
		monsterType = 103,
		lv = 1,
		hp = 1000000,
		landViewId = 20003,
	},

	[103002] = {
		id = 103002,
		monsterType = 103,
		lv = 2,
		hp = 2000000,
		landViewId = 20003,
	},

	[103003] = {
		id = 103003,
		monsterType = 103,
		lv = 3,
		hp = 3000000,
		landViewId = 20003,
	},

	[103004] = {
		id = 103004,
		monsterType = 103,
		lv = 4,
		hp = 4000000,
		landViewId = 20003,
	},

	[103005] = {
		id = 103005,
		monsterType = 103,
		lv = 5,
		hp = 5000000,
		landViewId = 20003,
	},

	[104001] = {
		id = 104001,
		monsterType = 104,
		lv = 1,
		hp = 1000000,
		landViewId = 20004,
	},

	[104002] = {
		id = 104002,
		monsterType = 104,
		lv = 2,
		hp = 2000000,
		landViewId = 20004,
	},

	[104003] = {
		id = 104003,
		monsterType = 104,
		lv = 3,
		hp = 3000000,
		landViewId = 20004,
	},

	[104004] = {
		id = 104004,
		monsterType = 104,
		lv = 4,
		hp = 4000000,
		landViewId = 20004,
	},

	[104005] = {
		id = 104005,
		monsterType = 104,
		lv = 5,
		hp = 5000000,
		landViewId = 20004,
	},

	[105001] = {
		id = 105001,
		monsterType = 105,
		lv = 1,
		hp = 1000000,
		landViewId = 20005,
	},

	[105002] = {
		id = 105002,
		monsterType = 105,
		lv = 2,
		hp = 2000000,
		landViewId = 20005,
	},

	[105003] = {
		id = 105003,
		monsterType = 105,
		lv = 3,
		hp = 3000000,
		landViewId = 20005,
	},

	[105004] = {
		id = 105004,
		monsterType = 105,
		lv = 4,
		hp = 4000000,
		landViewId = 20005,
	},

	[105005] = {
		id = 105005,
		monsterType = 105,
		lv = 5,
		hp = 5000000,
		landViewId = 20005,
	},



}

MoeMonsterSetting.dataCount = 25


function MoeMonsterSetting:LoadFile()

end


-- 查找单个key
function MoeMonsterSetting:Find (key)
    return MoeMonsterSetting.configs[key]
end


--获取子表数量
function MoeMonsterSetting:GetTablePageCount()
    return 0
end


--获取表数据数量
function MoeMonsterSetting:GetDataCount()
    return MoeMonsterSetting.dataCount
end

return MoeMonsterSetting