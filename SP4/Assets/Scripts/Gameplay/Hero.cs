using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hero : MonoBehaviour {
    protected static float hp,Attack,Defense, Resistance, Speed, Accuracy, Evasion;
    protected static Image hero;
    protected int sp;
    protected static string name;
    protected int level;
    protected float exp, max_exp;
    public bool unlocked;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void BlockAttack(int i)
    {
        switch(i)
        {
            case 1:
                OneChain();
                break;
            case 2:
                TwoChain();
                break;
            case 3:
                ThreeChain();
                break;
        }
    }

    // Chain attacks
    void OneChain()
    {

    }

    void TwoChain()
    {

    }

    void ThreeChain()
    {

    }

    // Normal attack
    void NormalAttack()
    {

    }

    // when attacked
    void getHit()
    {
        //calculate how damage is taken here

    }

    // Special ability
    public void SpecialAbility()
    {

    }

    public void LevelUp()
    {

    }

    public float GetHealth()
    {
        return hp;
    }
    public int GetSP()
    {
        return sp;
    }
    public float GetAttack()
    {
        return Attack;
    }
    public float GetDefense()
    {
        return Defense;
    }
    public Image GetImage()
    {
        return hero;
    }
    public float GetResistance()
    {
        return Resistance;
    }
    public float GetSpeed()
    {
        return Speed;
    }
    public float GetAccuracy()
    {
        return Accuracy;
    }
    public float GetEvasion()
    {
        return Evasion;
    }
    public int GetLevel()
    {
        return level;
    }
    public string GetHeroName()
    {
        return name;
    }
    public float GetExp()
    {
        return exp;
    }
    public float GetMaxExp()
    {
        return max_exp;
    }
}
