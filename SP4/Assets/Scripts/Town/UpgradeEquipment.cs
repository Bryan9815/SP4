using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeEquipment : MonoBehaviour
{
    public Button buyButton;
    float timer = 1.0f;
    public static int theCostToLevelUp;
    BaseWeapon thatWeapon;
    // Use this for initialization
    void Start()
    {
        thatWeapon = buyButton.GetComponent<BaseWeapon>();
        theCostToLevelUp = thatWeapon.Get_Level() * 50;
        buyButton.onClick.AddListener(delegate
        {
            Money.playerGold -= theCostToLevelUp;
            thatWeapon.LevelUp();
            buyButton.interactable = false;
            theCostToLevelUp = thatWeapon.Get_Level() * 50;
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (Money.playerGold < theCostToLevelUp || thatWeapon.Get_Level() == thatWeapon.Get_MaxLevel())
        {
            buyButton.interactable = false;
        }
        else if (Money.playerGold >= theCostToLevelUp)
        {
            buyButton.interactable = true;
        }
    }
}
