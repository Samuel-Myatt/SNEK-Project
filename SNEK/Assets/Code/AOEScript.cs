using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEScript : MonoBehaviour
{
    public int sizeX;// the size of the AOE

    public int sizeY;// the size of the AOE

    public int delay;//the ammount of time till the AOE dissapears

    public GameObject originalPart;// this stores the gameobject class that the AOE was spawned by

    public int temp;// this stores what position in the classes effectors list this AOE is

    void Start()
    { 
        Vector3 local = transform.localScale;

        transform.localScale = new Vector3(sizeX, sizeY, 0); //used to set the size

        WaitAndDestroy();//used to destroy the AOE after delay ammount of time
    }

    public void WaitAndDestroy()
    {
        Destroy(gameObject, delay);
        
    }

    void OnTriggerEnter2D(Collider2D col)// when an enemy enters the AOE
    {
        if(col.gameObject.tag == "Enemy")
		{
            Effector(col.gameObject);
            Debug.Log("Enemy Detected");
		}
    }

    public void Effector(GameObject col)
	{
        originalPart.GetComponent<ClassManager>().NextComponent(transform.position, (temp+1), col);// call the next effector
    }
}
