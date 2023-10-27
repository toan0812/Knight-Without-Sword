using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]private GunHoderUI gunHoderUI;
    public GunHoderUI GunHoderUI => gunHoderUI;
    [SerializeField] private HeaderUI headerUI;
    public HeaderUI HeaderUI => headerUI;

    private void Reset()
    {
        LoadComponent();
    }

    void LoadComponent()
    {
        LoadGunHodelUI();
        LoadGoldUI();
    }

    void LoadGunHodelUI()
    {
        if (gunHoderUI != null) return;
        gunHoderUI = GameObject.FindAnyObjectByType<GunHoderUI>();
    }  
    void LoadGoldUI()
    {
        if (headerUI != null) return;
        headerUI = GameObject.FindAnyObjectByType<HeaderUI>();
    }
}
