beforTime = os.clock()
require("_MoeLua.Config.battle.MoeSkillAdditionSetting")
print(string.format( "Load [MoeSkillAdditionSetting] %f s count %d", os.clock() - beforTime, ConfigMgr:GetDataCount(ConfigType.SkillAdditionSetting)))

beforTime = os.clock()
require("_MoeLua.Config.battle.MoeUnitSetting")
print(string.format( "Load [MoeUnitSetting] %f s count %d", os.clock() - beforTime, ConfigMgr:GetDataCount(ConfigType.UnitSetting)))

beforTime = os.clock()
require("_MoeLua.Config.land.MoeLandViewSetting")
print(string.format( "Load [MoeLandViewSetting] %f s count %d", os.clock() - beforTime, ConfigMgr:GetDataCount(ConfigType.LandViewSetting)))

beforTime = os.clock()
require("_MoeLua.Config.collect.MoeResourceSetting")
print(string.format( "Load [MoeResourceSetting] %f s count %d", os.clock() - beforTime, ConfigMgr:GetDataCount(ConfigType.ResourceSetting)))

beforTime = os.clock()
require("_MoeLua.Config.transport.MoeTransportSetting")
print(string.format( "Load [MoeTransportSetting] %f s count %d", os.clock() - beforTime, ConfigMgr:GetDataCount(ConfigType.TransportSetting)))

beforTime = os.clock()
require("_MoeLua.Config.army.MoeArmySetting")
print(string.format( "Load [MoeArmySetting] %f s count %d", os.clock() - beforTime, ConfigMgr:GetDataCount(ConfigType.ArmySetting)))

beforTime = os.clock()
require("_MoeLua.Config.hunting.MoeHuntingRewardSetting")
print(string.format( "Load [MoeHuntingRewardSetting] %f s count %d", os.clock() - beforTime, ConfigMgr:GetDataCount(ConfigType.HuntingRewardSetting)))

beforTime = os.clock()
require("_MoeLua.Config.hunting.MoeMonsterSetting")
print(string.format( "Load [MoeMonsterSetting] %f s count %d", os.clock() - beforTime, ConfigMgr:GetDataCount(ConfigType.MonsterSetting)))

beforTime = os.clock()
require("_MoeLua.Config.common.MoeLanguageSetting")
print(string.format( "Load [MoeLanguageSetting] %f s count %d", os.clock() - beforTime, ConfigMgr:GetDataCount(ConfigType.LanguageSetting)))

beforTime = os.clock()
require("_MoeLua.Config.common.MoeConfigValue")
print(string.format( "Load [MoeConfigValue] %f s count %d", os.clock() - beforTime, ConfigMgr:GetDataCount(ConfigType.ConfigValue)))

beforTime = os.clock()
require("_MoeLua.Config.item.MoeItemSetting")
print(string.format( "Load [MoeItemSetting] %f s count %d", os.clock() - beforTime, ConfigMgr:GetDataCount(ConfigType.ItemSetting)))

beforTime = os.clock()
require("_MoeLua.Config.email.MoeTemplateSetting")
print(string.format( "Load [MoeTemplateSetting] %f s count %d", os.clock() - beforTime, ConfigMgr:GetDataCount(ConfigType.TemplateSetting)))

beforTime = os.clock()
require("_MoeLua.Config.hole.MoeHoleSetting")
print(string.format( "Load [MoeHoleSetting] %f s count %d", os.clock() - beforTime, ConfigMgr:GetDataCount(ConfigType.HoleSetting)))

print("Load Finish! [13]")
