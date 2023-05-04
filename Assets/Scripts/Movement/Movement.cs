using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nMovement
{
    public class Movement : MonoBehaviour
    {
        [Tooltip("Movement stats.")] [SerializeField]
        protected SO_MoveInfo so_move;

        [Tooltip("Current speed.")]
        public Vector3 velocity;

        //movement
        public virtual void Move(Vector3 _dir)
        {
            //empty, changed after inheritance
        }

        //gradually rotates object towards direction
        public virtual void Rotate(Vector3 _dir)
        {
            //gets the next rotation vector
            Vector3 _rot = Vector3.RotateTowards(transform.forward, _dir, so_move.rot_spd * Time.deltaTime, 0f);
            //applies it as a quaternion
            transform.rotation = Quaternion.LookRotation(_rot);
        }

        //gravity
        public virtual void Gravity()
        {
            //empty, changed after inheritance
        }
    }
}