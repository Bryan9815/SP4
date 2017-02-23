using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayChar : MonoBehaviour {
    public Text HeroStats, HeroSecondStats;
    public Hero theHero;
	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {
        HeroStats.text = "Name: " + theHero.Get_HeroName()
                        + "\nLevel: " + theHero.Get_Level()
                        + "\nHealth: " + theHero.Get_MaxHp()
                        + "\nSP: " + theHero.GetSP()
                        + "\nAttack: " + theHero.GetAttack()
                        + "\nDefense: " + theHero.GetDefense();
        HeroSecondStats.text = "\nEvasion: " + theHero.Get_Evasion() + "%"
                             + "\nExp: " + theHero.Get_Exp()
                             + "\nExp To Next: " + theHero.Get_MaxExp()
                             + "\nCost: " + UpgradeHeroes.GetCost();
	}
}
