using UnityEngine;

public class SelectedGun : MonoBehaviour
{
    [Header("Selected")]
    [SerializeField] private GunController gunController;
    public GameObject hand;
    [SerializeField] private GameObject[] selectedModels;
    public GameObject shadow;
    void Start()
    {
        hand.SetActive(false);  
        Player.Instance.OnSelectedGun += Instance_OnSelectedGun;
    }

    private void Instance_OnSelectedGun(object sender, Player.OnSelectedGunArg e)
    {
        if (gunController.GetWeaponItemsSO() != Player.Instance.Weapon() && e.gunController == gunController)
        {
            Show();
        }
    }

    private void Update()
    {
       if(!Player.Instance.CloseGun())
        {
            Hide();
        }
    }
    public void Show()
    {
        foreach (GameObject selectedModel in selectedModels)
        {
            selectedModel.SetActive(true);
        }

    }
    public void Hide()
    {
        foreach (GameObject selectedModel in selectedModels)
        {
            selectedModel.SetActive(false);
        }
    }
}
