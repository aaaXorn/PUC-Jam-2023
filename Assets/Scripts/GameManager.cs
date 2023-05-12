using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using nEvent;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager s_singleton {get; private set;}

    //eventos que ainda não foram usados
    [SerializeField]
    private List<GameObject> list_unusedEvents = new List<GameObject>();
    //eventos que já foram usados
    private List<GameObject> list_usedEvents = new List<GameObject>();

    public GameObject currMinigame;
    public GameObject currEvent;

    #region timer
    private bool stopTimer = false;

    private bool isInEvent = false;
    private float eventTime = 0f;
    [SerializeField]
    private float eventCD = 15f;

    private float gameOverTime = 0f;

    [Tooltip("Menor que 0 é aleatório")] [SerializeField]
    private int force_event = -1;

    [SerializeField]
    private TMP_Text timerText;
    [SerializeField]
    private Color clr_eventCD, clr_gameOverTime;

    private void Awake()
    {
        s_singleton = this;
    }

    private void Start()
    {
        timerText.color = clr_eventCD;
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
            timerText.text = (eventCD - eventTime).ToString("F2");
        }
        else
        {
            if(gameOverTime <= 0f)
            {
                GameOver();
            }

            gameOverTime -= Time.deltaTime;
            timerText.text = gameOverTime.ToString("F2");
        }
    }
    #endregion

    #region events
    private void StartEvent()
    {
        isInEvent = true;

        int nextEvent = 0;
        if(force_event < 0) Random.Range(0, list_unusedEvents.Count);
        else nextEvent = force_event;

        currEvent = list_unusedEvents[nextEvent];//Instantiate(list_unusedEvents[nextEvent], Vector3.zero, Quaternion.identity);
        currEvent.SetActive(true);
        list_unusedEvents.RemoveAt(nextEvent);

        gameOverTime = currEvent.GetComponent<EventTrigger>().eventTime;
        timerText.text = gameOverTime.ToString("F2");
        timerText.color = clr_gameOverTime;
    }

    private void GameOver()
    {
        stopTimer = true;

        SceneManager.LoadScene("GameOver");
    }

    public void WinEvent()
    {
        currMinigame.SetActive(false);
        Destroy(currEvent);

        isInEvent = false;
        eventTime = 0f;
        timerText.text = (eventCD - eventTime).ToString("F2");
        timerText.color = clr_eventCD;

        if(list_unusedEvents.Count <= 0)
        {
            stopTimer = true;

            //win game
            SceneManager.LoadScene("WinScene");
        }
    }
    #endregion
}
