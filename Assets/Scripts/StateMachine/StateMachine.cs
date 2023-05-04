using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
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
            Vector3 _input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
            move.Move(_input);
            move.Rotate(_input);
        }
    }
}