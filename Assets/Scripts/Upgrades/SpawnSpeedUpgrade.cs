using System;
using System.Collections.Generic;
using DefaultNamespace;
using TriInspector;
using UnityEngine;

namespace Upgrades
{
    public class SpawnSpeedUpgrade : Upgrade
    {
        [TableList] public List<SpeedUpgrade> speedLevels = new List<SpeedUpgrade>();
        public Stat statToApply;

        public override void BuyUpgrade()
        {
            if (HeadManager.Instance.playerDataManager.TryDeductMoney(speedLevels[currentLevel].price))
            {
                currentLevel++;

                if (currentLevel >= speedLevels.Count)
                {
                    maxLevelReached = true;
                    return;
                }

                statToApply.percentageModifiers.Add(speedLevels[currentLevel].speed);
            }
        }

        [Serializable]
        public class SpeedUpgrade
        {
            public int speed;
            public int price;
        }

        public override string DisplayInfo()
        {
            return $"{speedLevels[currentLevel].speed}% {displayName}";
        }

        public override string PriceInfo()
        {
            return $"{speedLevels[currentLevel].price} AED";
        }
    }

    [Serializable]
    public abstract class Upgrade : MonoBehaviour
    {
        public string displayName;
        public int currentLevel = 0;
        public bool maxLevelReached = false;

        public virtual string DisplayInfo()
        {
            return "";
        }
        
        public virtual string PriceInfo()
        {
            return "";
        }
        
        public virtual void BuyUpgrade() {}

        public bool IsMaxLevelReached()
        {
            return maxLevelReached;
        }
    }
}