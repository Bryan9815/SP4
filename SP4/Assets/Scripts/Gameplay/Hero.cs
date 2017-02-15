using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hero : MonoBehaviour {
    public static float Attack,Defense, Resistance, Speed, Accuracy, Evasion;
    public static Image hero;
    public static string name;
    public int level;
    public float exp, max_exp;
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
}
