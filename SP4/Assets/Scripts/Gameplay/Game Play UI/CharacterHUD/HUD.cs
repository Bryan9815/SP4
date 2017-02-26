using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour
{
    public GameObject Hero;
	public Image characterIcon;
	public Image characterHP;
	public Image characterMP;

	public Text Hp_txt;
	public Text Mp_txt;

	private float maxHP;
	private float currHP;

	private float maxMP;
	private float currMP;

	private Vector3 tempHP; 
	private Vector3 tempMP;

    private bool ImageSet = false;
	// Use this for initialization
	void Start ()
	{        
		Hp_txt.text = "";
		Mp_txt.text = "";

		currHP = maxHP =  100.0f;
		currMP = maxMP =  100.0f;

		tempHP.x = currHP / maxHP;
		tempMP.x = currMP / maxMP;

		tempHP.y = tempHP.z = tempMP.y = tempMP.z = 1.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
        if(!ImageSet)
        {
            currHP = maxHP = Hero.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_Hp();
            currMP = Hero.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().GetSP();
            characterIcon.sprite = Hero.GetComponent<HeroHolder>().ReturnSprite();
            ImageSet = true;
        }

        maxHP = Hero.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_Hp();
		currHP = Hero.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_Hp();
        currMP = Hero.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().GetSP();

		if (currHP <= 0.0f)
			currHP = 0.0f;
		if (currMP <= 0.0f)
			currMP = 0.0f;

		Hp_txt.text = ((int)currHP).ToString();
		Mp_txt.text = ((int)currMP).ToString();
		
		tempHP.x = currHP / maxHP;
		tempMP.x = currMP / maxMP;

		characterHP.transform.localScale = tempHP;
		characterMP.transform.localScale = tempMP;
	}
}
