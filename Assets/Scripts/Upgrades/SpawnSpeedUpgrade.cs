using System;
using System.Collections.Generic;
using DefaultNamespace;
using TriInspector;
using UnityEngine;

namespace Upgrades
{
    public class SpawnSpeedUpgrade : Upgrade
    {
        public string displayName;
        public int currentLevel = 0;
        [TableList] public List<SpeedUpgrade> speedLevels = new List<SpeedUpgrade>();
        public Stat statToApply;
        public bool maxLevelReached = false;

        public void BuyUpgrade()
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
        
        public override bool IsMaxLevelReached()
        {
            return maxLevelReached;
        }
    }

    [Serializable]
    public abstract class Upgrade : MonoBehaviour
    {
        public virtual string DisplayInfo()
        {
            return "";
        }
        
        public virtual string PriceInfo()
        {
            return "";
        }

        public virtual bool IsMaxLevelReached()
        {
            return false;
        }
    }
}