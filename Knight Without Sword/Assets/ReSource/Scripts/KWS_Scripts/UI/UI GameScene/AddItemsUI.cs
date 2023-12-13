using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AddItemsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI plusText;
    [SerializeField] private TextMeshProUGUI quantityItemsText;
    [SerializeField] private Image itemImage;
    public void ChangeImageItem(ItemSO itemsSO)
    {
        plusText.text = "+";
        quantityItemsText.text = itemsSO.count.ToString();
        itemImage.sprite = itemsSO.prefabImage;

    }
}
