using UnityEngine;
using UnityEngine.EventSystems;
public class ButtonScrollView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isDown = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        isDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDown = false;
    }
}
