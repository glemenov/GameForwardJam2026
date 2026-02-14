using UnityEngine;

namespace Upgrades
{
    public class ComboMultiplierUpgrade : Upgrade
    {
        public override void InitiateUpgrade()
        {
            if (base.TryBuyUpgrade())
            {
                HeadManager.Instance.playerDataManager.UpgradeComboMultiplier(upgradeLevels[currentLevel].value);
            }
        }
        
        public override string DisplayInfo()
        {
            return $"{upgradeLevels[currentLevel].value} {displayName}";
        }
    }
}