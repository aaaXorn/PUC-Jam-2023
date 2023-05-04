using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nMovement;
using nInput;

namespace nController
{
    public class PlayerController : MonoBehaviour
    {
        [Tooltip("Movement functions.")] [SerializeField]
        protected Movement move;

        //if the character can move
        protected bool canMove = true;

        protected void Awake()
        {
            if(move == null) move = GetComponent<Movement>();
        }

        protected void Update()
        {
            //gets the input
            Vector3 _input = Vector3.zero;
            if(canMove)
            {
                //if the player can't move, input is null by default
                _input = new Vector3(InputSP.s_singleton.input_move.x, 0, InputSP.s_singleton.input_move.y).normalized;

                move.Rotate(_input);
            }

            //movement and gravity
            move.Move(_input);
        }
    }
}