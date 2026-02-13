using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Stat", menuName = "Stat", order = 0)]
    public class Stat : ScriptableObject
    {
        public float defaultValue;
        public float value;
        public List<int> percentageModifiers = new List<int>();

        public void Reset()
        {
            value = defaultValue;
            percentageModifiers.Clear();
        }

        public float GetValue()
        {
            float result = value;

            foreach (var percentageModifier in percentageModifiers)
            {
                result += (value * percentageModifier / 100f);
            }

            Debug.Log($"Returning value: {result}");
            return result;
        }
    }
}