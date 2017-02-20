using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class BlockManager : MonoBehaviour {

    //public static BlockManager _Instance;

//	public BlockManager Instance()
//	{
//		if (_Instance == null)
//			_Instance = new BlockManager ();
//		return _Instance;
//	}
//    public static BlockManager Instance
//    {
//        get
//        {
//            if (_Instance == null)
//            {
//                BlockManager temp = new BlockManager();
//                _Instance = temp;
//            }
//            return _Instance;
//        }
//    }

    public static List<Button> Listof_Blocks;
    //List<Button> Listof_UnusedBlocks;
    private float Block_Spawn_Timer = 0;
    public float Max_Block_Spawn_Timer;
    public Button block_obj_to_spawn;
    public GameObject block_background;
	public GameObject block_obj_end;
	private float travel_limit;
	// Use this for initialization
	void Start () {
        Listof_Blocks = new List<Button>();
		//Instance = new BlockManager ();
		travel_limit = block_obj_end.GetComponent<RectTransform>().anchoredPosition.x;
	}
	
	// Update is called once per frame
	void Update () {
        Block_Spawn_Timer += Time.deltaTime;
	    if (Block_Spawn_Timer > Max_Block_Spawn_Timer && Listof_Blocks.Count < 8)
        {
            Block_Spawn_Timer = 0.0f;
            SpawnNewBlock(Random.Range(1, 3));
            //Debug.Log("Block spawned");
        }
        for (int i = 0; i < Listof_Blocks.Count; ++i)
        {
            Block temp = Listof_Blocks[i].gameObject.GetComponent<Block>();
            if (!temp.get_Active())
            {
                Listof_Blocks.RemoveAt(i); 
				temp.Exit();
                //decrement i for later iterations as elemnts get moved down
				if (i > 0)
					i--;
            }
            else
            {
				temp.set_BlockSlot (i);
                temp.CheckBlockChain();
				temp.Travel(travel_limit);
            }
        }
		//Debug.Log (Listof_Blocks.Count);
	}

    public Button SpawnNewBlock(int hero_slot)
    {
        //Block temp = Listof_UnusedBlocks[Listof_UnusedBlocks.Count - 1];        
        //Listof_UnusedBlocks.RemoveAt(Listof_UnusedBlocks.Count - 1);
        ////temp.reset();

        //Listof_Blocks.Add(temp);


		Button newObject = Instantiate(block_obj_to_spawn,block_obj_to_spawn.transform.position,block_obj_to_spawn.transform.rotation) as Button;
		newObject.transform.parent = gameObject.transform;
		//Vector3 temp = new Vector3(block_background.GetComponent<RectTransform>().anchoredPosition.x /*- (Screen.width/21)*/, block_background.GetComponent<RectTransform>().anchoredPosition.y);
		//newObject.GetComponent<RectTransform> ().anchoredPosition.Set (temp.x, temp.y);//,temp.z);// = temp;
		Vector3 temp = new Vector3(1,1,1);
		newObject.GetComponent<RectTransform> ().localScale = temp;
		newObject.gameObject.SetActive(true);
		newObject.gameObject.GetComponent<Block> ().set_Active (true);
//		newObject.GetComponent<Button>().onClick.AddListener (delegate() {
//			this.GetComponent<Block>().Activate();
//		});
        Listof_Blocks.Add(newObject);
		float x = newObject.GetComponent<RectTransform> ().localScale.x;
		float y = newObject.GetComponent<RectTransform> ().localScale.y;
        return newObject;
    }
}
