using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    private enum BtnState { Buying, Buyed,Using}
    [SerializeField] private SelectCharacterUI selectCharacterUI;
    [SerializeField] private ButtonBuyCharacterUI buttonBuyCharacterUI;
    [Header("SO")]
    [SerializeField] public PlayerSO characterSO;
    [Header("UI")]
    [SerializeField] private Button btnUse;
    private Text btnText;
    private BtnState state;
    private bool IsBuyed;

    private int selectedOption = 0;
    private void Awake()
    {
        selectCharacterUI = GetComponentInParent<SelectCharacterUI>();
        buttonBuyCharacterUI = GetComponentInChildren<ButtonBuyCharacterUI>();
        btnText = btnUse.GetComponentInChildren<Text>();
    }
    private void Start()
    {
       if (!PlayerPrefs.HasKey("PlayerID"))
       {
           selectedOption = 0;
       }
       else
       {
            Load();
       }
        state = BtnState.Buying;
        IsBuyed = false;
        selectCharacterUI.OnCharacterUsing += SelectCharacterUI_OnCharacterUsing;
    }
    private void OnDisable()
    {
        selectCharacterUI.OnCharacterUsing -= SelectCharacterUI_OnCharacterUsing;
    }

    private void SelectCharacterUI_OnCharacterUsing(object sender, SelectCharacterUI.OnChangeCharacterUsing e)
    {
        if(e.PlayerSO == characterSO && IsBuyed)
        {
            Debug.Log("using");
            selectedOption++;
            state = BtnState.Using;
        }
        if(e.PlayerSO != characterSO && IsBuyed)
        {
            Debug.Log("Buyed");
            selectedOption = 0;
            state = BtnState.Buyed;
        }
        if(e.PlayerSO != characterSO && !IsBuyed)
        {
            Debug.Log("Buying");
            state = BtnState.Buying;
        }
    }

    private void Update()
    {
        switch (state)
        {
            case BtnState.Buying:
                if (characterSO.price == 0)
                {
                    btnText.text = "FREE";
                }
                btnText.text = characterSO.price.ToString();
                
                btnUse.onClick.AddListener(() =>
                {
                    state = BtnState.Buyed;
                });
                break; 
            case BtnState.Buyed:
                {
                    if (buttonBuyCharacterUI.CanBuyItem())
                    {
                        IsBuyed = true;
                        btnUse.enabled = true;
                        btnText.text = "USE";
                        btnUse.onClick.RemoveAllListeners();
                        btnUse.onClick.AddListener(() =>
                        {
                            state = BtnState.Using;
                            selectCharacterUI.SelectedCharacter(characterSO);
                            Save();

                        });
                    }
                }
                break; 
            case BtnState.Using:
                {
                    btnUse.enabled = false;
                    btnText.text = "USING";
                    btnUse.onClick.RemoveAllListeners();
                }
                break;
        }
    }


    public void Load()
    {
        selectedOption = PlayerPrefs.GetInt("PlayerID");
    }
    public void Save()
    {
        PlayerPrefs.SetInt("PlayerID", selectCharacterUI.GetPlayerSO().PlayerID);
    }
    public PlayerSO GetPlayerSO() {
        return characterSO;
    }

}
