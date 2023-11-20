using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : Singleton<Player>, IPickUpable
{
    public class OnSelectedGunArg : EventArgs
    {
        public GunController gunController;
    }

    private Rigidbody2D rig;
    private TrailRenderer trailRenderer;

    // Event
    public event EventHandler<OnSelectedGunArg> OnSelectedGun;
    public event EventHandler OnChangeGun;

    //Properties
    [Header("Character properties")]
    [SerializeField] protected float characterSpeed;
    private bool isRunning;
    private bool isIdle;
    private bool facingRight = true;
    [Header("Gun layermask")]
    [SerializeField] private LayerMask gunLayerMask;

    // Start Gun
    [Header("Gun Current")]
    [SerializeField] private GameObject weaponCurrent;
    private GameObject weaponDetectived;
    private bool isCloseWeapon;

    //Dashing
    //[Header("Dashing")]
    //[SerializeField] private float dashSpeed;
    //[SerializeField] private float dashDuation;
    //[SerializeField] private float dashCooldown;
    //private bool canDash;
    //private bool isDashing;

    [Header("Reloading")]
    [SerializeField] private Transform reloadingObject;
    protected void Start()
    {
        //canDash = true;
        characterSpeed = DataManager.Instance.PlayerData.speed;
        rig = GetComponent<Rigidbody2D>(); 
        trailRenderer = GetComponent<TrailRenderer>();
        reloadingObject.gameObject.SetActive(false);
        GameInput.Instance.OnInteract += Instance_OnInteract;
        //GameInput.Instance.OnDashing += Instance_OnDashing;
    }

    //private void Instance_OnDashing(object sender, EventArgs e)
    //{
    //    if (canDash)
    //        rig.velocity = new Vector2(GameInput.Instance.GetInputNomalize().x * dashSpeed, GameInput.Instance.GetInputNomalize().y * dashSpeed);
    //    //StartCoroutine(Dash());
    //    //Debug.Log("dash");
    //   //rig.velocity = new Vector2(GameInput.Instance.GetInputNomalize().x * 500, GameInput.Instance.GetInputNomalize().y * 500);
    //}

    private void Instance_OnInteract(object sender, EventArgs e)
    {
        if(isCloseWeapon)
        {
            ChangeCurrentWeapon(weaponDetectived);
        }
    }
    private void Update()
    {
        //if (isDashing) return;
        DetivedGunController();
        
    }
    private void FixedUpdate()
    {
        //if (isDashing) return;
        HandleMovement();
    }
    protected virtual void HandleMovement()
    {
        Vector2 vector2Nomal = GameInput.Instance.GetInputNomalize();
        rig.velocity = new Vector2(vector2Nomal.x * characterSpeed, vector2Nomal.y * characterSpeed);
        isRunning = vector2Nomal != Vector2.zero;
        isIdle = vector2Nomal == Vector2.zero;
        // Check character facing
        if (facingRight && vector2Nomal == Vector2.left)
        {
            FaceFlip();
            facingRight = false;
        }
        if (!facingRight && vector2Nomal == Vector2.right)
        {
            FaceFlip();
            facingRight = true;
        };
    }
    protected virtual void FaceFlip()
    {
         Vector3 Scaler = transform.GetChild(0).localScale;
         Scaler.x = Scaler.x * -1;
         transform.GetChild(0).localScale = Scaler;    
    }
    public bool IsRunning()
    {
        return isRunning;
    } 
    public bool Isidle()
    {
        return isIdle;
    }
    protected virtual void DetivedGunController()
    {
        float interactDistance = 1.5f;
        Collider2D collider2D = Physics2D.OverlapCircle(transform.position, interactDistance, gunLayerMask);
        isCloseWeapon = collider2D;
        if (collider2D)
        {
            OnSelectedGun?.Invoke(this,new OnSelectedGunArg { gunController = collider2D.GetComponentInParent<GunController>()});
            if (collider2D.GetComponentInParent<GunController>())
            {
                weaponDetectived = collider2D.GetComponentInParent<GunController>().gameObject;
            }
        }
       
    }
    public WeaponItemsSO Weapon()
    {
        return weaponCurrent.GetComponent<GunController>().GetWeaponItemsSO();
    } 
    public GunController WeaponUsing()
    {
        return weaponCurrent.GetComponent<GunController>();
    }
    public bool CloseGun()
    {
        return isCloseWeapon;
    }
    public void ChangeCurrentWeapon(GameObject newWeapon)
    {
        OnChangeGun?.Invoke(this, EventArgs.Empty);
        weaponCurrent = newWeapon; 
        GunOnPlayer(newWeapon.GetComponentInChildren<LookatMouse>(), newWeapon.GetComponentInChildren<SelectedGun>());
    }
    private void GunOnPlayer(LookatMouse lookatMouse, SelectedGun selectedGun)//Called when Player Hold gun
    {
        lookatMouse.enabled = true;
        selectedGun.Hide();
        isCloseWeapon = !isCloseWeapon;
    }

    //private IEnumerator Dash()
    //{
    //    canDash = false;
    //    isDashing = true;
    //    trailRenderer.emitting = true;
    //    gameObject.layer = 0;
    //    rig.velocity = new Vector2(GameInput.Instance.GetInputNomalize().x * dashSpeed, GameInput.Instance.GetInputNomalize().y * dashSpeed);
    //    yield return new WaitForSeconds(dashDuation);
    //    isDashing = false;
    //    trailRenderer.emitting = false;
    //    yield return new WaitForSeconds(dashCooldown);
    //    canDash = true;
    //}
    public IEnumerator LoadingActive(float time, WeaponItemsSO weaponItemsSO)
    {
        if(weaponItemsSO == Weapon())
        {
            reloadingObject.gameObject.SetActive(true);
            yield return new WaitForSeconds(time);
            reloadingObject.gameObject.SetActive(false);
        }

    }

}
