using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hero : MonoBehaviour {
    protected float Hp, currHp, Attack, Defense, Evasion;
	protected int Sp;
    protected Sprite hero_img;
    protected string name;
    protected int level;
	protected int id;
    protected float exp, max_exp;
	protected float attackTimer, attackTimer_Max;
	protected int state;
	protected string ClassName;
    protected bool isDead;
	protected float InvincibilityTimer;
	protected float InvincibilityDuration;
	protected bool unlocked;
	protected BaseWeapon Weapon;
	protected Animator animator;
	public GameObject attackCollider;

	protected virtual void Awake()
	{
		//attackCollider = gameObject.gameObject.get
	}

	// Use this for initialization
	protected virtual void Start () {
		animator = GetComponent<Animator> ();
		currHp = Hp;
		Sp = 0;
		ClassName = "TemplateHero";
		level = 1;
		exp = 0;
		Weapon = Resources.Load<BaseWeapon>("Equipment/Weapons/TestWeapon1");
		animator = GetComponent<Animator>();
		InvincibilityTimer = 0;
		InvincibilityDuration = 1f;
		isDead = false;
		//CalculateStats ();
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

	public virtual void IncreaseExp(float exp_received)
	{
		exp += exp_received;
		if (exp >= max_exp) 
		{
			float temp = exp - max_exp;
			LevelUp ();
		}
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

    public virtual Sprite GetSprite()
    {
		return gameObject.GetComponent<SpriteRenderer>().sprite;
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

	public virtual float Get_Hp()
	{
		return currHp;
	}

	public virtual float Get_MaxHp()
	{
		return Hp;
	}

    public virtual float GetSP()
    {
        return Sp;
    }

    public virtual float Get_Evasion()
    {
        return Evasion;
    }
    public virtual float Get_Exp()
    {
        return exp;
    }
    public virtual float Get_MaxExp()
    {
        return max_exp;
    }
    public virtual int Get_Level()
    {
        return level;
    }
    public virtual string Get_HeroName()
    {
        return name;
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

    public virtual bool Get_IsDead()
    {
        return isDead;
    }

	public virtual bool Get_IsInvincible()
	{
		return InvincibilityTimer > 0;
	}

	public virtual void Set_Idle()
	{
		animator.SetTrigger("Idle");
	}

    public virtual void Set_Static()
    {
        animator.SetTrigger("Idle");
        animator.enabled = false;
    }

    public virtual bool Get_Unlocked()
    {
        return unlocked;
    }

    public virtual void Set_Unlocked(bool newBool)
    {
        unlocked = newBool;
    }

	public virtual void Exit()
	{
        Vector3 temp = new Vector3(-10000, 0, 0);
		gameObject.transform.position = temp;
	}
}
