﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Weeb : Hero 
{
    static Weeb _instance;
    Animator anim;
    bool isDead;
    enum States // for animation
    {
        Idle,
        Attack,

        Death,
    }
    // Use this for initialization
    protected override void Start()
    {
        id = 2;
        ClassName = "Weeb";                                             //Weeb's Class Name
        Sp = 100;                                                       //Weeb's Special Points for ultimate (Sort of)
        //hero_img = ;                                                  //Weeb's Sprite I guess?
        name = "Weeb";                                                  //Name of Weeb
        level = 1;                                                      //Weeb's Level
        exp = 0;                                                        //Weeb's Experience points
        //state;
        isDead = false;
        CalculateStats();
        anim = gameObject.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {

    }

    void CalculateStats()
    {
        Hp = level * 10 + 81;                                           //Weeb's Health Points
        Attack = Attack = level * 20.775f + 9;                          //Weeb's Attack Value
        Defense = Defense = (level * 6.4f) + (Attack / 100) + 5;        //Weeb's Defense Value
        Evasion = 48 + ((Defense / 12));                                //Weeb's Evasion Rate (Maximum of 100% of course)
        max_exp = (level * 2 * 500);                                    //Weeb's Experience points needed to level up  
    }


    protected override Hero Get_Class()
    {
        return this;
    }

    public override void BlockAttack(int i)
    {
        switch (i)
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
	protected override void OneChain()
	{
		anim.SetInteger("Number of Blocks", 1);
		anim.SetTrigger("Blocks Pressed");

		foreach(Mob temp in AttackCollide.Mobs_Collided)
		{
			temp.getHit ((int) (Attack));
		}
	}

	protected override void TwoChain()
	{
		anim.SetInteger("Number of Blocks", 2);
		anim.SetTrigger("Blocks Pressed");

		foreach(Mob temp in AttackCollide.Mobs_Collided)
		{
			temp.getHit ((int) (Attack* 2.0f));
		}
	}

	protected override void ThreeChain()
	{
		anim.SetInteger("Number of Blocks", 3);
		anim.SetTrigger("Blocks Pressed");

		foreach(Mob temp in AttackCollide.Mobs_Collided)
		{
			temp.getHit ((int) (Attack * 3.0f));
		}
	}

    // Normal attack
    protected override void NormalAttack()
    {

    }

    // when attacked
    public override void getHit(int damagetaken)
    {
        //calculate how damage is taken here
        anim.SetTrigger("isHit");
        Hp -= damagetaken;
        if (Hp <= 0)
        {
            isDead = true;
            anim.SetBool("No HP", true);
        }
    }

    // Special ability
    protected override void SpecialAbility()
    {
        anim.SetTrigger("Skill Activated");

        GameObject tempcoll = Instantiate(attackCollider);
        tempcoll.SetActive(true);
        foreach (GameObject temp in WaveManager.ListOfMobs)
        {
            if (tempcoll.GetComponent<BoxCollider2D>().IsTouching(temp.GetComponent<BoxCollider2D>()))
            {
                temp.GetComponent<Mob>().getHit((int)((GetAttack() * 5.0f) + (GetDefense() * 2.0f)));
                currHp += (Attack * 3) * 0.3f;
            }
        }
        Destroy(tempcoll);
    }

    public override void LevelUp()
    {
        exp = 0;
        level += 1;
        CalculateStats();
    }

    public override void SetAttack(int newAtk)
    {
        Attack = newAtk;
    }

    public override float GetAttack()
    {
        return Attack;
    }

    public override void SetDefense(int newDef)
    {
        Defense = newDef;
    }

    public override float GetDefense()
    {
        return Defense;
    }

    public override void SetImage(Sprite newHero_img)
    {
        gameObject.GetComponent<Image>().sprite = newHero_img;
        //hero_img = newHero_img;
    }

    public override Sprite GetSprite()
    {
        return gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    public override int Get_Id()
    {
        return id;
    }


    public override string Get_ClassName()
    {
        return ClassName;
    }

    public override Hero Get_ClassType()
    {
        return this;
    }

    public override Hero Get_Instance()
    {
        if (_instance == null)
        {
            _instance = new Weeb();
            _instance.Start();
            return _instance;
        }

        else
            return _instance;

    }

    public override void Exit()
    {
        Destroy(gameObject);
    }
}
