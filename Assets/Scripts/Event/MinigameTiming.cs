using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nInput;

namespace nEvent
{
    public class MinigameTiming : MonoBehaviour
    {
        [SerializeField]
        private RectTransform rTransf_bolinha;
        
        [SerializeField]
        private float bolinha_spd = 920f;
        [SerializeField]
        private float bolinha_border_top = 460f, bolinha_border_bottom = -460f;
        [SerializeField]
        private float bolinha_target_top = 75f, bolinha_target_bottom = -75f;
        [SerializeField]
        private float bolinha_sourSpot_top = 195f, bolinha_sourSpot_bottom = -195f;

        private bool bolinha_goUp = true;

        private int points = 0;
        [SerializeField]
        private int points_needed = 100;
        [SerializeField]
        private int points_perHit = 20, points_perMiss = 40, points_perSourSpot = 5;

        private Vector2 bolinha_initPos;

        [SerializeField]
        private RectTransform rTransf_barra;
        private Vector2 barra_initPos;
        [SerializeField]
        private float barra_targetWidth = 953f;

        private void Start()
        {
            bolinha_initPos = rTransf_bolinha.anchoredPosition;
            barra_initPos = rTransf_barra.anchoredPosition;
        }

        private void OnDisable()
        {
            rTransf_bolinha.anchoredPosition = bolinha_initPos;
            rTransf_barra.anchoredPosition = barra_initPos;
            rTransf_barra.sizeDelta = new Vector2(0f, rTransf_barra.sizeDelta.y);
            bolinha_goUp = true;
        }

        private void Update()
        {
            if(bolinha_goUp)
            {
                rTransf_bolinha.anchoredPosition += Vector2.up * bolinha_spd * Time.deltaTime;

                if(rTransf_bolinha.anchoredPosition.y >= bolinha_border_top)
                {
                    bolinha_goUp = false;
                }

                CheckIfHit();
            }
            else
            {
                rTransf_bolinha.anchoredPosition += Vector2.down * bolinha_spd * Time.deltaTime;

                if(rTransf_bolinha.anchoredPosition.y <= bolinha_border_bottom)
                {
                    bolinha_goUp = true;
                }

                CheckIfHit();
            }
        }

        private void CheckIfHit()
        {
            if(InputSP.s_singleton.input_interactDown)
            {
                if(rTransf_bolinha.anchoredPosition.y <= bolinha_target_top && rTransf_bolinha.anchoredPosition.y >= bolinha_target_bottom)
                {
                    TimingHit(true);
                }
                else if(rTransf_bolinha.anchoredPosition.y <= bolinha_sourSpot_top && rTransf_bolinha.anchoredPosition.y >= bolinha_sourSpot_bottom)
                {
                    TimingHit(false);
                }
                else
                {
                    TimingMiss();
                }
            }
        }

        private void TimingHit(bool _sweetSpot)
        {
            points += (_sweetSpot ? points_perHit : points_perSourSpot);

            if(points >= points_needed)
            {
                points = points_needed;
                GameManager.s_singleton.WinEvent();
            }
            
            rTransf_barra.sizeDelta = new Vector2 (barra_targetWidth * points / points_needed, rTransf_barra.sizeDelta.y);
            rTransf_barra.anchoredPosition = barra_initPos + new Vector2(rTransf_barra.sizeDelta.x/2, 0f);
        }

        private void TimingMiss()
        {
            points -= points_perMiss;

            if(points < 0) points = 0;

            rTransf_barra.sizeDelta = new Vector2 (barra_targetWidth * points / points_needed, rTransf_barra.sizeDelta.y);
            rTransf_barra.anchoredPosition = barra_initPos + new Vector2(rTransf_barra.sizeDelta.x/2, 0f);
        }
    }
}