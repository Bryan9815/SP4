using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class SwitchHeroes : MonoBehaviour
{
    public ToggleGroup EquippedHeroes, UnEquippedHeroes;
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
            if (active && active2)
            {
                if (active.isOn && active2.isOn)
                    bothSelected = true;
            }
        }
        //else if (Swap)
            //SwapValues();
        if (bothSelected)
            Swap();
    }

    void Swap()
    {
        Toggle temp1 = Instantiate(active);
        Hero tempEquip = temp1.GetComponent<Hero>();
        Toggle temp2 = Instantiate(active2);
        Hero tempUnequip = temp2.GetComponent<Hero>();
        //tempUnequip = active2.GetComponent<Hero>();
        bothSelected = false;
        
        active.isOn = false;
        active2.isOn = false;
        
        UnityEditorInternal.ComponentUtility.CopyComponent(tempEquip);
        UnityEditorInternal.ComponentUtility.PasteComponentValues(active2.GetComponent<Hero>());
        UnityEditorInternal.ComponentUtility.CopyComponent(tempUnequip);
        UnityEditorInternal.ComponentUtility.PasteComponentValues(active.GetComponent<Hero>());
        
        DestroyImmediate(temp1);
        DestroyImmediate(temp2);
    }

    //void SwapValues()
    //{
    //    UnityEditorInternal.ComponentUtility.CopyComponent(tempEquip);
    //    UnityEditorInternal.ComponentUtility.PasteComponentValues(active2.GetComponent<Hero>());
    //    UnityEditorInternal.ComponentUtility.CopyComponent(tempUnequip);
    //    UnityEditorInternal.ComponentUtility.PasteComponentValues(active.GetComponent<Hero>());

    //    Destroy(tempEquip);
    //    Destroy(tempUnequip);

    //    Swap = false;
    //}
}
public static class ToggleGroupExtension
{
    public static Toggle GetActive(this ToggleGroup aGroup)
    {
        return aGroup.ActiveToggles().FirstOrDefault();
    }
}

