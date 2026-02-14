using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
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