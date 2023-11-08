using UnityEngine;
using TMPro;

public class BulletsHolderUI : MonoBehaviour
{
    [Header("UI Text")]
    [SerializeField] private TextMeshProUGUI pistolBulletText;
    [SerializeField] private TextMeshProUGUI rocketBulletText;
    [SerializeField] private TextMeshProUGUI plasmaBulletText;
    [SerializeField] private TextMeshProUGUI shotgunBulletText;

    void Start()
    {
        pistolBulletText.text = DataManager.Instance.PlayerData.pistolAmmo.quatity.ToString();
        rocketBulletText.text = DataManager.Instance.PlayerData.rocketAmmo.quatity.ToString();
        plasmaBulletText.text = DataManager.Instance.PlayerData.plasmaAmmo.quatity.ToString();
        shotgunBulletText.text = DataManager.Instance.PlayerData.shotgunAmmo.quatity.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateBulletTextUI()
    {
        pistolBulletText.text = DataManager.Instance.PlayerData.pistolAmmo.quatity.ToString();
        rocketBulletText.text = DataManager.Instance.PlayerData.rocketAmmo.quatity.ToString();
        plasmaBulletText.text = DataManager.Instance.PlayerData.plasmaAmmo.quatity.ToString();
        shotgunBulletText.text = DataManager.Instance.PlayerData.shotgunAmmo.quatity.ToString();
    }
}
