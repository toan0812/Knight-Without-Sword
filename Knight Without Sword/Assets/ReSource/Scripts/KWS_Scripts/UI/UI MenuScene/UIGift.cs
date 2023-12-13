using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UIGift : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Button giftButton;
    [SerializeField] private GameObject gitfClamp;
    [SerializeField] private Text timeText;
    private float timeRemaining = 60f;
    public bool timerIsRunning;
    void Start()
    {
        timerIsRunning = true;
        giftButton.onClick.AddListener(() =>
        {
            ReciveGift();
        });
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timerIsRunning = false;
            }
        }
        else
        {
            gitfClamp.SetActive(true);
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
    }

    private void ReciveGift()
    {
        if(timerIsRunning == false)
        {
            timeRemaining = 60;
            timerIsRunning = true;
            gitfClamp.SetActive(false);
        }

    }
}
