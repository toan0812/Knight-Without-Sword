using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManager : Singleton<GameManager>
{
    [Header("Component")]
    [SerializeField] private GiftBoxUI giftBoxUI;
    //[SerializeField] private FinishUI finishUI;

    private void Start()
    {
        Time.timeScale = 1.0f;
        //if (finishUI != null)
        //{
        //    giftBoxUI.OnClickBtn += GiftBoxUI_OnClickBtn;
        //}
        
    }

    //private void GiftBoxUI_OnClickBtn(object sender, EventArgs e)
    //{
    //    finishUI.gameObject.SetActive(true);
    //}
}
