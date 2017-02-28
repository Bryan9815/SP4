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
    public List<BaseWeapon> theWeapons = new List<BaseWeapon>();
    GameObject Equipped, Unequipped;
    Toggle active, active2;

    GUIContent content;

    public GameObject slot;
    // Use this for initialization
    void Start()
    {
        theWeapons.Add(Resources.Load<BaseWeapon>("Equipment/Weapons/TestWeapon1"));
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