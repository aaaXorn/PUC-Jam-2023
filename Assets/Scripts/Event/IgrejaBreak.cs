using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nEvent
{
    public class IgrejaBreak : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] array_obj_igreja;

        public void ChangeIgreja(int _igreja)
        {
            for(int i = 0; i < array_obj_igreja.Length; i++)
            {
                array_obj_igreja[i].SetActive(_igreja == i);
            }
        }
    }
}