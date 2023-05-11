using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nEvent
{
    public class EventPedraTrigger : EventTrigger
    {
        public int pedras = 0;

        protected override bool EnableCondition()
        {
            return ((!obj_minigame.activeSelf) && pedras >= 3);
        }
    }
}