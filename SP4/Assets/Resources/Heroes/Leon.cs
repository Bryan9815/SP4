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
	enum States // for animation
	{
		Idle,
		Attack,
	}
	// Use this for initialization
	protected override void Start () {
		id = 1;
		ClassName = "Leon";
	}

	// Update is called once per frame
	protected override void Update () {

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

	}

	protected override void TwoChain()
	{

	}

	protected override void ThreeChain()
	{

	}

	// Normal attack
	protected override void NormalAttack()
	{

	}

	// when attacked
	public override void getHit()
	{
		//calculate how damage is taken here

	}

	// Special ability
	protected override void SpecialAbility()
	{

	}

	public override void LevelUp()
	{

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

	}
}
