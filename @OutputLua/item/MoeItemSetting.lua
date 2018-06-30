
MoeItemSetting = {}

MoeItemSetting.configs = {
	
	[1] = {
		id = 1,
		name = "1W金币",
		itemType = 101,
		useCosts = "",
		useRewards = "BOX101001",
	},

	[2] = {
		id = 2,
		name = "1W钻石",
		itemType = 101,
		useCosts = "",
		useRewards = "BOX101002",
	},

	[3] = {
		id = 3,
		name = "1W粮食",
		itemType = 101,
		useCosts = "",
		useRewards = "BOX101003",
	},

	[4] = {
		id = 4,
		name = "1W石头",
		itemType = 101,
		useCosts = "",
		useRewards = "BOX101004",
	},

	[5] = {
		id = 5,
		name = "1W钢铁",
		itemType = 101,
		useCosts = "",
		useRewards = "BOX101005",
	},

	[6] = {
		id = 6,
		name = "1W木材",
		itemType = 101,
		useCosts = "",
		useRewards = "BOX101006",
	},

	[7] = {
		id = 7,
		name = "军队宝箱",
		itemType = 102,
		useCosts = "",
		useRewards = "BOX101007",
	},



}

MoeItemSetting.dataCount = 7


function MoeItemSetting:LoadFile()

end


-- 查找单个key
function MoeItemSetting:Find (key)
    return MoeItemSetting.configs[key]
end


--获取子表数量
function MoeItemSetting:GetTablePageCount()
    return 0
end


--获取表数据数量
function MoeItemSetting:GetDataCount()
    return MoeItemSetting.dataCount
end

return MoeItemSetting