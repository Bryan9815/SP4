using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class WeaponSelect : MonoBehaviour
{
    public ToggleGroup EquippedHeroes;
    public List<GameObject> WeaponListo = new List<GameObject>();
    public static List<BaseWeapon> theWeapons = new List<BaseWeapon>();

    public GameObject slot;
    // Use this for initialization
    void Awake()
    {
        theWeapons.Add(Resources.Load<BaseWeapon>("Equipment/Weapons/TestWeapon1"));
        theWeapons.Add(Resources.Load<BaseWeapon>("Equipment/Weapons/StandardSword"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backToTownAgain()
    {
        SceneManager.LoadScene("Town");
    }
}