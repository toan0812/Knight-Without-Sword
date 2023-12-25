using UnityEngine;

public enum ItemsType
{
    Equipment, Buff, trading, Weapon,sup,special
}
public class ItemSO : ScriptableObject
{
    public Transform prefab;//prefab
    public Sprite prefabImage;// sprite of prefab
    public ItemsType type;// type of prefab
    public int count;
    public string prefabName;
    public int buffValue;
    [TextArea(0,10)]
    public string description;
}
