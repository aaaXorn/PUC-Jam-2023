using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager s_singleton {get; private set;}

    //eventos que ainda não foram usados
    private List<GameObject> list_unusedEvents = new List<GameObject>();
    //eventos que já foram usados
    private List<GameObject> list_usedEvents = new List<GameObject>();

    private void Awake()
    {
        s_singleton = this;
    }
}
