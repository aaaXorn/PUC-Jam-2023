using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nInput;

namespace nEvent
{
    public class StoneMinigameTotem : MonoBehaviour
    {
        public MinigameTotem minigame;

        private RectTransform rTransf;
        private Rigidbody2D rb;

        private bool isPositioning = true;

        private bool goRight = true;
        [SerializeField]
        private float positioning_spd = 310f;
        [SerializeField]
        private float positioning_borderL = -210f, positioning_borderR = 210f;

        [SerializeField]
        private float falling_spd = 150f;

        private bool isPlaced = false;

        private void Awake()
        {
            rTransf = GetComponent<RectTransform>();
            rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            rb.velocity = Vector2.right * positioning_spd;
        }

        private void Update()
        {
            if(isPositioning)
            {
                if(InputSP.s_singleton.input_interactDown)
                {
                    isPositioning = false;
                    rb.velocity = Vector2.down * falling_spd;
                }
                else
                {
                    if(goRight)
                    {
                        //rTransf.anchoredPosition += Vector2.right * positioning_spd * Time.deltaTime;

                        if(rTransf.anchoredPosition.x >= positioning_borderR)
                        {
                            goRight = false;
                            rb.velocity = Vector2.left * positioning_spd;
                        }
                    }
                    else
                    {
                        //rTransf.anchoredPosition += Vector2.left * positioning_spd * Time.deltaTime;

                        if(rTransf.anchoredPosition.x <= positioning_borderL)
                        {
                            goRight = true;
                            rb.velocity = Vector2.right * positioning_spd;
                        }
                    }
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(isPlaced) return;

            if(other.gameObject.CompareTag("MinigameTarget"))
            {
                isPlaced = true;

                gameObject.tag = "MinigameTarget";
                other.gameObject.tag = "Untagged";
                minigame.Hit();
            }
            else
            {
                minigame.SpawnStone();
                Destroy(gameObject);
            }

            rb.velocity = Vector2.zero;
        }
    }
}