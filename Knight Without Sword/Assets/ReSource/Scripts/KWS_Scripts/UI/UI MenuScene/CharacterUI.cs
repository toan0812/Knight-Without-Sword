using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    [SerializeField] private PlayerFieldUI playerFieldUI;
    [Header("SO")]
    [SerializeField] public PlayerSO characterSO;
    [Header("UI")]
    [SerializeField] private Button btnUse;
    
    private void Start()
    {
        btnUse.enabled = false;
        btnUse.onClick.AddListener(() => {
        });

    }
}
