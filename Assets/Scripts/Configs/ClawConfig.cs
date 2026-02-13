using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "ClawConfig", menuName = "Configs/ClawConfig", order = 0)]
    public class ClawConfig : ScriptableObject
    {
        public float elevationModifier;
    }
}