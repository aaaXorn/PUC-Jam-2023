using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nEvent
{
    public class StoneMinigameTotem : MonoBehaviour
    {
        private enum State { Positioning, Falling, Idle }
        private State state = State.Positioning;

        private void Update()
        {
            switch(state)
            {
                case State.Positioning:
                    StatePositioning();
                    break;

                case State.Falling:
                    StateFalling();
                    break;
                
                case State.Idle:
                    StateIdle();
                    break;
            }
        }

        private void StatePositioning()
        {

        }

        private void StateFalling()
        {

        }

        private void StateIdle()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Minigame"))
            {

            }
            else
            {

            }

            state = State.Idle;
        }
    }
}