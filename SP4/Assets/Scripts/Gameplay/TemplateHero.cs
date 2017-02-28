using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TemplateHero : Hero {

	enum States // for animation (optional as u can use states in animator)
	{
		Idle,
		Attack,
	}

	Animator animator;

	protected override void Awake()
	{
		
	}

	// Use this for initialization
	protected override void Start () {
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
		CalculateStats ();
	}

	void CalculateStats()
	{	
											//Max
		//Hp = 100 * level * 1.45f;			//7250
		//Attack = 18 * level * 1;			//900
		//Defense = 11 * level * 1.2f;		//550
		//Evasion = 0.7f * level * 0.9f;		//31.5
		//max_exp = 500 * level * 2;			//50k
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
			if (InvincibilityTimer < 0)
				InvincibilityTimer = 0;
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
		Hp -= damagetaken;
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
		return new TemplateHero ();
	}

	public override void Exit()
	{
		Destroy (gameObject);
	}
}
