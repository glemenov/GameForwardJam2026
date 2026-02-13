using Configs;
using UnityEngine;

namespace Managers
{
    public class ConfigsManager : MonoBehaviour
    {
        public BuildingBlockConfig buildingBlockConfig;
        public ClawConfig clawConfig;
        
        private static ConfigsManager _instance;
        public static ConfigsManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
    }
}