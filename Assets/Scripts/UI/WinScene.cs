using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace nUI
{
    public class WinScene : MonoBehaviour
    {
        private string id_loadScene = "MainMenu";

        private void Start()
        {
            print("ganhou");
            SceneManager.LoadScene(id_loadScene);
        }
    }
}