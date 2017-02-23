using UnityEngine;
using System.Collections;

public class Arrow : Mob 
{
    public GameObject gArcher, bArcher, rArcher, uArcher;

	// Use this for initialization
    protected override void Start()
    {
        if (WaveManager.GetWaveNumber() < 18)
            Attack = 10;
        else if (WaveManager.GetWaveNumber() > 18 && WaveManager.GetWaveNumber() < 24)
            Attack = 10;
        else if (WaveManager.GetWaveNumber() > 24 && WaveManager.GetWaveNumber() < 29)
            Attack = 10;
        else if (WaveManager.GetWaveNumber() > 29)
            Attack = 10;
    }
	
	// Update is called once per frame
	protected override void Update () 
    {
        Vector3 temp = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        temp.x -= Time.deltaTime * 3.0f;
        gameObject.transform.position = temp;
        foreach (GameObject hero in HeroList)
        {
            if(temp.x <= hero.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().transform.position.x)
            {
                hero.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().getHit(Attack);
                Debug.Log("Arrow Shot");
                Exit();
            }
        }
	}
}
