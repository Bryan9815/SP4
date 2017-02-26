using UnityEngine;
using System.Collections;

public class Arrow : Mob 
{
	// Use this for initialization
    protected override void Start()
    {
        if (WaveManager.GetWaveNumber() < 18)
            Attack = (int)(26.4f * WaveManager.GetWaveNumber() * Random.Range(1, 1.43f));
        else if (WaveManager.GetWaveNumber() > 18 && WaveManager.GetWaveNumber() < 24)
            Attack = (int)(40.9f * WaveManager.GetWaveNumber() * Random.Range(1, 1.43f));
        else if (WaveManager.GetWaveNumber() > 24 && WaveManager.GetWaveNumber() < 29)
            Attack = (int)(60.9f * WaveManager.GetWaveNumber() * Random.Range(1, 1.43f));
        else if (WaveManager.GetWaveNumber() > 29)
            Attack = (int)(74.9f * WaveManager.GetWaveNumber() * Random.Range(1, 1.43f));

        if (Attack > 5000)
            Attack = 5000;
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
                float accuracy = Random.Range(1, 101);
                if (accuracy > hero.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_Evasion())
                    hero.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().getHit(Attack);

                if (temp.x <= Hero3.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().transform.position.x)
                    Exit();
            }
        }
	}
}
