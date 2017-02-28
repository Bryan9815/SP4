using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayWeapon : MonoBehaviour 
{
    public Text weaponStats;
    int slotID;
    BaseWeapon weaponDisplayed;
	// Use this for initialization
	void Start () 
    {
        weaponDisplayed = Resources.Load<BaseWeapon>("Equipment/Weapons/TestWeapon1");
	}
	
	// Update is called once per frame
	void Update () 
    {
        displayEquipment();
	}

    void displayEquipment()
    {
        //weaponStats.text =  "Name: " + weaponDisplayed.Get_Name()
        //                    + "\nAttack: " + weaponDisplayed.Get_Attack()
        //                    + "\nLevel: " + weaponDisplayed.Get_Level();
    }
}
