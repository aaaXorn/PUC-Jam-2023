using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nInput;

namespace nEvent
{
    public class MinigameMash : MonoBehaviour
    {
        [SerializeField]
        private RectTransform rTransf_barra;

        [SerializeField]
        private float barra_increasePerTap = 15f;
        [SerializeField]
        private float barra_targetWidth = 500f;

        private Vector2 initPos;

        private float bucket_icon_timer = 0f;
        [SerializeField]
        private float bucket_icon_dur = 0.15f;

        [SerializeField]
        private GameObject obj_bucket_water;

        private void Start()
        {
            initPos = rTransf_barra.anchoredPosition;
        }

        private void OnDisable()
        {
            rTransf_barra.anchoredPosition = initPos;
            rTransf_barra.sizeDelta = new Vector2(0f, rTransf_barra.sizeDelta.x);
        }

        private void Update()
        {
            if(obj_bucket_water.activeSelf)
            {
                bucket_icon_timer -= Time.deltaTime;

                if(bucket_icon_timer <= 0f) obj_bucket_water.SetActive(false);
            }

            if(InputSP.s_singleton.input_interactDown)
            {
                bucket_icon_timer = bucket_icon_dur;
                if(!obj_bucket_water.activeSelf) obj_bucket_water.SetActive(true);

                rTransf_barra.anchoredPosition += Vector2.right * barra_increasePerTap / 2f;
                rTransf_barra.sizeDelta += Vector2.right * barra_increasePerTap;

                if(rTransf_barra.anchoredPosition.x >= 0f)
                {
                    rTransf_barra.anchoredPosition = new Vector2(0f, rTransf_barra.anchoredPosition.x);
                    rTransf_barra.sizeDelta = new Vector2(barra_targetWidth, rTransf_barra.anchoredPosition.y);

                    GameManager.s_singleton.WinEvent();
                }
            }
        }
    }
}