

namespace Upgrades
{
    public class BlockTierUpgrade : Upgrade
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void InitiateUpgrade()
        {
            if (base.TryBuyUpgrade())
            {
                HeadManager.Instance.playerDataManager.UpgradeBlockTier();
            }
        }

        public override string DisplayInfo()
        {
            return $"{upgradeLevels[currentLevel].value} {displayName}";
        }
    }
}