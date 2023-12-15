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
    [Header("SO")]
    [SerializeField] public PlayerSO characterSO;
    [Header("UI")]
    [SerializeField] private Button btnUse;
    private Text btnText;
    private BtnState state;
    private bool IsBuyed;
    private void Awake()
    {
        selectCharacterUI = GetComponentInParent<SelectCharacterUI>();
        btnText = btnUse.GetComponentInChildren<Text>();
    }
    private void Start()
    {
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
            state = BtnState.Using;
        }
        if(e.PlayerSO != characterSO && IsBuyed)
        {
            Debug.Log("Buyed");
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
                btnText.text = characterSO.price.ToString();
                
                btnUse.onClick.AddListener(() =>
                {
                    state = BtnState.Buyed;

                });
                break; 
            case BtnState.Buyed:
                {
                    IsBuyed = true;
                    btnUse.enabled = true;
                    btnText.text = "USE";
                    btnUse.onClick.RemoveAllListeners();
                    btnUse.onClick.AddListener(() => {
                            state = BtnState.Using;
                        selectCharacterUI.SelectedCharacter(characterSO);
                    });
                }
                break; 
            case BtnState.Using:
                {
                    btnUse.enabled = false;
                    btnText.text = "USING";
                    btnUse.onClick.RemoveAllListeners();
                    //selectCharacterUI.SelectedCharacter(characterSO);
                }
                break;
        }
    }
}
