using System;
using System.Collections.Generic;
using TriInspector;

namespace Upgrades
{
    public class BlockTierUpgrade : Upgrade
    {
        [TableList] public List<BlockUpgrade> blockLevels = new List<BlockUpgrade>();
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void BuyUpgrade()
        {
            if (HeadManager.Instance.playerDataManager.TryDeductMoney(blockLevels[currentLevel].price))
            {
                currentLevel++;

                if (currentLevel >= blockLevels.Count)
                {
                    maxLevelReached = true;
                    return;
                }

                HeadManager.Instance.playerDataManager.UpgradeBlockTier();
            }
        }

        public override string DisplayInfo()
        {
            return $"{blockLevels[currentLevel].tier} {displayName}";
        }

        public override string PriceInfo()
        {
            return $"{blockLevels[currentLevel].price} AED";
        }
        
        [Serializable]
        public class BlockUpgrade
        {
            public int tier;
            public int price;
        }
    }
}