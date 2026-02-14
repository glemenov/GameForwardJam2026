using Configs;
using TMPro;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public PlayerDataConfig playerConfig;

    private float _playerMoney;
    private int _currentBlockTier;
    private float _currentComboMultiplier;
    private int _currentCombo;
    private int _blockCount;
    
    public delegate void OnBlockTierUpgraded();
    public OnBlockTierUpgraded onBlockTierUpgraded;
    
    //UI
    public TMP_Text playerMoneyText;
    public TMP_Text blockHeightText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerMoney = playerConfig.startingMoney;
        _currentComboMultiplier = playerConfig.defaultComboMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        playerMoneyText.SetText($"{_playerMoney} AED");
        blockHeightText.SetText($"{_blockCount}");
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
    
    public float GetMoney() => _playerMoney;

    public int GetBlockTier() => _currentBlockTier;

    public void UpgradeBlockTier()
    {
        _currentBlockTier++;
        onBlockTierUpgraded.Invoke();
    }
    
    public float GetComboMultiplier() => _currentComboMultiplier;
    public void UpgradeComboMultiplier(float multiplier) => _currentComboMultiplier = multiplier;
    
    public int GetCombo() => _currentCombo;
    public void IncreaseCombo() => _currentCombo++;
    public void ResetCombo() => _currentCombo = 0;
    public int GetBlockCount() => _blockCount;
    public void UpdateBlockCount() => _blockCount++;
}
