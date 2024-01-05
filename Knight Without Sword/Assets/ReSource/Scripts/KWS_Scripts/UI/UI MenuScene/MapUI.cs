using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapUI : MonoBehaviour
{
    private enum btnState { Playing, Completed}
    [SerializeField] private SelectCharacterUI selectCharacterUI;
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private Button startBtn;
    [SerializeField]private int IdMap = 1;
    private btnState state;
    private void Awake()
    {
        selectCharacterUI = GameObject.FindAnyObjectByType<SelectCharacterUI>();
        levelLoader = GameObject.FindAnyObjectByType<LevelLoader>();
    }
    private void Start()
    {
        //if (PlayerPrefs.GetInt("IsBuyed") == IdMap)
        //{
        //    state = btnState.Completed;
        //}
        startBtn.onClick.AddListener(() => { LoadNextLevel();});

    }

    private void Update()
    {
        //switch (state)
        //{
        //    case btnState.Playing:
        //        {
        //            startBtn.enabled = true;
        //            startBtn.GetComponentInChildren<Text>().text = "START";
        //        }
        //        break;
        //    case btnState.Completed:
        //        {
        //            startBtn.GetComponentInChildren<Text>().text = "COMPLETED";
        //            startBtn.enabled = false;
        //        }
        //        break;
        //}

    }
    public void LoadNextLevel()
    {
        if (selectCharacterUI != null && selectCharacterUI.GetPlayerSO().prefab.gameObject)
        {
            StartCoroutine(levelLoader.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
        else
        {
            Debug.Log("You do not select your character");
        }

    }

}
