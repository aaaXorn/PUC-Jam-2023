using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager s_singleton {get; private set;}

    //eventos que ainda não foram usados
    [SerializeField]
    private List<GameObject> list_unusedEvents = new List<GameObject>();
    //eventos que já foram usados
    private List<GameObject> list_usedEvents = new List<GameObject>();

    public GameObject currEvent;

    #region timer
    private bool stopTimer = false;

    private bool isInEvent = false;
    private float eventTime = 0f;
    private float eventCD = 15f;

    private float gameOverTime = 0f;
    private float gameOverTimer = 15f;

    private void Awake()
    {
        s_singleton = this;
    }

    private void Update()
    {
        if(stopTimer)
        {
            

            return;
        }

        if(!isInEvent)
        {
            if(eventTime > eventCD)
            {
                StartEvent();
            }

            eventTime += Time.deltaTime;
        }
        else
        {
            if(gameOverTime > gameOverTimer)
            {
                GameOver();
            }

            gameOverTime += Time.deltaTime;
        }
    }
    #endregion

    #region events
    private void StartEvent()
    {
        isInEvent = true;
        gameOverTime = 0f;

        int nextEvent = Random.Range(0, list_unusedEvents.Count);

        currEvent = list_unusedEvents[nextEvent];//Instantiate(list_unusedEvents[nextEvent], Vector3.zero, Quaternion.identity);
        currEvent.SetActive(true);
        list_unusedEvents.RemoveAt(nextEvent);
    }

    private void GameOver()
    {
        stopTimer = true;
    }

    private void WinEvent()
    {
        Destroy(currEvent);

        isInEvent = false;
        eventTime = 0f;

        stopTimer = true;

        if(list_unusedEvents.Count <= 0)
        {
            //win game
        }
    }
    #endregion
}
