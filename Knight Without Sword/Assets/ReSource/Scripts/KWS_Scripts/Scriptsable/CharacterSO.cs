using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class CharacterSO : ScriptableObject
{
    public PlayerSO[] playeSOs;
    public GameObject GetCharacter(int index)
    { return playeSOs[index].prefab.gameObject; }
}
