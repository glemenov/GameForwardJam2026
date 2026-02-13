using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Upgrades;

public class UpgradeButton : MonoBehaviour
{
    
    public Upgrade upgrade;
    public TMP_Text text;
    public TMP_Text priceText;
    public Button Button;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(upgrade.DisplayInfo());
        priceText.SetText(upgrade.PriceInfo());

        if (upgrade.IsMaxLevelReached())
        {
            Button.interactable = false;
        }
    }
}
