﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class SwitchHeroes : MonoBehaviour
{
    public ToggleGroup EquippedHeroes, UnEquippedHeroes;
    GameObject Equipped, Unequipped;
    Toggle active, active2;
    bool bothSelected = false;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!bothSelected)
        {
            if (!active)
                active = ToggleGroupExtension.GetActive(EquippedHeroes);
            if (!active2)
                active2 = ToggleGroupExtension.GetActive(UnEquippedHeroes);
            
            if (active && !active.isOn)
            {
                active.GetComponent<HeroSelector>().ActiveHeroUnselected();
                active = null;
            }
            else if(active && active.isOn)
                active.GetComponent<HeroSelector>().ActiveHeroSelected();
            if (active2 && !active2.isOn)
                active2 = null;
            
            if (active && active2)
            {
                if (active.isOn && active2.isOn)
                    bothSelected = true;
            }
        }
        else if (bothSelected)
            Swap();
    }

    void Swap()
    {
        Equipped = GameObject.Find(active.name);
        Unequipped = GameObject.Find(active2.name);
        GameObject temp1 = Instantiate(Equipped);
        HeroSelector tempEquip = temp1.GetComponent<HeroSelector>();
        GameObject temp2 = Instantiate(Unequipped);
        HeroSelector tempUnequip = temp2.GetComponent<HeroSelector>();

        HeroSelector unEQ = Unequipped.GetComponent<HeroSelector>();
        HeroSelector EQ = Equipped.GetComponent<HeroSelector>();

        bothSelected = false;

        active.GetComponent<HeroSelector>().ActiveHeroUnselected();
        active.isOn = false;
        active2.isOn = false;

        unEQ.HeroID = tempEquip.HeroID;
        GlobalVariable.SetPlayerHeroID(unEQ.slot, unEQ.HeroID, unEQ.Active);
        EQ.HeroID = tempUnequip.HeroID;
        GlobalVariable.SetPlayerHeroID(EQ.slot, EQ.HeroID, EQ.Active);

        //CopyHeroComponent(tempEquip, Unequipped);
        //CopyHeroComponent(tempUnequip, Equipped);
        
        DestroyImmediate(temp1);
        DestroyImmediate(temp2);

        active = null;
        active2 = null;
    }

    Component CopyHeroComponent(Component original, GameObject destination)
    {
        System.Type type = original.GetType();
        if(destination.GetComponent<Hero>())
        {
            Destroy(destination.GetComponent<Hero>());
        }
        Component copy = destination.AddComponent(type);
        // Copied fields can be restricted with BindingFlags
        System.Reflection.FieldInfo[] fields = type.GetFields();
        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(copy, field.GetValue(original));
        }
        return copy;
    }
}
public static class ToggleGroupExtension
{
    public static Toggle GetActive(this ToggleGroup aGroup)
    {
        return aGroup.ActiveToggles().FirstOrDefault();
    }
}

