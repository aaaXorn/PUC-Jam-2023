using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nMovement;
using nInput;
using nEvent;

namespace nController
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController s_singleton;

        [Tooltip("Movement functions.")] [SerializeField]
        private Movement move;

        //if the character can move
        public bool canMove = true;

        public bool inMinigameArea;
        public EventTrigger eventT;

        private void Awake()
        {
            if(move == null) move = GetComponent<Movement>();

            s_singleton = this;
        }

        private void Update()
        {
            //gets the input
            Vector3 _input = Vector3.zero;
            if(canMove)
            {
                //if the player can't move, input is null by default
                _input = new Vector3(InputSP.s_singleton.input_move.x, 0, InputSP.s_singleton.input_move.y).normalized;

                move.Rotate(_input);

                if(InputSP.s_singleton.input_interactDown && eventT != null)
                {
                    eventT.EnableMinigame();
                }
            }
            else
            {
                if(eventT == null)
                {
                    canMove = true;
                }
                else if(Input.GetKeyDown(KeyCode.Escape) && eventT.obj_minigame.activeSelf)
                {
                    eventT.ExitMinigame();
                }
            }

            //movement and gravity
            move.Move(_input);
        }
    }
}