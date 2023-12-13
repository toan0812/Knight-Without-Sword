using UnityEngine;

public enum PlayerType {
    Knight, Wizzard

}
[CreateAssetMenu()]
public class PlayerSO : ScriptableObject
{
    public Transform prefab;//prefab
    public Sprite prefabImage;// sprite of prefab
    public PlayerType type;// type of prefab
    public GameObject Prefab;
    [TextArea(0, 10)]
    public string description;

}
