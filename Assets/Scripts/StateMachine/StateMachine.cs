using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nMovement;
using nInput;

namespace nStateMachine
{
    public class StateMachine : MonoBehaviour
    {
        protected Movement move;

        protected void Awake()
        {
            move = GetComponent<Movement>();
        }

        protected void Update()
        {
            Vector3 _input = new Vector3(InputSP.s_singleton.input_move.x, 0, InputSP.s_singleton.input_move.y).normalized;
            move.Move(_input);
            move.Rotate(_input);
        }
    }
}