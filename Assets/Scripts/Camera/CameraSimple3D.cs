using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nCamera
{
    public class CameraSimple3D : MonoBehaviour
    {
        [SerializeField]
        protected Transform camFollow;

        [SerializeField]
        protected Transform playerFollow;

        [SerializeField]
        protected Vector3 camOffset = new Vector3(0f, 10f, -5f);

        public float shake = 0f;

        protected Vector3 shake_vector = Vector3.zero;

        protected void Start()
        {
            if(camFollow == null)
            {
                camFollow = Camera.main.transform;
            }
        }

        protected void FixedUpdate()
        {
            float shake_x = Random.Range(0, shake);
            float shake_y = Random.Range(0, shake);
            float shake_z = Random.Range(0, shake);

            shake_vector = new Vector3(shake_x, shake_y, shake_z);
        }

        protected void LateUpdate()
        {
            MoveCameraFollow();
            MoveCamera();
        }

        protected void MoveCameraFollow()
        {
            float shake_x = Random.Range(0, shake);
            float shake_y = Random.Range(0, shake);
            float shake_z = Random.Range(0, shake);

            camFollow.position = playerFollow.position + shake_vector;
        }

        protected void MoveCamera()
        {
            transform.position = camFollow.position + camOffset;
        }

        public void Shake(bool _shake)
        {
            shake = _shake ? 0.05f : 0f;
        }
    }
}