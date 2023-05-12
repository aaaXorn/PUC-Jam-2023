using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace nUI
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text text;

        public static string text_gameOver;

        private string id_loadScene = "Game";

        private void Start()
        {
            text.text = text_gameOver;
        }

        private void Update()
        {
            if(Input.GetButtonDown("Interact"))
                SceneManager.LoadScene(id_loadScene);
            else if(Input.GetKeyDown(KeyCode.Escape))
                SceneManager.LoadScene("MainMenu");
        }
    }
}