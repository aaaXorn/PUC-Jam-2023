using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nDebugging
{
    public class QuickImport : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] array_obj_import;

        private void Start()
        {
            foreach(GameObject _obj in array_obj_import)
            {
                _obj.transform.parent = null;
            }
        }
    }
}