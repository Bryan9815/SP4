﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hero : MonoBehaviour {
	protected float Hp,Attack,Defense, Resistance, Speed, Accuracy, Evasion;
	protected int Sp;
    protected Sprite hero_img;
    protected string name;
    protected int level;
	protected int id;
    protected float exp, max_exp;
	protected float attackTimer, attackTimer_Max;
	protected int state;
	protected string ClassName;
	public bool unlocked;
	// Use this for initialization
	protected virtual void Start () {
        
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		
	}

	protected virtual Hero Get_Class()
	{
		return this;
	}

	public virtual void BlockAttack(int i)
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
	protected virtual void OneChain()
    {

    }

	protected virtual void TwoChain()
    {

    }

	protected virtual void ThreeChain()
    {

    }

    // Normal attack
	protected virtual void NormalAttack()
    {

    }

    // when attacked
	public virtual void getHit(int damagetaken)
    {
        //calculate how damage is taken here

    }

    // Special ability
	protected virtual void SpecialAbility()
    {

    }

	public virtual void LevelUp()
    {

    }

	public virtual void SetAttack(int newAtk)
	{
		Attack = newAtk;
	}

	public virtual float GetAttack()
    {
        return Attack;
    }

	public virtual void SetDefense(int newDef)
	{
		Defense = newDef;
	}

	public virtual float GetDefense()
    {
        return Defense;
    }

	public virtual void SetImage(Sprite newHero_img)
	{
		gameObject.GetComponent<Image> ().sprite = newHero_img;
		//hero_img = newHero_img;
	}

	public virtual Sprite GetImage()
    {
		return gameObject.GetComponent<Image>().sprite;
    }

	public virtual int Get_Id()
	{
		return id;
	}

	public virtual float Get_AttackTimer()
	{
		return attackTimer;
	}

	public virtual float Get_Max_AttackTimer()
	{
		return attackTimer_Max;
	}

	public virtual string Get_ClassName()
	{
		return ClassName;
	}

	public virtual Hero Get_ClassType()
	{
		return this;
	}

	public virtual Hero Get_Instance()
	{
		return new Hero ();
	}

	public virtual void Exit()
	{
		Destroy (gameObject);
	}
}
