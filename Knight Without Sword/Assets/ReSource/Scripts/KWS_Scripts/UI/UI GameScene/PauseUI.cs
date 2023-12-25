using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;
using System.Collections;
public class PauseUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Button resumeBtn;
    [SerializeField] private Button menuBtn;
    [Header("Prefabs")]
    [SerializeField] private Transform pauseField;
    [Header("DOMove")]
    [SerializeField] private Transform endPos;
    [SerializeField] private Transform startPos;
    [SerializeField] private Ease ease;
    [SerializeField] float timeDuration;

    private void Start()
    {
        startPos = pauseField.transform;
        GameInput.Instance.OnPause += Instance_OnPause;
        
        resumeBtn.onClick.AddListener(() => {
            pauseField.transform.DOMove(startPos.position, timeDuration).SetEase(ease).SetUpdate(true);
            Time.timeScale = 1; });
        menuBtn.onClick.AddListener(() => { Time.timeScale = 1; 
            SceneManager.LoadScene("MenuScene"); });

    }
    private void Instance_OnPause(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
        pauseField.transform.DOMove(endPos.position, timeDuration).SetEase(ease).SetUpdate(true);
    }

}
