using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Leon : Hero {

	//	public static float Hp,Attack,Defense, Resistance, Speed, Accuracy, Evasion;
	//	public static Image hero;
	//	public static string name;
	//	public int level;
	//	public float exp, max_exp;
	bool isDead;
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
	// Use this for initialization
	protected override void Start () {
		currHp = Hp;
		id = 1;
		ClassName = "Leon";
		//Level increase stat variables
		Sp = 0;
		isDead = false;
		//state = States.Idle;
		animator = gameObject.gameObject.GetComponent<Animator> ();
		level = 1;
		exp = 0;
		CalculateStats ();
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
		GameObject tempcoll = Instantiate (attackCollider);
		tempcoll.SetActive (true);
		foreach(GameObject temp in WaveManager.ListOfMobs)
		{
			if (tempcoll.GetComponent<BoxCollider2D> ().IsTouching (temp.GetComponent<BoxCollider2D> ()))
			{
				temp.GetComponent<Mob> ().getHit (Attack);
			}
		}
		Destroy (tempcoll);

	}

	protected override void TwoChain()
	{
		//state = States.Chain2;
		animator.SetInteger ("Number of Blocks",2);
		animator.SetTrigger ("Blocks Pressed");

		GameObject tempcoll = Instantiate (attackCollider);
		tempcoll.SetActive (true);
		foreach(GameObject temp in WaveManager.ListOfMobs)
		{
			if (tempcoll.GetComponent<BoxCollider2D> ().IsTouching (temp.GetComponent<BoxCollider2D> ()))
			{
				temp.GetComponent<Mob> ().getHit (Attack * 1.5f);
			}
		}
		Destroy (tempcoll);
	}

	protected override void ThreeChain()
	{
		//state = States.Chain3;
		animator.SetInteger ("Number of Blocks",3);
		animator.SetTrigger ("Blocks Pressed");

		GameObject tempcoll = Instantiate (attackCollider);
		tempcoll.SetActive (true);
		foreach(GameObject temp in WaveManager.ListOfMobs)
		{
			if (tempcoll.GetComponent<BoxCollider2D> ().IsTouching (temp.GetComponent<BoxCollider2D> ()))
			{
				temp.GetComponent<Mob> ().getHit (Attack * 2f);
			}
		}
		Destroy (tempcoll);
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
		Hp -= damagetaken;
		if (Hp <= 0)
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

	public override Sprite GetImage()
	{
		return gameObject.GetComponent<Image> ().sprite;
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

	public override void Exit()
	{
		Destroy (gameObject);
	}
}
