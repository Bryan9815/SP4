using UnityEngine;
using System.Collections;

public class Brawler : Hero {

	protected override void Awake()
	{

	}

	// Use this for initialization
	protected override void Start () {
		animator = GetComponent<Animator> ();
		currHp = Hp;
		Sp = 0;
		ClassName = "Brawler";
        name = "Brawler";
        Skill_Description = "Does high damage with an uppercut.";
        unlocked = BoolPrefs.GetBool("Brawler Unlocked", false);
        level = PlayerPrefs.GetInt("Brawler Level", 1);
        exp = PlayerPrefs.GetFloat("Brawler EXP", 0);                     

		//Weapon = Resources.Load<BaseWeapon>("Equipment/Weapons/TestWeapon1");
		animator = GetComponent<Animator>();
		InvincibilityTimer = 0;
		InvincibilityDuration = 1f;
		isDead = false;
        if (level == 1)
            CalculateStats();
        else
        {
            Hp = PlayerPrefs.GetFloat("Brawler HP");
            Attack = PlayerPrefs.GetFloat("Brawler Attack");
            Defense = PlayerPrefs.GetFloat("Brawler Defense");
            Evasion = PlayerPrefs.GetFloat("Brawler Evasion");
            max_exp = PlayerPrefs.GetFloat("Brawler Max_EXP");
        }
	}

	void CalculateStats()
	{	
		//Max
		Hp = 100 * level * 1.1f;					//5500
		Attack = 13 * level * 0.8f;					//520
		Defense = 11 * level * 1.2f;				//660
	Evasion = (Defense / 1000) * level * 0.85f;		//28.05
		max_exp = 500 * level * 2;					//50k
	}

	// Update is called once per frame
	protected override void Update () {
		if (isDead)
			return;
		if (Sp >= 100)
		{
			Sp -= 100;
			SpecialAbility ();
		}
		if (InvincibilityTimer > 0)
		{
			InvincibilityTimer -= Time.deltaTime;
			if (GetComponent<SpriteRenderer> ().enabled)
				GetComponent<SpriteRenderer> ().enabled = false;
			else
				GetComponent<SpriteRenderer> ().enabled = true;
			if (InvincibilityTimer < 0)
			{
				InvincibilityTimer = 0;
				GetComponent<SpriteRenderer> ().enabled = true;
			}				
		}
		else 
		{
			if (!GetComponent<SpriteRenderer> ().enabled)
				GetComponent<SpriteRenderer> ().enabled = true;
		}
	}

	protected override Hero Get_Class()
	{
		return this;
	}

	public override void BlockAttack(int i)
	{
		if (isDead)
			return;
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
        PlayerPrefs.SetFloat("Brawler EXP", exp);
	}

	// Chain attacks
	protected override void OneChain()
	{
		animator.SetInteger ("Number of Blocks",1);
		animator.SetTrigger ("Blocks Pressed");

		foreach(Mob temp in AttackCollide.Mobs_Collided)
		{
			temp.getHit ((int) (Attack));
		}
	}

	protected override void TwoChain()
	{
		animator.SetInteger ("Number of Blocks",2);
		animator.SetTrigger ("Blocks Pressed");

		foreach(Mob temp in AttackCollide.Mobs_Collided)
		{
			temp.getHit ((int) (Attack * 1.5f));
		}
	}

	protected override void ThreeChain()
	{
		animator.SetInteger ("Number of Blocks",3);
		animator.SetTrigger ("Blocks Pressed");

		foreach(Mob temp in AttackCollide.Mobs_Collided)
		{
			temp.getHit ((int) (Attack * 2f));
		}
	}

	// Normal attack
	protected override void NormalAttack()
	{

	}

	// when attacked
	public override void getHit(int damagetaken)
	{
		if (isDead)
			return;
		if (InvincibilityTimer > 0)
			return;

		//calculate how damage is taken here
		InvincibilityTimer += InvincibilityDuration;
		animator.SetTrigger ("isHit");
		currHp -= damagetaken;
		if (currHp <= 0)
		{
			isDead = true;
			animator.SetBool ("No HP", true);
		}
	}

	// Special ability
	protected override void SpecialAbility()
	{
		animator.SetTrigger ("Skill Activated");
		foreach(Mob temp in AttackCollide.Mobs_Collided)
		{
			temp.getHit ((int) (Attack * 5f));
		}
	}

	public override void LevelUp()
	{
		level += 1;
		exp = 0;
		CalculateStats ();

        PlayerPrefs.SetInt("Brawler Level", level);
        PlayerPrefs.SetFloat("Brawler HP", Hp);
        PlayerPrefs.SetFloat("Brawler Attack", Attack);
        PlayerPrefs.SetFloat("Brawler Defense", Defense);
        PlayerPrefs.SetFloat("Brawler Evasion", Evasion);
        PlayerPrefs.SetFloat("Brawler Max_EXP", max_exp);
	}

	public override void IncreaseExp(float exp_received)
	{
		exp += exp_received;
		if (exp >= max_exp) 
		{
			float temp = exp - max_exp;
			LevelUp ();
		}
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

	public override Sprite GetSprite()
	{
		return gameObject.GetComponent<SpriteRenderer>().sprite;
	}

	public override int Get_Id()
	{
		return id;
	}

	public override float Get_AttackTimer()
	{
		return attackTimer;
	}

	public override float Get_Max_AttackTimer()
	{
		return attackTimer_Max;
	}

	public override float Get_Hp()
	{
		return currHp;
	}

	public override float Get_MaxHp()
	{
		return Hp;
	}

	public override float GetSP()
	{
		return Sp;
	}

	public override float Get_Evasion()
	{
		return Evasion;
	}
	public override float Get_Exp()
	{
		return exp;
	}
	public override float Get_MaxExp()
	{
		return max_exp;
	}
	public override int Get_Level()
	{
		return level;
	}
	public override string Get_HeroName()
	{
		return name;
	}
	public override string Get_ClassName()
	{
		return ClassName;
	}

	public override Hero Get_ClassType()
	{
		return this;
	}

    public override void Set_Unlocked(bool newBool)
    {
        unlocked = newBool;
        BoolPrefs.SetBool("Brawler Unlocked", unlocked);
    }

	public override Hero Get_Instance()
	{
		return new Brawler ();
	}
}
