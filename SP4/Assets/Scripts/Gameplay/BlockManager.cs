using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class BlockManager : MonoBehaviour {

    static BlockManager _Instance;
    public static BlockManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                BlockManager temp = new BlockManager();
                _Instance = temp;
            }
            return _Instance;
        }
    }

    public List<GameObject> Listof_Blocks;
    //List<Button> Listof_UnusedBlocks;
    float Block_Spawn_Timer = 0;
    float Max_Block_Spawn_Timer;
    GameObject block_obj_to_spawn;
    GameObject block_background;
	// Use this for initialization
	void Start () {
        Listof_Blocks = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        Block_Spawn_Timer += Time.deltaTime;
	    if (Block_Spawn_Timer > Max_Block_Spawn_Timer && Listof_Blocks.Count < 8)
        {
            Block_Spawn_Timer = 0.0f;
            SpawnNewBlock(Random.Range(1, 3));
        }
        for (int i = 0; i < Listof_Blocks.Count; ++i)
        {
            Block temp = Listof_Blocks[i].GetComponent<Block>();
            if (!temp.get_Active())
            {
                Destroy(Listof_Blocks[i]);
                Listof_Blocks.RemoveAt(i); 
                //decrement i for later iterations as elemnts get moved down
                //Decrease two times in case there was a three chain
                i -= 2;
                if (i < 0)
                    i = 0;
            }
            else
            {
                temp.CheckBlockChain();
            }
        }
        for (int i = 0; i < Listof_Blocks.Count; ++i)
        {
            Block temp = Listof_Blocks[i].GetComponent<Block>();
            temp.set_BlockSlot(i);
        }
	}

    public GameObject SpawnNewBlock(int hero_slot)
    {
        //Block temp = Listof_UnusedBlocks[Listof_UnusedBlocks.Count - 1];        
        //Listof_UnusedBlocks.RemoveAt(Listof_UnusedBlocks.Count - 1);
        ////temp.reset();

        //Listof_Blocks.Add(temp);


        GameObject newObject = Instantiate(block_obj_to_spawn);
        Vector3 temp = new Vector3(block_background.transform.position.x,block_background.transform.position.y - Screen.width);
        newObject.transform.position = temp;
        Listof_Blocks.Add(newObject);
        return newObject;
    }
}
