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
            //horizontal velocity, without the Y axis
            Vector3 _h_velocity = new Vector3(velocity.x, 0f, velocity.z);

            //if below maximum speed
            if(_h_velocity.magnitude <= so_move.max_spd)
            {
                //instantly changes the speed to the target value
                velocity = new Vector3(_dir.x * so_move.spd, velocity.y, _dir.z * so_move.spd);
            }
            //otherwise
            else
            {
                //gradually slows the player down
                velocity = velocity - ((_h_velocity.normalized * so_move.decay_spd) + (_dir * so_move.spd)) * Time.deltaTime;
            }

            Gravity();

            //uses the CharacterController to apply movement
            cc.Move(velocity * Time.deltaTime);
        }

        public override void Gravity()
        {
            //if touching the ground
            if(cc.isGrounded)
            {
                //keeps vertical velocity below 0 to make sure the character doesn't float slightly above the ground
                velocity.y = so_move.gravity * Time.deltaTime;
            }
            else
            {
                //applies gravity over time
                velocity.y += so_move.gravity * Time.deltaTime;
            }
        }
    }
}