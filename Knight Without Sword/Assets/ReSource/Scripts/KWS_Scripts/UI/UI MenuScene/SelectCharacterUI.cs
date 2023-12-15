using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SelectCharacterUI : MonoBehaviour
{
    public class OnChangeCharacterUsing : EventArgs
    { public PlayerSO PlayerSO; }
    public event EventHandler<OnChangeCharacterUsing> OnCharacterUsing;
    [SerializeField] PlayerSO characterIsUsing;
    public void SelectedCharacter(PlayerSO playerSO)
    {
        this.characterIsUsing = playerSO;
        OnCharacterUsing?.Invoke(this, new OnChangeCharacterUsing { PlayerSO = playerSO });
    }


}
