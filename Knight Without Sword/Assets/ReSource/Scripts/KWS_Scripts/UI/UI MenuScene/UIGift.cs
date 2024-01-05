using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UIGift : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private GiftBoxUI giftBoxUI;
    [Header("UI")]
    [SerializeField] private Button giftButton;
    [SerializeField] private GameObject gitfClamp;
    [SerializeField] private Text timeText;
    private float timeRemaining = 60f;
    public bool timerIsRunning;
    void Start()
    {
        timerIsRunning = true;
        giftButton.enabled = false;
        giftButton.onClick.AddListener(() =>
        {
            giftBoxUI.gameObject.SetActive(true);
        });
        giftBoxUI.OnClickBtn += GiftBoxUI_OnClickBtn;
    }

    private void GiftBoxUI_OnClickBtn(object sender, System.EventArgs e)
    {
        ResetTime();
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
                giftButton.enabled = true;
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
    public void ResetTime()
    {
        if (timerIsRunning == false)
        {
            timeRemaining = 60;
            timerIsRunning = true;
            gitfClamp.SetActive(false);
        }
    }    
}
