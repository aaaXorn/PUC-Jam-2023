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
        private float barra_targetHeight = 500f;

        private void Update()
        {
            if(InputSP.s_singleton.input_interactDown)
            {
                rTransf_barra.anchoredPosition += Vector2.up * barra_increasePerTap / 2f;
                rTransf_barra.sizeDelta += Vector2.up * barra_increasePerTap;

                if(rTransf_barra.anchoredPosition.y >= 0f)
                {
                    rTransf_barra.anchoredPosition = new Vector2(rTransf_barra.anchoredPosition.x, 0f);
                    rTransf_barra.sizeDelta = new Vector2(rTransf_barra.sizeDelta.x, barra_targetHeight);

                    GameManager.s_singleton.WinEvent();
                }
            }
        }
    }
}