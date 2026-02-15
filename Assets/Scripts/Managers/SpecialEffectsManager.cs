using DamageNumbersPro;
using UnityEngine;

public class SpecialEffectsManager : MonoBehaviour
{
    public DamageNumber moneyNimberPrefab;
    
    private static SpecialEffectsManager _instance;
    public static SpecialEffectsManager Instance  { get { return _instance; } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
}
