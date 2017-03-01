using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwitchWeapons : MonoBehaviour {
    public Image heroSprite;
    public Text heroStatDisplay;
    public int WeaponID, slot;
    public bool Active;
    private bool ImageSet = false;
    // Use this for initialization
    void Start () 
    {
        if (gameObject.GetComponent<Toggle>().group.name == "Hero1Weapon")
            Active = true;
        else
            Active = false;
    
        if (Active)
        {
            switch (slot)
            {
                case 1:
                    WeaponID = PlayerPrefs.GetInt("Hero1Weapon", 1);
                    break;
                case 2:
                    WeaponID = PlayerPrefs.GetInt("Hero2Weapon", 2);
                    break;
                case 3:
                    WeaponID = PlayerPrefs.GetInt("Hero3Weapon", 3);
                    break;
                default:
                    break;
            }
        }
    }
	
    // Update is called once per frame
    //void Update()
    //{
    //    if (!ImageSet)
    //    {
    //        GlobalVariable.GetHero(WeaponID).GetComponent<BaseWeapon>();
    //        ImageSet = true;
    //    }
    //    heroSprite.sprite = GlobalVariable.GetHero(WeaponID).GetComponent<BaseWeapon>().GetSprite();
    //
    //    if (!Active)
    //        heroStatDisplay.text = GlobalVariable.PrintRecordHeroStats(WeaponID);
    //}
}
