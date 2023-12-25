using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    [SerializeField] private SelectCharacterUI selectCharacterUI;
    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime =1f;
    public void LoadNextLevel()
    {
        if (selectCharacterUI != null && selectCharacterUI.GetPlayerSO().prefab.gameObject)
        {
            
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
        else
        {
            Debug.Log("You do not select your character");
        }

    }

    IEnumerator LoadLevel(int LevelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(LevelIndex);
    }
}
