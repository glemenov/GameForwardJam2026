using System;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeadManager : MonoBehaviour
{
    public PlayerDataManager playerDataManager;
    public GameStateManager gameStateManager;
    public UIManager uiManager;
    public Claw claw;
    
    public Slider volumeSlider;
    private Bus _masterBus;
    
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
        _masterBus = RuntimeManager.GetBus("bus:/");
    }

    // Update is called once per frame
    void Update()
    {
        _masterBus.setVolume(volumeSlider.value);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Defeat()
    {
        uiManager.DefeatScreen.canvas.enabled = true;
        uiManager.DefeatScreen.heightReachedText.SetText(playerDataManager.GetBlockCount().ToString());
        //uiManager.DefeatScreen.moneyEarnedText.SetText(playerDataManager.GetMoney().ToString() +" AED");
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
