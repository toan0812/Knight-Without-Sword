using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DashAbility : CharactersAbility
{
    [Header("Dashing")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuation;
    [SerializeField] private float dashCooldown;
    public bool canDash = true;
    private bool isDashing;
    public override void Activate()
    {
        if (canDash)
        {
            canDash = false;
            isDashing = true;
            Player.Instance.GetComponent<TrailRenderer>().emitting = true;
            Player.Instance.gameObject.layer = 0;
            Player.Instance.GetComponent<Rigidbody2D>().velocity = new Vector2(GameInput.Instance.GetInputNomalize().x * dashSpeed, GameInput.Instance.GetInputNomalize().y * dashSpeed);
        }
        else return;
        
    }
    public override void BeginCoolDown()
    {
        isDashing = false;
        Player.Instance.gameObject.layer = 10;
        Player.Instance.GetComponent<TrailRenderer>().emitting = false;
        canDash = true;
    }
    //private IEnumerator Dash()
    //{
    //    canDash = false;
    //    isDashing = true;
    //    Player.Instance.GetComponent<TrailRenderer>().emitting = true;
    //    Player.Instance.gameObject.layer = 0;
    //    Player.Instance.GetComponent<Rigidbody2D>().velocity = new Vector2(GameInput.Instance.GetInputNomalize().x * dashSpeed, GameInput.Instance.GetInputNomalize().y * dashSpeed);
    //    yield return new WaitForSeconds(dashDuation);
    //    isDashing = false;
    //    Player.Instance.GetComponent<TrailRenderer>().emitting = false;
    //    yield return new WaitForSeconds(dashCooldown);
    //    canDash = true;
    //}
}
