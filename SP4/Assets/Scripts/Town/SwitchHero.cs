using UnityEngine;
using UnityEngine.UI;
using UnityEditorInternal;
using System.Collections;
using System.Linq;

public class SwitchHero : MonoBehaviour {
    PLACEHOLDER lol;
    private Toggle EquippedHero;
    private Toggle UnEquippedHero;
    public ToggleGroup EquippedHeroes, UnEquippedHeroes;
	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        EquippedHero.GetComponent<Text>().text = lol.name;
        Toggle active = ToggleGroupExtension.GetActive(EquippedHeroes);
        Toggle active2 = ToggleGroupExtension.GetActive(UnEquippedHeroes);
        if (active && active2)
        {
            EquippedHero = active2;
            active2.isOn = false;
            EquippedHero.group = EquippedHeroes;
            UnityEditorInternal.ComponentUtility.CopyComponent(EquippedHero);
            UnityEditorInternal.ComponentUtility.PasteComponentValues(active);
            active.isOn = false;
        }
	}
}

public static class ToggleGroupExtension
{
    public static Toggle GetActive(this ToggleGroup aGroup)
    {
        return aGroup.ActiveToggles().FirstOrDefault();
    }
}