using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nEvent
{
    public class MinigameTotem : MonoBehaviour
    {
        private RectTransform rTransf;

        [SerializeField]
        private GameObject prefab_stone;
        [SerializeField]
        private RectTransform rTransf_stoneSpawn;

        private int hits = 0;
        private int hits_needed = 3;

        private List<GameObject> list_spawnedStones = new List<GameObject>();

        [SerializeField]
        private GameObject obj_totem;

        private void Awake()
        {
            rTransf = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            SpawnStone();
        }
        private void OnDisable()
        {
            foreach(GameObject obj in list_spawnedStones)
            {
                Destroy(obj);
            }

            list_spawnedStones.Clear();
            obj_totem.tag = "MinigameTarget";
        }

        public void SpawnStone()
        {
            GameObject _stone = Instantiate(prefab_stone, rTransf_stoneSpawn);
            _stone.transform.SetParent(rTransf, true);

            list_spawnedStones.Add(_stone);

            _stone.GetComponent<StoneMinigameTotem>().minigame = this;
        }

        public void Hit()
        {
            hits++;
            if(hits >= hits_needed)
            {
                GameManager.s_singleton.WinEvent();
            }
            else
            {
                SpawnStone();
            }
        }
    }
}