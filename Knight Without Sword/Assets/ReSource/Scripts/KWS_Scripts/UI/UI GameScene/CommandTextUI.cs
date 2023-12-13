using TMPro;
using UnityEngine;

public class CommandTextUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    public void ChangeCommandText(int textChanged)
    {
        text.text = textChanged.ToString();
    }
}
