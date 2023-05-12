using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace nUI
{
    public class MainMenu : MonoBehaviour
    {
        [Tooltip("Gameplay scene.")] [SerializeField]
        private string id_scene_gameplay = "Plot";

        [Tooltip("Option menu.")] [SerializeField]
        private GameObject option_menu;
        [Tooltip("How to play menu.")] [SerializeField]
        private GameObject h2p_menu;

        [SerializeField]
        private AudioMixer audioM;
        [SerializeField]
        private Slider audioSlider;

        private void Start()
        {
            if(PlayerPrefs.HasKey("Volume"))
            {
                float _value = PlayerPrefs.GetFloat("Volume");
                audioSlider.value = _value;
                Volume(_value);
            }
            else
            {
                Volume(0.5f);
            }
        }

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

        public void Volume(float _value)
        {
            float _volumeValue = Mathf.Log10(_value) * 20f;
            audioM.SetFloat("MasterVolume", _volumeValue);

            PlayerPrefs.SetFloat("Volume", _value);
            PlayerPrefs.Save();
        }
    }
}