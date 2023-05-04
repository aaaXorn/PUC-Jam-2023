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

        public Vector2 input_move = new Vector2();

        protected void Awake()
        {
            s_singleton = this;
        }

        protected void Update()
        {
            input_move.x = Input.GetAxisRaw(id_hMove);
            input_move.y = Input.GetAxisRaw(id_vMove);
        }
    }
}