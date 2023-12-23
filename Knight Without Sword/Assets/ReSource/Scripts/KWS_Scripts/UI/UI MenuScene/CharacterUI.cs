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
    private bool isBuyed;
    private int selectedOption = -1;
    private int isBuy = -1;
    private void Awake()
    {
        selectCharacterUI = GetComponentInParent<SelectCharacterUI>();
        btnText = btnUse.GetComponentInChildren<Text>();
    }
    private void Start()
    {
        selectCharacterUI.OnCharacterUsing += SelectCharacterUI_OnCharacterUsing;
        if (!PlayerPrefs.HasKey("PlayerID"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }

        btnUse.onClick.AddListener(() =>
        {
            BuyItemByGem((int)characterSO.price);
        });

    }
    private void OnDisable()
    {
        selectCharacterUI.OnCharacterUsing -= SelectCharacterUI_OnCharacterUsing;
    }

    private void SelectCharacterUI_OnCharacterUsing(object sender, SelectCharacterUI.OnChangeCharacterUsing e)
    {
        if(e.PlayerSO == characterSO && isBuyed == true)
        {
            selectedOption = characterSO.PlayerID;
            state = BtnState.Using;

        }
        if(e.PlayerSO != characterSO && isBuyed == true)
        {
            state = BtnState.Buyed;
        }
        if(e.PlayerSO != characterSO && isBuyed == false)
        {
            state = BtnState.Buying;
        }
    }

   private void Update()
   {

        switch (state)
        {
            case BtnState.Buying:
                btnText.text = characterSO.price.ToString();
                if (characterSO.price == 0)
                {
                    btnText.text = "FREE";
                }

                btnUse.onClick.AddListener(() =>
                {
                    state = BtnState.Buyed;
                    isBuy = 1;
                });
                break; 
            case BtnState.Buyed:
                {
                    isBuyed = true;
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
                break; 
            case BtnState.Using:
                {
                    btnUse.enabled = false;
                    btnText.text = "USING";
                    isBuyed = true;
                    btnUse.onClick.RemoveAllListeners();
                }
                break;
        }
   }
    public void Load()
    {
        selectedOption = PlayerPrefs.GetInt("PlayerID");
        isBuy = PlayerPrefs.GetInt("IsBuyed");
        if (selectedOption == characterSO.PlayerID)
        {
            state = BtnState.Using;
            selectCharacterUI.SelectedCharacter(characterSO);
        }
        if(selectedOption != characterSO.PlayerID && isBuy == 1)
        {
            state = BtnState.Buyed;
            isBuyed = true;
        }
        if(selectedOption != characterSO.PlayerID && isBuy != 1)
        {
            state = BtnState.Buying;
            isBuyed = false;
        }
        
    }

    public void BuyItemByGem(int price)
    {
        if (DataManager.Instance.PlayerData.gem >= price)
        {
            DataManager.Instance.PlayerData.gem -= price;
            DataManager.Instance.SaveData();
            DataField.Instance.LoadData();
        }
        else
        {
            Debug.Log("can not buy item");
        }
    }
    public void Save()
    {
        PlayerPrefs.SetInt("PlayerID", selectCharacterUI.GetPlayerSO().PlayerID);
        PlayerPrefs.SetInt("IsBuyed", 1);
    }
    public PlayerSO GetPlayerSO() {
        return characterSO;
    }
}
