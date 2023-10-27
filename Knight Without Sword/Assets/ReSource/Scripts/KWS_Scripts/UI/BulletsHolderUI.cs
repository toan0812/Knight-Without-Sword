using UnityEngine;
using TMPro;

public class BulletsHolderUI : MonoBehaviour
{
    [Header("UI Text")]
    [SerializeField] private TextMeshProUGUI pistolBulletText;
    [SerializeField] private TextMeshProUGUI rocketBulletText;
    [SerializeField] private TextMeshProUGUI plasmaBulletText;
    [SerializeField] private TextMeshProUGUI shotgunBulletText;

    private PlayerData playerData = new PlayerData();
    void Start()
    {
        pistolBulletText.text = playerData.pistolAmmo.quatity.ToString();
        rocketBulletText.text = playerData.rocketAmmo.quatity.ToString();
        plasmaBulletText.text = playerData.plasmaAmmo.quatity.ToString();
        shotgunBulletText.text = playerData.shotgunAmmo.quatity.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateBulletTextUI()
    {
        pistolBulletText.text = playerData.pistolAmmo.quatity.ToString();
        rocketBulletText.text = playerData.rocketAmmo.quatity.ToString();
        plasmaBulletText.text = playerData.plasmaAmmo.quatity.ToString();
        shotgunBulletText.text = playerData.shotgunAmmo.quatity.ToString();
    }
}
