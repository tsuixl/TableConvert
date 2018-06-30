
MoeLanguageSetting = {}

MoeLanguageSetting.configs = {
	
	[100001] = {
		id = 100001,
		content = "麦田",
	},

	[100002] = {
		id = 100002,
		content = "林地",
	},

	[100003] = {
		id = 100003,
		content = "遗迹",
	},

	[100004] = {
		id = 100004,
		content = "矿山",
	},

	[100005] = {
		id = 100005,
		content = "岩山",
	},

	[100006] = {
		id = 100006,
		content = "传送",
	},

	[100007] = {
		id = 100007,
		content = "占领",
	},

	[100008] = {
		id = 100008,
		content = "树林",
	},

	[100009] = {
		id = 100009,
		content = "猎杀",
	},

	[100010] = {
		id = 100010,
		content = "采集",
	},

	[100011] = {
		id = 100011,
		content = "撤回",
	},

	[100012] = {
		id = 100012,
		content = "王国",
	},

	[100013] = {
		id = 100013,
		content = "玩家档案",
	},

	[100014] = {
		id = 100014,
		content = "占领者",
	},

	[100015] = {
		id = 100015,
		content = "数量",
	},

	[100016] = {
		id = 100016,
		content = "侦查",
	},

	[100017] = {
		id = 100017,
		content = "攻击",
	},

	[100018] = {
		id = 100018,
		content = "负重量%d/%d",
	},

	[100019] = {
		id = 100019,
		content = "采集剩余时间%s",
	},

	[100020] = {
		id = 100020,
		content = "召回",
	},

	[100021] = {
		id = 100021,
		content = "加速",
	},

	[100022] = {
		id = 100022,
		content = "到达剩余时间:",
	},

	[100023] = {
		id = 100023,
		content = "目的地:",
	},

	[100024] = {
		id = 100024,
		content = "kmap_level_red_%d",
	},

	[100025] = {
		id = 100025,
		content = "kmap_level_%d",
	},

	[100026] = {
		id = 100026,
		content = "进入领地",
	},

	[100027] = {
		id = 100027,
		content = "诚保外观",
	},

	[100028] = {
		id = 100028,
		content = "驻扎",
	},

	[100029] = {
		id = 100029,
		content = "运输资源",
	},

	[100030] = {
		id = 100030,
		content = "增援",
	},

	[100031] = {
		id = 100031,
		content = "集结攻击",
	},

	[100032] = {
		id = 100032,
		content = "确认",
	},

	[110001] = {
		id = 110001,
		content = "战士",
	},

	[110002] = {
		id = 110002,
		content = "短弓手",
	},

	[110003] = {
		id = 110003,
		content = "枪骑兵",
	},

	[110004] = {
		id = 110004,
		content = "弩炮",
	},

	[110005] = {
		id = 110005,
		content = "角斗士",
	},

	[110006] = {
		id = 110006,
		content = "护卫射手",
	},

	[110007] = {
		id = 110007,
		content = "龙掠者",
	},

	[110008] = {
		id = 110008,
		content = "投石器",
	},

	[110009] = {
		id = 110009,
		content = "皇家护卫",
	},

	[110010] = {
		id = 110010,
		content = "暗夜游侠",
	},

	[110011] = {
		id = 110011,
		content = "铁血骑士",
	},

	[110012] = {
		id = 110012,
		content = "攻城弩炮",
	},

	[110013] = {
		id = 110013,
		content = "传奇勇士",
	},

	[110014] = {
		id = 110014,
		content = "传奇魔炮手",
	},

	[110015] = {
		id = 110015,
		content = "传奇龙骑士",
	},

	[110016] = {
		id = 110016,
		content = "破城者",
	},

	[120001] = {
		id = 120001,
		content = "金币",
	},

	[120002] = {
		id = 120002,
		content = "水晶",
	},

	[120003] = {
		id = 120003,
		content = "粮食",
	},

	[120004] = {
		id = 120004,
		content = "岩石",
	},

	[120005] = {
		id = 120005,
		content = "木材",
	},

	[120006] = {
		id = 120006,
		content = "钢铁",
	},



}

MoeLanguageSetting.dataCount = 54


function MoeLanguageSetting:LoadFile()

end


-- 查找单个key
function MoeLanguageSetting:Find (key)
    return MoeLanguageSetting.configs[key]
end


--获取子表数量
function MoeLanguageSetting:GetTablePageCount()
    return 0
end


--获取表数据数量
function MoeLanguageSetting:GetDataCount()
    return MoeLanguageSetting.dataCount
end

return MoeLanguageSetting