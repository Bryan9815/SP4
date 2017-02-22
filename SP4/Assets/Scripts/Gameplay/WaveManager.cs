using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour 
{
    public GameObject Orc, G_Dwarf_Miner, G_Dwarf_Warrior, G_Dwarf_Archer;

    public static List<GameObject> ListOfMobs;

    private int WaveNumber, MobNumber;
    private bool WaveOver;
	// Use this for initialization
	void Start ()
    {
        WaveNumber = 1;
        WaveOver = false;

        RandomizeMobNumber();
        GenerateMobs();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!WaveOver)
        {
            if (ListOfMobs.Count <= 0)
                WaveOver = true;
        }
        else
            WaveTransition();
	}

    void RandomizeMobNumber()
    {
        MobNumber = Random.Range((5 + WaveNumber), (3 + WaveNumber + 2 * WaveNumber));
    }

    void SpawnMobs(int mobID)
    {
        GameObject newMob;
        switch(mobID)
        {
            case 0:
                newMob = Instantiate(Orc);
                ListOfMobs.Add(newMob);
                break;
            case 1:
                newMob = Instantiate(G_Dwarf_Miner);
                ListOfMobs.Add(newMob);
                break;
            case 2:
                newMob = Instantiate(G_Dwarf_Warrior);
                ListOfMobs.Add(newMob);
                break;
            case 3:
                newMob = Instantiate(G_Dwarf_Archer);
                ListOfMobs.Add(newMob);
                break;
            default:
                break;
        }
    }

    void GenerateMobs()
    {
        if (WaveNumber <= 3)
        {
            for (int i = 0; i < MobNumber; i++)
            {
                SpawnMobs(0);
            }
        }
        if (WaveNumber > 3 && WaveNumber <= 5)
        {
            for (int i = 0; i < MobNumber; i++)
            {
                SpawnMobs(Random.Range(0, 1));
            }
        }
    }

    void WaveTransition()
    {
        WaveNumber++;
        RandomizeMobNumber();
        GenerateMobs();
        WaveOver = false;
    }
}