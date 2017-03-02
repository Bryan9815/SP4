using UnityEngine;
using System.Collections;

public class Arrow : Mob 
{
    bool hit_Hero1, hit_Hero2, hit_Hero3;
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

        hit_Hero1 = false;
        hit_Hero2 = false;
        hit_Hero3 = false;
    }
	
	// Update is called once per frame
    protected override void Update()
    {
        Vector3 temp = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        temp.x -= Time.deltaTime * 5.0f;
        gameObject.transform.position = temp;
        if (temp.x <= (Hero1.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().transform.position.x) && !hit_Hero1)
        {
            if (!Hero1.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_IsDead())
            {
                float accuracy = Random.Range(1, 101);

                if (accuracy > Hero1.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_Evasion())
                    Hero1.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().getHit(Attack);

                hit_Hero1 = true;
            }
        }
        else if (temp.x <= (Hero2.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().transform.position.x) && !hit_Hero2)
        {
            if (!Hero2.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_IsDead())
            {
                float accuracy = Random.Range(1, 101);

                if (accuracy > Hero2.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_Evasion())
                    Hero2.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().getHit(Attack);

                hit_Hero2 = true;
            }
        }
        else if (temp.x <= (Hero3.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().transform.position.x) && !hit_Hero3)
        {
            if (!Hero3.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_IsDead())
            {
                float accuracy = Random.Range(1, 101);

                if (accuracy > Hero3.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().Get_Evasion())
                    Hero3.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().getHit(Attack);

                hit_Hero3 = true;
            }

            if (temp.x <= Hero3.GetComponent<HeroHolder>().Get_GameObject().GetComponent<Hero>().transform.position.x - 5)
                Exit();
        }
    }
}
