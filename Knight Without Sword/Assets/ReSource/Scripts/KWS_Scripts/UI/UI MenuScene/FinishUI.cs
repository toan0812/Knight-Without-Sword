using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UIElements;

public class FinishUI : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button MenuBtn;
    [SerializeField] Transform Field;
    [SerializeField] Transform endPos;
    private int completedID;
    private void OnEnable()
    {
        Field.transform.DOMove(endPos.position, .5f).SetUpdate(true);
    }
    void Start()
    {
        Time.timeScale = 0;
        MenuBtn.onClick.AddListener(() => {
            completedID++;
            PlayerPrefs.SetInt("CompletedMapID", completedID);
            SceneManager.LoadScene(0); });
    }
}
