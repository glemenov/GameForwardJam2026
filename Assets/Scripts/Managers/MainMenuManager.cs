using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private EventReference mainMenuMusic;
        EventInstance mainMenuMusicEvent;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // mainMenuMusic = RuntimeManager.CreateInstance(mainMenuMusic);
        }

        // Update is called once per frame
        void Update()
        {
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