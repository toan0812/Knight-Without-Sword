using System;
using UnityEngine;

public class GameInput : Singleton<GameInput>
{
    private PlayerActions inputActions;
    public event EventHandler Onshoot;
    public event EventHandler OnInteract;
    public event EventHandler OnDashing;
    public event EventHandler OnReloading;
    public event EventHandler OnPause;
    private void Awake()
    {
        inputActions = new PlayerActions();
        inputActions.PlayerAction.Enable();
        inputActions.PlayerAction.interact.performed += Interact_performed;
        inputActions.PlayerAction.Dash.performed += Dash_performed;
        inputActions.PlayerAction.Reload.performed += Reload_performed;
        inputActions.PlayerAction.Pause.performed += Pause_performed;
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Pause");
        OnPause?.Invoke(this, EventArgs.Empty);
    }

    private void Reload_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnReloading?.Invoke(this, EventArgs.Empty);
    }

    private void Dash_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnDashing?.Invoke(this, EventArgs.Empty);
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Onshoot?.Invoke(this, EventArgs.Empty);
        }
    }
    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteract?.Invoke(this, EventArgs.Empty);
    }
    public Vector2 GetInputNomalize()
    {
        Vector2 inputVector = inputActions.PlayerAction.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }

}
