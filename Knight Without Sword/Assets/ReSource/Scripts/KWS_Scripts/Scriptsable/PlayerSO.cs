using UnityEngine;

public enum PlayerType {
    Knight, Wizzal

}
[CreateAssetMenu()]
public class PlayerSO : ScriptableObject
{
    public Transform prefab;//prefab
    public Sprite prefabImage;// sprite of prefab
    public PlayerType type;// type of prefab
    [TextArea(0, 10)]
    public string description;

}
