using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nController;
using UnityEngine.Events;

namespace nEvent
{
    public class EventTrigger : MonoBehaviour
    {
        public string text_gameOver;

        public float eventTime = 20f;

        public GameObject obj_minigame;

        public UnityEvent event_enable, event_disable;

        protected void OnEnable()
        {
            event_enable.Invoke();
        }
        protected void OnDisable()
        {
            event_disable.Invoke();
        }

        protected void OnTriggerEnter(Collider other)
        {
            PlayerController.s_singleton.inMinigameArea = true;
            PlayerController.s_singleton.eventT = this;
        }

        protected void OnTriggerExit(Collider other)
        {
            PlayerController.s_singleton.inMinigameArea = false;
            if(PlayerController.s_singleton.eventT == this) PlayerController.s_singleton.eventT = null;

            if(obj_minigame.activeSelf) ExitMinigame();
        }

        protected virtual bool EnableCondition()
        {
            return (!obj_minigame.activeSelf);
        }

        public void EnableMinigame()
        {
            if(!EnableCondition()) return;

            obj_minigame.SetActive(true);
            PlayerController.s_singleton.canMove = false;

            GameManager.s_singleton.currMinigame = obj_minigame;
        }

        public void ExitMinigame()
        {
            obj_minigame.SetActive(false);
            PlayerController.s_singleton.canMove = true;
        }
    }
}