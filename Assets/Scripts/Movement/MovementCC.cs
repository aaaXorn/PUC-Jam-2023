using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nMovement
{
    public class MovementCC : Movement
    {
        protected CharacterController cc;

        protected void Awake()
        {
            cc = GetComponent<CharacterController>();
        }

        public override void Move(Vector3 _dir)
        {
            if(velocity.magnitude <= so_move.max_spd)
            {
                velocity = _dir * so_move.spd;
            }
            else
            {
                velocity = velocity - (velocity.normalized * so_move.decay_spd) + (_dir * so_move.spd);
            }

            cc.Move(velocity * Time.deltaTime);
        }

        public override void Gravity()
        {

        }
    }
}