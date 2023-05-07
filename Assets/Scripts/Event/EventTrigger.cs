using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nController;

namespace nEvent
{
    public class EventTrigger : MonoBehaviour
    {
        public GameObject obj_minigame;

        private void OnTriggerEnter(Collider other)
        {
            PlayerController.s_singleton.inMinigameArea = true;
            PlayerController.s_singleton.eventT = this;
        }

        private void OnTriggerExit(Collider other)
        {
            PlayerController.s_singleton.inMinigameArea = false;

            if(obj_minigame.activeSelf) ExitMinigame();
        }

        public void EnableMinigame()
        {
            if(obj_minigame.activeSelf) return;

            obj_minigame.SetActive(true);
            PlayerController.s_singleton.canMove = false;

            GameManager.s_singleton.currEvent = obj_minigame;
        }

        public void ExitMinigame()
        {
            obj_minigame.SetActive(false);
            PlayerController.s_singleton.canMove = true;
        }
    }
}