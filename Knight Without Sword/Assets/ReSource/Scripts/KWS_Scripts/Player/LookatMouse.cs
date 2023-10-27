using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatMouse : MonoBehaviour
{
    bool gunDirectionUp = false;
    private void Update()
    {
        transform.position = Player.Instance.transform.position;
        LookAtMouse();
    }
    private void LookAtMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector3 direction = mousePos.normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0,angle);
        if (!gunDirectionUp && angle < -100)
        {
            Flip(angle);
            gunDirectionUp = true;

        }
        if (gunDirectionUp && angle < 90 && angle > 0)
        {
            Flip(angle);
            gunDirectionUp = false;
        }
    }
    private void Flip(float angle)
    {
        Vector3 Scaler = transform.localScale;
        Scaler.y = Scaler.y * -1;
        transform.localScale = Scaler;
    }

}
