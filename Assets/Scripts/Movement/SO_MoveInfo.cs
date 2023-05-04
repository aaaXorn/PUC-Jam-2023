using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nMovement
{
    [CreateAssetMenu(fileName = "SO_MoveInfo", menuName = "ScriptableObjects/Character/Movement Info")]
    public class SO_MoveInfo : ScriptableObject
    {
        [Tooltip("Walk speed.")]
        public float spd = 5f;
        [Tooltip("Maximum walk speed.")]
        public float max_spd = 5f;
        [Tooltip("By how much the speed decays after going past the maximum.")]
        public float decay_spd = 10f;

        [Tooltip("How fast the character rotates to the input direction.")]
        public float rot_spd = 10f;

        [Tooltip("Gravity acceleration.")]
        public float gravity = -9.81f;
    }
}