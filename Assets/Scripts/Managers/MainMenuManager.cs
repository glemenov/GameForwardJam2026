using FMOD.Studio;
using FMODUnity;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private EventReference mainMenuMusic;
        EventInstance mainMenuMusicEvent;
        public MMF_Player player;

        public Slider volumeSlider;
        private Bus _masterBus;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // mainMenuMusic = RuntimeManager.CreateInstance(mainMenuMusic);
            _masterBus = RuntimeManager.GetBus("bus:/");
            player.PlayFeedbacks();
        }

        // Update is called once per frame
        void Update()
        {
            _masterBus.setVolume(volumeSlider.value);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void PlayGame()
        {
            SceneManager.LoadScene(1);
        }
    }
}