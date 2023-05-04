using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Movement : MonoBehaviour
    {
        [SerializeField]
        protected SO_MoveInfo so_move;

        public Vector3 velocity;

        public virtual void Move(Vector3 _dir)
        {

        }

        public virtual void Rotate(Vector3 _dir)
        {
            Vector3 _rot = Vector3.RotateTowards(transform.forward, _dir, so_move.rot_spd * Time.deltaTime, 0f);

            transform.rotation = Quaternion.LookRotation(_rot);
        }

        protected Vector3 gravity_dir = Vector3.down;

        public virtual void Gravity()
        {

        }

        public virtual void GroundCheck()
        {

        }
    }
}