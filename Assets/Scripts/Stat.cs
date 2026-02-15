using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Stat", menuName = "Stat", order = 0)]
    public class Stat : ScriptableObject
    {
        public float defaultValue;
        public float value;
        public float percentageModifier;

        public void Reset()
        {
            value = defaultValue;
            percentageModifier = 0;
        }

        public float GetValue()
        {
            float result = value;

            if(percentageModifier != 0)
            {
                result += (value * percentageModifier / 100f);
            }

            Debug.Log($"{name} RETURNING VALUE {result}");

            return result;
        }
    }
}