using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace nUI
{
    public class GameOver : MonoBehaviour
    {
        private string id_loadScene = "SampleScene";

        private void Start()
        {
            print("perdeu");
            SceneManager.LoadScene(id_loadScene);
        }
    }
}