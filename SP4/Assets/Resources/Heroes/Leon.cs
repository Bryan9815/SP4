using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Leon : Hero {

	//	public static float Hp,Attack,Defense, Resistance, Speed, Accuracy, Evasion;
	//	public static Image hero;
	//	public static string name;
	//	public int level;
	//	public float exp, max_exp;

	static Leon _instance;
//	enum States // for animation
//	{
//		Idle,
//		Attack,
//		Chain1,
//		Chain2,
//		Chain3,
//		Death,
//	}
//
//	States state;
	Animator animator;
	//Collider
	//GameObject tempcoll;
	// Use this for initialization
	protected override void Start () {
		currHp = Hp;
		id = 3;
		ClassName = "Leon";
		//Level increase stat variables
		Sp = 0;
		isDead = false;
		//state = States.Idle;
		animator = GetComponent<Animator> ();
		level = 1;
		exp = 0;
        CalculateStats();
        currHp = Hp;
	}

	void CalculateStats()
	{										//Max
		Hp = 100 * level * 1.45f;			//7250
		Attack = 18 * level * 1;			//900
		Defense = 11 * level * 1.2f;		//550
		Evasion = 0.7f * level * 0.9f;		//31.5
		max_exp = 500 * level * 2;			//50k
	}

	// Update is called once per frame
	protected override void Update () {
		if (Sp >= 100)
		{
			Sp -= 100;
			SpecialAbility ();
		}
	}


	protected override Hero Get_Class()
	{
		return this;
	}

	public override void BlockAttack(int i)
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
	protected override void OneChain()
	{
		//state = States.Chain1;
		animator.SetInteger ("Number of Blocks",1);
		animator.SetTrigger ("Blocks Pressed");

		foreach(Mob temp in AttackCollide.Mobs_Collided)
		{
			temp.getHit ((int) (Attack));
		}
	}

	protected override void TwoChain()
	{
		//state = States.Chain2;
		animator.SetInteger ("Number of Blocks",2);
		animator.SetTrigger ("Blocks Pressed");

		foreach(Mob temp in AttackCollide.Mobs_Collided)
		{
			temp.getHit ((int) (Attack * 1.5f));
		}
	}

	protected override void ThreeChain()
	{
		//state = States.Chain3;
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
		//calculate how damage is taken here
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
	}

	public override void LevelUp()
	{
		level += 1;
		exp = 0;
		CalculateStats ();
        currHp = Hp;
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
			_instance = new Leon ();
			_instance.Start();
			return _instance;
		}
			
		else
			return _instance;
		
	}
}
