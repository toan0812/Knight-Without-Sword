using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCharacter : MonoBehaviour
{
    private int selectedOption = -1;
    [SerializeField] CharacterSO characterSO;
    [SerializeField] private Transform characterPrent;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("PlayerID"))
        {
            selectedOption = -1;
        }
        else
        {
            Load();
        }
        SpawnCharacter(selectedOption);
    }
    private void SpawnCharacter(int ID)
    {
        var charater = Instantiate(characterSO.GetCharacter(ID));
        charater.transform.SetParent(characterPrent);
        charater.transform.position = characterPrent.position;
    }
    public void Load()
    {
        selectedOption = PlayerPrefs.GetInt("PlayerID");
    }
}
