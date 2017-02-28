using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cloud : Hero
{
    static Cloud _instance;
    //Animator anim;

    enum States // for animation
    {
        Idle,
        Attack,

        Death,
    }
    // Use this for initialization
    protected override void Start()
    {
        id = 1;
        ClassName = "Cloud";                                            //Cloud's Class Name
        Sp = 0;                                                         //Cloud's Special Points for ultimate (Sort of)
        name = "Cloud";                                                 //Name of Cloud
        level = PlayerPrefs.GetInt("Cloud Level", 1);                   //Cloud's Level
        exp = PlayerPrefs.GetFloat("Cloud EXP", 0);                     //Cloud's Experience points

        if(level == 1)
            CalculateStats();
        else 
        {
            Hp = PlayerPrefs.GetFloat("Cloud HP");
            Attack = PlayerPrefs.GetFloat("Cloud Attack");
            Defense = PlayerPrefs.GetFloat("Cloud Defense");
            Evasion = PlayerPrefs.GetFloat("Cloud Evasion");
            max_exp = PlayerPrefs.GetFloat("Cloud Max_EXP");
        }
        isDead = false;
        currHp = Hp;
		InvincibilityTimer = 0;
		InvincibilityDuration = 2f;
		animator = gameObject.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {
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
    }

    void CalculateStats()
    {
        Hp = level * 10 + 105;                                          //Cloud's Health Points
        Attack = level * 17.25f + 9;                                    //Cloud's Attack Value
        Defense = (level * 14.31f) + (Attack / 100) + 5;                //Cloud's Defense Value
        Evasion = 48 + (((Attack - Defense) / 12));                     //Cloud's Evasion Rate (Maximum of 100% of course)
        max_exp = (500 * level * 2);                                    //Cloud's Experience points needed to level up
    }

    protected override Hero Get_Class()
    {
        return this;
    }

    public override void BlockAttack(int i)
    {
		if (isDead)
			return;
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
        PlayerPrefs.SetFloat("Cloud EXP", exp);
    }

    // Chain attacks
    protected override void OneChain()
    {
		animator.SetInteger("Number of Blocks", 1);
		animator.SetTrigger("Blocks Pressed");

		foreach(Mob temp in AttackCollide.Mobs_Collided)
		{
			temp.getHit ((int) (Attack));
		}
		Sp += 20;
    }

    protected override void TwoChain()
    {
		animator.SetInteger("Number of Blocks", 2);
		animator.SetTrigger("Blocks Pressed");

		foreach(Mob temp in AttackCollide.Mobs_Collided)
		{
			temp.getHit ((int) (Attack* 2.0f));
		}
		Sp += 40;
    }

    protected override void ThreeChain()
    {
		animator.SetInteger("Number of Blocks", 3);
		animator.SetTrigger("Blocks Pressed");

		foreach(Mob temp in AttackCollide.Mobs_Collided)
		{
			temp.getHit ((int) (Attack * 3.0f));
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
		animator.SetTrigger("isHit");
        currHp -= damagetaken;

		Vector3 tempPos = gameObject.transform.position;
		//tempPos.y += gameObject.GetComponent<Transform> ().localScale.y / 2;
		DamageTextManager.GeneratePlayerTakeDmg (tempPos, damagetaken);

		Debug.Log ("Ai yaa Cloud got hit....");

        if (currHp <= 0)
        {
            isDead = true;
			animator.SetBool("No HP", true);
        }
    }

    // Special ability
    protected override void SpecialAbility()
    {
		animator.SetTrigger("Skill Activated");

        GameObject tempcoll = Instantiate(attackCollider);
        tempcoll.SetActive(true);
        foreach (GameObject temp in WaveManager.ListOfMobs)
        {
            if (tempcoll.GetComponent<BoxCollider2D>().IsTouching(temp.GetComponent<BoxCollider2D>()))
            {
                temp.GetComponent<Mob>().getHit((int)(GetAttack() * 2.0f));
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
        currHp = Hp;
        PlayerPrefs.SetInt("Cloud Level", level);
        PlayerPrefs.SetFloat("Cloud HP", Hp);
        PlayerPrefs.SetFloat("Cloud Attack", Attack);
        PlayerPrefs.SetFloat("Cloud Defense", Defense);
        PlayerPrefs.SetFloat("Cloud Evasion", Evasion);
        PlayerPrefs.SetFloat("Cloud Max_EXP", max_exp);
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
            _instance = new Cloud();
            _instance.Start();
            return _instance;
        }

        else
            return _instance;

    }
}
