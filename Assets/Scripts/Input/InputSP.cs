using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nInput
{
    public class InputSP : MonoBehaviour
    {
        public static InputSP s_singleton;

        protected string id_hMove = "Horizontal";
        protected string id_vMove = "Vertical";

        protected string id_interact = "Interact";

        public Vector2 input_move = new Vector2();
        public bool input_interact;
        public bool input_interactDown;
        public bool input_interactUp;

        protected void Awake()
        {
            s_singleton = this;
        }

        protected void Update()
        {
            input_move.x = Input.GetAxisRaw(id_hMove);
            input_move.y = Input.GetAxisRaw(id_vMove);

            input_interact = Input.GetButton(id_interact);
            input_interactDown = Input.GetButtonDown(id_interact);
            input_interactUp = Input.GetButtonUp(id_interact);
        }
    }
}