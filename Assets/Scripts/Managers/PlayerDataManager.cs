using Configs;
using TMPro;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public PlayerDataConfig playerConfig;

    private float _playerMoney;
    private int _currentBlockTier;
    
    public delegate void OnBlockTierUpgraded();
    public OnBlockTierUpgraded onBlockTierUpgraded;
    
    //UI
    public TMP_Text playerMoneyText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerMoney = playerConfig.startingMoney;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        playerMoneyText.SetText($"{_playerMoney} AED");
    }

    public void AddMoney(float amount)
    {
        Debug.Log($"Money added: {amount}");
        _playerMoney += amount;
    }

    public bool TryDeductMoney(float amount)
    {
        if (_playerMoney >= amount)
        {
            Debug.Log($"Money deducted: {amount}");
            _playerMoney -= amount;
            return true;
        }
        else
        {
            Debug.Log($"Can't deduct money: {amount}");
            return false;
        }
    }

    public int GetBlockTier() => _currentBlockTier;

    public void UpgradeBlockTier()
    {
        _currentBlockTier++;
        onBlockTierUpgraded.Invoke();
    }
}
