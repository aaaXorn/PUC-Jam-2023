using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace nUI
{
    public class PlotScene : MonoBehaviour
    {
        private void Update()
        {
            if(Input.GetButtonDown("Interact"))
            {
                SceneManager.LoadScene("Game");
            }
        }
    }
}