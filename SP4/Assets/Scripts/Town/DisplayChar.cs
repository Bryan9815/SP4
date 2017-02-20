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
       //HeroStats.text  = "Name: " + theHero.GetHeroName()
       //                + "\nHealth: " + theHero.GetHealth()
       //                + "\nSP: " + theHero.GetSP()
       //                + "\nAttack: " + theHero.GetAttack()
       //                + "\nDefense: " + theHero.GetDefense()
       //                + "\nResistance: " + theHero.GetResistance();
       //HeroSecondStats.text = "Speed: " + theHero.GetSpeed()
       //                     + "\nAccuracy: " + theHero.GetAccuracy()
       //                     + "\nEvasion" + theHero.GetEvasion()
       //                     + "\nExp: " + theHero.GetExp()
       //                     + "\nExp To Next: " + theHero.GetMaxExp();
	}
}
