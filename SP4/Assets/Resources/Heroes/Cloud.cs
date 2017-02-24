using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cloud : Hero
{
    static Cloud _instance;
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
        id = 1;
        ClassName = "Cloud";                                            //Cloud's Class Name
        Sp = 100;                                                       //Cloud's Special Points for ultimate (Sort of)
        //hero_img = ;                                                  //Cloud's Sprite I guess?
        name = "Cloud";                                                 //Name of Cloud
        level = 1;                                                      //Cloud's Level
        exp = 0;                                                        //Cloud's Experience points
        //state;
        CalculateStats();
        isDead = false;
        currHp = Hp;
        anim = gameObject.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (Sp >= 100)
        {
            Sp -= 100;
            SpecialAbility();
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

    public override void Exit()
    {
        Destroy(gameObject);
    }
}
