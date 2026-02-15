using System;
using System.Collections.Generic;
using DefaultNamespace;
using FMODUnity;
using TriInspector;
using UnityEngine;

namespace Upgrades
{
    public class SpawnSpeedUpgrade : Upgrade
    {
        public Stat statToApply;

        public override void InitiateUpgrade()
        {
            if (base.TryBuyUpgrade())
            {
                statToApply.percentageModifier = (upgradeLevels[currentLevel].value);
            }
        }

        public override string DisplayInfo()
        {
            return $"{upgradeLevels[currentLevel].value}% {displayName}";
        }
    }

    [Serializable]
    public abstract class Upgrade : MonoBehaviour
    {
        public EventReference upgradeSFX;
        public string displayName;
        public int currentLevel = 0;
        public bool maxLevelReached = false;

        [TableList] public List<UpgradeLevel> upgradeLevels = new List<UpgradeLevel>();

        [Serializable]
        public class UpgradeLevel
        {
            public float value;
            public int price;
        }

        public virtual string DisplayInfo()
        {
            return "";
        }

        public virtual string PriceInfo()
        {
            return $"{upgradeLevels[currentLevel].price}";
        }
        
        public virtual void InitiateUpgrade() {}
        
        public virtual bool TryBuyUpgrade()
        {
            if (HeadManager.Instance.playerDataManager.TryDeductMoney(upgradeLevels[currentLevel].price)
                && !maxLevelReached)
            {
                currentLevel++;

                if (currentLevel + 1 >= upgradeLevels.Count)
                {
                    maxLevelReached = true;
                }
                
                RuntimeManager.PlayOneShot(upgradeSFX, HeadManager.Instance.claw.transform.position);

                return true;
            }

            return false;
        }

        public bool IsMaxLevelReached()
        {
            return maxLevelReached;
        }
    }
}