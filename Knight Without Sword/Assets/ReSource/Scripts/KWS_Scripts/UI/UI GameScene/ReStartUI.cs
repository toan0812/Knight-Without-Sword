using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReStartUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Button restartBtn;
    [SerializeField] private Button menuBtn;
    void Start()
    {
        restartBtn.onClick.AddListener(() => {
            SceneManager.LoadScene("GameScene");
        });
        menuBtn.onClick.AddListener(() => {
            Time.timeScale = 1;
            SceneManager.LoadScene("MenuScene");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
