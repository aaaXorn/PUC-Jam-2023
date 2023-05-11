using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nEvent
{
    public class DetectPedraTrigger : MonoBehaviour
    {
        protected void Start()
        {
            gameObject.SetActive(true);
        }

        [SerializeField] 
        private EventPedraTrigger eventT;

        private void OnTriggerEnter()
        {
            eventT.pedras++;
        }

        private void OnTriggerExit()
        {
            eventT.pedras--;
            if(eventT.pedras < 0) eventT.pedras = 0;
        }
    }
}