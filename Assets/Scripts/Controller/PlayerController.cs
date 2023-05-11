using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nMovement;
using nInput;
using nEvent;

namespace nController
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController s_singleton;

        [Tooltip("Movement functions.")] [SerializeField]
        private Movement move;

        //if the character can move
        public bool canMove = true;

        public bool inMinigameArea;
        public EventTrigger eventT;

        [SerializeField]
        private Animator anim;

        [SerializeField]
        private Transform transf_grab;

        [SerializeField]
        private Transform transf_grabbedObj;

        private void Awake()
        {
            if(move == null) move = GetComponent<Movement>();

            s_singleton = this;
        }

        private void Update()
        {
            //gets the input
            Vector3 _input = Vector3.zero;
            if(canMove)
            {
                //if the player can't move, input is null by default
                _input = new Vector3(InputSP.s_singleton.input_move.x, 0, InputSP.s_singleton.input_move.y);
                _input = Camera.main.transform.TransformDirection(_input);
                _input.y = 0f;
                _input = _input.normalized;

                move.Rotate(_input);

                if(InputSP.s_singleton.input_interactDown)
                {
                    if(transf_grabbedObj != null)
                    {
                        transf_grabbedObj.parent = null;

                        Rigidbody _rb = transf_grabbedObj.GetComponent<Rigidbody>();
                        if(_rb != null)
                        {
                            _rb.isKinematic = false;
                        }
                        
                        transf_grabbedObj = null;
                        anim.SetBool("Item", false);
                    }
                    else if(eventT != null)
                        eventT.EnableMinigame();
                    else
                    {
                        Collider[] _colls = Physics.OverlapSphere(transf_grab.position, 1f, (1<<7), QueryTriggerInteraction.Ignore);

                        if(_colls.Length > 0)
                        {
                            transf_grabbedObj = _colls[0].transform;
                            transf_grabbedObj.position = transf_grab.position;
                            transf_grabbedObj.SetParent(transform, true);

                            Rigidbody _rb = transf_grabbedObj.GetComponent<Rigidbody>();
                            if(_rb != null)
                            {
                                _rb.isKinematic = true;
                            }

                            anim.SetBool("Item", true);
                        }
                    }
                }
            }
            else
            {
                if(eventT == null)
                {
                    canMove = true;
                }
                else if(Input.GetKeyDown(KeyCode.Escape) && eventT.obj_minigame.activeSelf)
                {
                    eventT.ExitMinigame();
                }
            }

            //movement and gravity
            move.Move(_input);

            anim.SetFloat("Velocidade", _input.magnitude);
        }
    }
}