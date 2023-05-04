using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nMovement
{
    [CreateAssetMenu(fileName = "SO_MoveInfo", menuName = "ScriptableObjects/Character/Movement Info")]
    public class SO_MoveInfo : ScriptableObject
    {
        public float spd = 5f;
        public float max_spd = 5f;
        public float decay_spd = 10f;

        public float rot_spd = 10f;

        public float gravity = 9.81f;
    }
}