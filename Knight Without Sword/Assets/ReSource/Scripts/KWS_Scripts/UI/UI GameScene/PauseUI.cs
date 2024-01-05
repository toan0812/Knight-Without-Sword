using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Button resumeBtn;
    [SerializeField] private Button menuBtn;
    [SerializeField] private Image background;
    [Header("Prefabs")]
    [SerializeField] private Transform pauseField;
    [Header("DOMove")]
    [SerializeField] private Transform endPos;
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Ease ease;
    [SerializeField] float timeDuration;
    private void Awake()
    {
        startPos = pauseField.transform.position;
    }
    private void OnEnable()
    {
        Pause();
    }
    private void Start()
    {
        GameInput.Instance.OnPause += Instance_OnPause;
        
        resumeBtn.onClick.AddListener(() => {
            pauseField.transform.DOMove(startPos, timeDuration).SetEase(ease).SetUpdate(true);
            Time.timeScale = 1;
            background.gameObject.SetActive(false);
        });
        menuBtn.onClick.AddListener(() => { Time.timeScale = 1; 
            SceneManager.LoadScene("MenuScene"); });

    }

    private void Pause()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
        background.gameObject.SetActive(true);
        pauseField.transform.DOMove(endPos.position, timeDuration).SetEase(ease).SetUpdate(true);
    }
    private void Instance_OnPause(object sender, System.EventArgs e)
    {
        Pause();
    }

}
