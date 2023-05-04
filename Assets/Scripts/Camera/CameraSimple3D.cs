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

        protected void Start()
        {
            if(camFollow == null)
            {
                camFollow = Camera.main.transform;
            }
        }

        protected void LateUpdate()
        {
            MoveCameraFollow();
            MoveCamera();
        }

        protected void MoveCameraFollow()
        {
            camFollow.position = playerFollow.position;
        }

        protected void MoveCamera()
        {
            transform.position = camFollow.position + camOffset;
        }
    }
}