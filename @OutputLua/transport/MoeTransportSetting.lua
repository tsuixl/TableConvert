
MoeTransportSetting = {}

MoeTransportSetting.configs = {
	
	[1] = {
		marketLv = 1,
		transportCountLimit = 3000,
		taxRate = 30,
		speed = 30,
	},

	[2] = {
		marketLv = 2,
		transportCountLimit = 3001,
		taxRate = 31,
		speed = 31,
	},

	[3] = {
		marketLv = 3,
		transportCountLimit = 3002,
		taxRate = 32,
		speed = 32,
	},

	[4] = {
		marketLv = 4,
		transportCountLimit = 3003,
		taxRate = 33,
		speed = 33,
	},

	[5] = {
		marketLv = 5,
		transportCountLimit = 3004,
		taxRate = 34,
		speed = 34,
	},

	[6] = {
		marketLv = 6,
		transportCountLimit = 3005,
		taxRate = 35,
		speed = 35,
	},

	[7] = {
		marketLv = 7,
		transportCountLimit = 3006,
		taxRate = 36,
		speed = 36,
	},

	[8] = {
		marketLv = 8,
		transportCountLimit = 3007,
		taxRate = 37,
		speed = 37,
	},

	[9] = {
		marketLv = 9,
		transportCountLimit = 3008,
		taxRate = 38,
		speed = 38,
	},

	[10] = {
		marketLv = 10,
		transportCountLimit = 3009,
		taxRate = 39,
		speed = 39,
	},

	[11] = {
		marketLv = 11,
		transportCountLimit = 3010,
		taxRate = 40,
		speed = 40,
	},

	[12] = {
		marketLv = 12,
		transportCountLimit = 3011,
		taxRate = 41,
		speed = 41,
	},

	[13] = {
		marketLv = 13,
		transportCountLimit = 3012,
		taxRate = 42,
		speed = 42,
	},

	[14] = {
		marketLv = 14,
		transportCountLimit = 3013,
		taxRate = 43,
		speed = 43,
	},

	[15] = {
		marketLv = 15,
		transportCountLimit = 3014,
		taxRate = 44,
		speed = 44,
	},



}

MoeTransportSetting.dataCount = 15


function MoeTransportSetting:LoadFile()

end


-- 查找单个key
function MoeTransportSetting:Find (key)
    return MoeTransportSetting.configs[key]
end


--获取子表数量
function MoeTransportSetting:GetTablePageCount()
    return 0
end


--获取表数据数量
function MoeTransportSetting:GetDataCount()
    return MoeTransportSetting.dataCount
end

return MoeTransportSetting