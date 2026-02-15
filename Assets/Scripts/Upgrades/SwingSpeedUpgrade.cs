using UnityEngine;
using Upgrades;

namespace Upgrades
{
    public class SwingSpeedUpgrade : Upgrade
    {
        public override void InitiateUpgrade()
        {
            if (base.TryBuyUpgrade())
            {
                HeadManager.Instance.claw.swingSpeed += upgradeLevels[currentLevel].value;
            }
        }
        
        public override string DisplayInfo()
        {
            return $"+{upgradeLevels[currentLevel].value} {displayName}";
        }
    }
}