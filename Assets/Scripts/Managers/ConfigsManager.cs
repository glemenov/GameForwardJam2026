using Configs;
using UnityEngine;

namespace Managers
{
    public class ConfigsManager : MonoBehaviour
    {
        public BuildingBlockConfig buildingBlockConfig;
        
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