using UnityEngine;
using UnityEngine.UI;
public class ButtonUI : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] bool isChangingColor;
    void Start()
    {
        if (isChangingColor)
        {
            GetComponent<Button>().Select();
        }
        GetComponent<Button>().onClick.AddListener(() =>
        {
            
        });
    }
}
