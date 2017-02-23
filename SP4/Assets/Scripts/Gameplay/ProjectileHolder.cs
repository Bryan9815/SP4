using UnityEngine;
using System.Collections;

public class ProjectileHolder : MonoBehaviour 
{
    public GameObject projectile;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject Get_GameObject()
    {
        return projectile;
    }

    public void Set_GameObject(GameObject newGameobject)
    {
        projectile = newGameobject;
    }
}
