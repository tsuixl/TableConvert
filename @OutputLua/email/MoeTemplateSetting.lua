
MoeTemplateSetting = {}

MoeTemplateSetting.configs = {
	
	[-1] = {
		id = -1,
		mailType = "USER_SELF",
		type = "user",
		title = "",
		message = "",
	},

	[1] = {
		id = 1,
		mailType = "RESOURCE",
		type = "report",
		title = "lv.{KEY_NUM[LEVEL]}矿山资源采集报告",
		message = "lv.{KEY_NUM[LEVEL]}矿山,坐标{POINTS[0]},获得{REWARDS}",
	},

	[2] = {
		id = 2,
		mailType = "SYSTEM_MESSAGE",
		type = "system",
		title = "系统通知",
		message = "恭喜你任务获得奖励{REWARDS}",
	},

	[3] = {
		id = 3,
		mailType = "FIGHT",
		type = "report",
		title = "攻打{PLAYERS[0]}领地",
		message = "{POINTS[0]}之战，攻击{WIN},观看战斗{REPORT_URL}",
	},

	[4] = {
		id = 4,
		mailType = "FIGHT",
		type = "report",
		title = "{PLAYERS[0]}攻击了你的领地",
		message = "{POINTS[0]}之战，守城{WIN},观看战斗{REPORT_URL}",
	},



}

MoeTemplateSetting.dataCount = 5


function MoeTemplateSetting:LoadFile()

end


-- 查找单个key
function MoeTemplateSetting:Find (key)
    return MoeTemplateSetting.configs[key]
end


--获取子表数量
function MoeTemplateSetting:GetTablePageCount()
    return 0
end


--获取表数据数量
function MoeTemplateSetting:GetDataCount()
    return MoeTemplateSetting.dataCount
end

return MoeTemplateSetting