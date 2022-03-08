using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public int delay;//the ammount of time till the AOE dissapears

    public GameObject Target;// the object the projectile is shot at

    public int sizeX;// the size of the AOE

    public int sizeY;// the size of the AOE

    public float speed;//the speed of the projectile

    public GameObject originalPart;// this stores the gameobject class that the AOE was spawned by

    public int temp;// this stores what position in the classes effectors list this AOE is

    // Start is called before the first frame update
    void Start()
    {
        Vector3 local = transform.localScale;

        transform.localScale = new Vector3(sizeX, sizeY, 0);//used to set the size

        Target = GameObject.FindGameObjectWithTag("Enemy");// just sets the target to an object with the tag enemey for testing

        WaitAndDestroy();//used to destroy the AOE after delay ammount of time
    }


    // Update is called once per frame
    void Update()
    {
        Move();//moves the projectile
    }

    public void Move()
    {
        Vector3 dir = Target.transform.position - transform.position ;
        // Normalize resultant vector to unit Vector
        dir = dir.normalized;
        // Move in the direction of the direction vector every frame 
        transform.position += dir * Time.deltaTime * speed;
    }

    public void WaitAndDestroy()
    {
        Destroy(gameObject, delay);
    }

    void OnTriggerEnter2D(Collider2D col)// when the projectile hits the enemy
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("Projectile hit");
            Effector(col.gameObject);
        }
    }

    public void Effector(GameObject col)
    { 
        originalPart.GetComponent<ClassManager>().NextComponent(transform.position, temp+1, col);
        Destroy(gameObject);// call the next effector
    }
}

