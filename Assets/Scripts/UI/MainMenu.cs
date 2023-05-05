using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace nUI
{
    public class MainMenu : MonoBehaviour
    {
        [Tooltip("Gameplay scene.")] [SerializeField]
        private string id_scene_gameplay = "Game";

        [Tooltip("Option menu.")] [SerializeField]
        private GameObject option_menu;
        [Tooltip("How to play menu.")] [SerializeField]
        private GameObject h2p_menu;

        public void PlayGame()
        {
            SceneManager.LoadScene(id_scene_gameplay);
        }

        public void OpenCloseOptions()
        {
            option_menu.SetActive(!option_menu.activeSelf);
        }

        public void OpenCloseH2P()
        {
            h2p_menu.SetActive(!h2p_menu.activeSelf);
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void Volume()
        {
            
        }
    }
}