using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "BuildingBlockConfig", menuName = "Configs/BuildingBlockConfig", order = 0)]
    public class BuildingBlockConfig : ScriptableObject
    {
        public float blockFallingSpeed;
        public float perfectScoreAllowed; // How close to perfect is considered "perfect"
    }
}