using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Werewolf : Hero {

	static Werewolf _instance;
	//Animator animator;

	// Use this for initialization
	protected override void Start () {
		currHp = Hp;
		id = 3;
		ClassName = "Werewolf";
        name = "Werewolf";
        Sp = 0;
        unlocked = BoolPrefs.GetBool("Werewolf Unlocked", true);
        level = PlayerPrefs.GetInt("Werewolf Level", 1);                   //Werewolf's Level
        exp = PlayerPrefs.GetFloat("Werewolf EXP", 0);                     //Werewolf's Experience points

        if (level == 1)
            CalculateStats();
        else
        {
            Hp = PlayerPrefs.GetFloat("Werewolf HP");
            Attack = PlayerPrefs.GetFloat("Werewolf Attack");
            Defense = PlayerPrefs.GetFloat("Werewolf Defense");
            Evasion = PlayerPrefs.GetFloat("Werewolf Evasion");
            max_exp = PlayerPrefs.GetFloat("Werewolf Max_EXP");
        } 
        currHp = Hp;
		isDead = false;
		animator = GetComponent<Animator> ();
		InvincibilityTimer = 0;
		InvincibilityDuration = 1f;
	}

	void CalculateStats()
	{										//Max
		Hp = 100 * level * 1.1f;			//5500
		Attack = 18 * level * 1;			//900
		Defense = 11 * level * 1.2f;		//550
		Evasion = 0.7f * level * 0.9f;		//31.5
		max_exp = 500 * level * 2;			//50k
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

		if (animator.GetCurrentAnimatorStateInfo(0).IsName("Werewolf_Howl"))
		{
			float temp = animator.GetFloat ("Howl Timer");
			temp += Time.deltaTime;
			animator.SetFloat ("Howl Timer", temp);
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
        PlayerPrefs.SetFloat("Werewolf EXP", exp);
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

		Sp += 20;
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
		Sp += 40;
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
		Sp += 60;
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

		Vector3 tempPos = gameObject.transform.position;
		tempPos.y += gameObject.GetComponent<Transform> ().localScale.y / 2;
		DamageTextManager.GeneratePlayerTakeDmg (tempPos, damagetaken);

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
        PlayerPrefs.SetInt("Werewolf Level", level);
        PlayerPrefs.SetFloat("Werewolf HP", Hp);
        PlayerPrefs.SetFloat("Werewolf Attack", Attack);
        PlayerPrefs.SetFloat("Werewolf Defense", Defense);
        PlayerPrefs.SetFloat("Werewolf Evasion", Evasion);
        PlayerPrefs.SetFloat("Werewolf Max_EXP", max_exp);
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
			_instance = new Werewolf ();
			_instance.Start();
			return _instance;
		}
			
		else
			return _instance;
		
	}
}
