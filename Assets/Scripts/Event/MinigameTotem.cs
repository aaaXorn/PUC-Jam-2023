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

        private void Awake()
        {
            rTransf = GetComponent<RectTransform>();
        }

        private void Start()
        {
            SpawnStone();
        }

        public void SpawnStone()
        {
            StoneMinigameTotem _stone = Instantiate(prefab_stone, rTransf_stoneSpawn).GetComponent<StoneMinigameTotem>();
            _stone.transform.parent = rTransf;

            _stone.minigame = this;
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