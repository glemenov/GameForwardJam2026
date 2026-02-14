using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadManager : MonoBehaviour
{
    public PlayerDataManager playerDataManager;
    public GameStateManager gameStateManager;
    public UIManager uiManager;
    
    private static HeadManager _instance;

    public static HeadManager Instance  { get { return _instance; } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Defeat()
    {
        uiManager.DefeatScreen.canvas.enabled = true;
        uiManager.DefeatScreen.heightReachedText.SetText(playerDataManager.GetBlockCount().ToString());
        uiManager.DefeatScreen.moneyEarnedText.SetText(playerDataManager.GetMoney().ToString() +" AED");
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
