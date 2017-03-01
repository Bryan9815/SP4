using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayWeapon : MonoBehaviour 
{
    public Text weaponStats, costToLevel;
    BaseWeapon weaponDisplayed;
	// Use this for initialization
	void Start () 
    {
		weaponDisplayed = gameObject.GetComponent<BaseWeapon>();
	}
	
	// Update is called once per frame
	void Update () 	
    {
        displayEquipment();
	}

    void displayEquipment()
    {
		weaponStats.text =  "Name: " + weaponDisplayed.Get_Name()
			+ "\nAttack: " + weaponDisplayed.Get_Attack()
			+ "\nLevel: " +weaponDisplayed.Get_Level();
        costToLevel.text = "Cost: " + UpgradeEquipment.theCostToLevelUp;
    }
}
