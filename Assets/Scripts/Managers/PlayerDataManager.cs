using Configs;
using TMPro;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public PlayerDataConfig playerConfig;

    public float playerMoney;
    
    //UI
    public TMP_Text playerMoneyText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMoney = playerConfig.startingMoney;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        playerMoneyText.SetText($"{playerMoney} AED");
    }

    public void AddMoney(float amount)
    {
        Debug.Log($"Money added: {amount}");
        playerMoney += amount;
    }
}
