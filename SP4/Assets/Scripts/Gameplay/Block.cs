using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour {
    public Button gameobject;
    private string Name; // useless for now, but put just in case it might be used later
    public int block_slot; // position in the block manager list of blocks
    private int hero_slot; // slot which block corresponds to
	private bool active; // if block should be destroyed
    public float Block_Travel_Speed; // block travel speed
	public bool set; // if block still travelling
	public float collide_allowance;
	public Sprite Block1_Img,Block2_Img,Block3_Img;
	public List<Sprite> BlockImageList;

	//HS
	Scene scene;
    public enum Chain
    {
        One_Chain,
        Two_Chain_Left,
        Two_Chain_Right,
        Three_Chain_Left,
        Three_Chain_Right,
		Three_Chain_Middle
    }

    public Chain chain_type;

	void Awake()
	{
		hero_slot = 0;
		BlockImageList = new List<Sprite> ();
		scene = SceneManager.GetActiveScene ();
		BlockImageList.Add (Block1_Img);
		BlockImageList.Add (Block2_Img);
		BlockImageList.Add (Block3_Img);

		//HS
		if (scene.name == "Tutorial") 
			gameObject.GetComponent<Button> ().interactable = false;
	}

	// Use this for initialization
	void Start () {
        Name = gameobject.name;
        active = true;
        block_slot = 0;
        
        chain_type = Chain.One_Chain;
		set = false;
		gameObject.GetComponent<Button> ().onClick.AddListener (delegate() {
			this.Activate ();
		});
	}
	
	// Update is called once per frame
	void Update () {
		//HS
		if (TutorialManager.counter > 0 && TutorialManager.distance <= 0.5f)
		{
			gameObject.GetComponent<Button> ().interactable = true;
		}
	}

	public bool get_Set()
	{
		return set;
	}
	public void set_Set(bool newSet)
	{
		set = newSet;
	}

    public void set_BlockSlot(int blockslot)
    {
        block_slot = blockslot;
    }

    public int get_BlockSlot()
    {
        return block_slot;
    }

    public void set_HeroSlot(int newHeroslot)
    {
        hero_slot = newHeroslot;
    }

    public int get_HeroSlot()
    {
        return hero_slot;
    }

    public void set_Active(bool _active)
    {
        active = _active;
    }

    public bool get_Active()
    {
        return active;
    }


    public void Set_Transform_X(float x_value)
    {
        //gameobject.transform.position.x + Time.deltaTime * Block_Travel_Speed
        //Vector3 temp = new Vector3(x_value, 0);
        gameobject.transform.position.Set(
            x_value,
            gameobject.transform.position.y,
            gameobject.transform.position.z);
    }

	public void Travel(float limit)
	{
		// if first block in list ----------------------------------------------------------------------------------------------------
		if (gameobject.GetComponent<RectTransform> ().anchoredPosition.x < limit && block_slot == 0) 
		{
			Vector2 temp = new Vector2 (gameobject.GetComponent<RectTransform> ().anchoredPosition.x, gameobject.GetComponent<RectTransform> ().anchoredPosition.y);
			temp.x += Time.deltaTime * Block_Travel_Speed;
			gameobject.GetComponent<RectTransform> ().anchoredPosition = temp;
			set = false;
		} 
		else if (block_slot != 0) { // if not first block in list ----------------------------------------------------------------------------------------------------
			// if touching the previous block collider
			if (gameObject.GetComponent<BoxCollider2D> ().IsTouching (BlockManager.Listof_Blocks [block_slot - 1].gameObject.GetComponent<BoxCollider2D> ())) 
			{
				set = true;
				//adjust if collision detected too late ----------------------------------------------------
				float coll_width = gameObject.GetComponent<BoxCollider2D>().size.x - gameObject.GetComponent<RectTransform>().rect.width;
				float properdist = gameObject.GetComponent<RectTransform> ().rect.width + coll_width - collide_allowance;
				if ( (BlockManager.Listof_Blocks [block_slot - 1].gameObject.GetComponent<RectTransform> ().anchoredPosition.x - 
					gameObject.GetComponent<RectTransform> ().anchoredPosition.x) < properdist )
				{
					Vector2 temp = new Vector2 (gameobject.GetComponent<RectTransform> ().anchoredPosition.x, gameobject.GetComponent<RectTransform> ().anchoredPosition.y);
					temp.x -= Time.deltaTime * (Block_Travel_Speed / 10);
					gameobject.GetComponent<RectTransform> ().anchoredPosition = temp;
				}
			} 
			else // if not touching the previous block collider
			{ 
				Vector2 temp = new Vector2 (gameobject.GetComponent<RectTransform> ().anchoredPosition.x, gameobject.GetComponent<RectTransform> ().anchoredPosition.y);
				temp.x += Time.deltaTime * Block_Travel_Speed;
				gameobject.GetComponent<RectTransform> ().anchoredPosition = temp;
				set = false;
			}
		} 
		else  // if first block in list but x position over limit
		{
			set = true;
		}
	}	

    public void Activate()
    {
		//HS
		//it will only enter this if when it is in tutorial mode
		if (TutorialManager.counter > 0 && TutorialManager.distance <= 0.5f) 
		{
			Time.timeScale = 1;
			TutorialManager.counter++;
		}

		// if still traveling, dont activate
		if (!set)
			return;
		// else set to destroy
        active = false;
		// to check chain number
        int chain_no = 0;
        switch (chain_type)
        {
			case Chain.Three_Chain_Middle:
				{
				Block temp = BlockManager.Listof_Blocks[block_slot + 1].gameObject.GetComponent<Block>();
				Block temp2 = BlockManager.Listof_Blocks[block_slot - 1].gameObject.GetComponent<Block>();
				temp.set_Active(false);
				temp2.set_Active(false);
				chain_no = 3;
				}
				break;
            case Chain.Three_Chain_Left:
                {
				Block temp = BlockManager.Listof_Blocks[block_slot + 1].gameObject.GetComponent<Block>();
				Block temp2 = BlockManager.Listof_Blocks[block_slot + 2].gameObject.GetComponent<Block>();
                    temp.set_Active(false);
                    temp2.set_Active(false);
                    chain_no = 3;
                }                
                break;
            case Chain.Three_Chain_Right:
                {
				Block temp = BlockManager.Listof_Blocks[block_slot - 1].gameObject.GetComponent<Block>();
				Block temp2 =BlockManager.Listof_Blocks[block_slot - 2].gameObject.GetComponent<Block>();
                    temp.set_Active(false);
                    temp2.set_Active(false);
                    chain_no = 3;
                }                
                break;
            case Chain.Two_Chain_Left:
                {
				Block temp = BlockManager.Listof_Blocks[block_slot + 1].gameObject.GetComponent<Block>();                    
                    temp.set_Active(false);
                    chain_no = 2;
                }
                break;
            case Chain.Two_Chain_Right:
                {
				Block temp = BlockManager.Listof_Blocks[block_slot - 1].gameObject.GetComponent<Block>();
                    temp.set_Active(false);
                    chain_no = 2;

                }
                break;
            case Chain.One_Chain:
                {
                    chain_no = 1;
                }
                break;
        }

        // Run respective hero stuffs here
		HeroManager.List_ofHeroes [hero_slot].GetComponent<HeroHolder> ().Get_GameObject().GetComponent<Hero>().BlockAttack (chain_no);

    }
    public void CheckBlockChain()
    {
        if (block_slot >= 2)
        {
            //right
			if (ThreeChainCheck_Middle ())
				chain_type = Chain.Three_Chain_Middle;
			
            else if (ThreeChainCheck_Right())
                chain_type = Chain.Three_Chain_Right;
            else if (TwoChainCheck_Right())
                chain_type = Chain.Two_Chain_Right;
            //left
            else if (ThreeChainCheck_Left())
                chain_type = Chain.Three_Chain_Left;
            else if (TwoChainCheck_Left())
                chain_type = Chain.Two_Chain_Left;
            //No chain
            else
                chain_type = Chain.One_Chain;
        }
        else if (block_slot == 1)
        {
            //right
			if (ThreeChainCheck_Middle ())
				chain_type = Chain.Three_Chain_Middle;
			
            else if (TwoChainCheck_Right())
                chain_type = Chain.Two_Chain_Right;
            //left
			else if (ThreeChainCheck_Left())
				chain_type = Chain.Three_Chain_Left;
            else if (TwoChainCheck_Left())
                chain_type = Chain.Two_Chain_Left;
            //No chain
            else
                chain_type = Chain.One_Chain;
        }
        else
        {
			if (ThreeChainCheck_Left())
				chain_type = Chain.Three_Chain_Left;
			else if (TwoChainCheck_Left())
				chain_type = Chain.Two_Chain_Left;
            else
                chain_type = Chain.One_Chain;
        }
    }



    bool TwoChainCheck_Left()
    {
		
		if (BlockManager.Listof_Blocks.Count - 1 < block_slot + 1)
			return false;
		Block temp = BlockManager.Listof_Blocks[block_slot + 1].GetComponent<Block>();
		if (temp.get_HeroSlot() == hero_slot && temp.get_Set())
        {
            return true;
        }
        else
            return false;
    }

    bool TwoChainCheck_Right()
    {
		Block temp = BlockManager.Listof_Blocks[block_slot - 1].GetComponent<Block>();

        if (temp.get_HeroSlot() == hero_slot)
        {
            return true;
        }
        else
            return false;
    }

    bool ThreeChainCheck_Left()
    {
		//FindObjectOfType
		if (BlockManager.Listof_Blocks.Count - 1 < block_slot + 2)
			return false;
		Block temp = BlockManager.Listof_Blocks[block_slot + 2].GetComponent<Block>();
		bool test = ReferenceEquals (temp, BlockManager.Listof_Blocks [block_slot + 2].GetComponent<Block> ());
		if (temp.get_HeroSlot() == hero_slot && TwoChainCheck_Left() && temp.get_Set())
        {
            return true;
        }
        else
            return false;
    }

    bool ThreeChainCheck_Right()
    {
		Block temp = BlockManager.Listof_Blocks[block_slot - 2].GetComponent<Block>();
		if (temp.get_HeroSlot() == hero_slot && TwoChainCheck_Right() && temp.get_Set())
        {
            return true;
        }
        else
            return false;
    }

	bool ThreeChainCheck_Middle()
	{
		if (TwoChainCheck_Left () && TwoChainCheck_Right ())
			return true;
		else
			return false;
	}

	public void Exit()
	{
		Destroy (gameObject);
	}
}
