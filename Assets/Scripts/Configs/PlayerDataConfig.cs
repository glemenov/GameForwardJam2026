using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "PlayerDataConfig", menuName = "Configs/PlayerDataConfig", order = 0)]
    public class PlayerDataConfig : ScriptableObject
    {
        public float startingMoney;
        public float defaultComboMultiplier;
    }
}