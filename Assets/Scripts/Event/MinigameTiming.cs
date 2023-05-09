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
        private float bolinha_spd = 450f;
        [SerializeField]
        private float bolinha_border_top = 233f, bolinha_border_bottom = -233f;
        [SerializeField]
        private float bolinha_target_top = 34f, bolinha_target_bottom = -34f;

        private bool bolinha_goUp = true;

        private int points = 0;
        [SerializeField]
        private int points_needed = 5;
        [SerializeField]
        private int points_perHit = 1, points_perMiss = 2;

        private Vector2 bolinha_initPos;

        private void Start()
        {
            bolinha_initPos = rTransf_bolinha.anchoredPosition;
        }

        private void OnDisable()
        {
            rTransf_bolinha.anchoredPosition = bolinha_initPos;
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
                    TimingHit();
                }
                else
                {
                    TimingMiss();
                }
            }
        }

        private void TimingHit()
        {
            points += points_perHit;

            if(points >= points_needed)
            {
                points = points_needed;
                GameManager.s_singleton.WinEvent();
            }

            print("hit");
        }

        private void TimingMiss()
        {
            points -= points_perMiss;

            if(points < 0) points = 0;

            print("miss");
        }
    }
}