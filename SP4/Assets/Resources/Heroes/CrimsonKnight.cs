using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CrimsonKnight : Hero {

	float SpecialAttackTimer, SpecialAttackDuration;
	float DefenseIncreasePercentage, DefenseIncreaseAmount;

	protected override void Awake()
	{

	}

	// Use this for initialization
	protected override void Start () {
		animator = GetComponent<Animator> ();
		CalculateStats ();
		currHp = Hp;
		Sp = 0;
		ClassName = "CrimsonKnight";
		level = 1;
		exp = 0;
		//Weapon = Resources.Load<BaseWeapon>("Equipment/Weapons/TestWeapon1");
		animator = GetComponent<Animator>();
		InvincibilityTimer = 0;
		InvincibilityDuration = 1f;
		isDead = false;
		SpecialAttackTimer = 0.0f;
		SpecialAttackDuration = 3.0f;
		DefenseIncreasePercentage = 0.5f; //20% if you couldn't tell
		DefenseIncreaseAmount = 0; // used to store amount of defense increased
	}

	void CalculateStats()
	{	
											//Max
		Hp = 100 * level * 1.65f;			//8250
		Attack = 6 * level * 1.2f;			//360
		Defense = 18.5f * level * 1.2f;		//1110
		Evasion = 0.6f * level * 0.4f;		//2.25
		max_exp = 500 * level * 2;			//50k
		//Attack += Weapon.Get_Attack();
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

		if (SpecialAttackTimer > 0)
		{
			SpecialAttackTimer -= Time.deltaTime;
			if (SpecialAttackTimer <= 0)
			{
				SpecialAttackTimer = 0f;
				Defense -= DefenseIncreaseAmount;
				DefenseIncreaseAmount = 0;
			}
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
			temp.getHit ((int) (Attack * 1.3f));
		}
	}

	protected override void ThreeChain()
	{
		animator.SetInteger ("Number of Blocks",3);
		animator.SetTrigger ("Blocks Pressed");

		foreach(Mob temp in AttackCollide.Mobs_Collided)
		{
			temp.getHit ((int) (Attack * 1.8f));
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
		SpecialAttackTimer = SpecialAttackDuration;
		DefenseIncreaseAmount = DefenseIncreasePercentage * Defense;
		Defense += DefenseIncreaseAmount;
	}

	public override void LevelUp()
	{
		level += 1;
		exp = 0;
		CalculateStats ();
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
		gameObject.GetComponent<Image> ().sprite = newHero_img;
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

	public override Hero Get_Instance()
	{
		return new CrimsonKnight ();
	}
}
