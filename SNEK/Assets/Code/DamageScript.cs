using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public GameObject target;// the object we are damaging

    public int ammount;//the ammount of the damage being applied

    public GameObject originalPart;// the class that called this stun

    public int temp;// this stores what position in the classes effectors list this AOE is

    public void Damage()
	{
        Debug.Log("applying " + ammount.ToString() + " damage");
        target.GetComponent<TargetScript>().TakeDamage(ammount);
        originalPart.GetComponent<ClassManager>().NextComponent(transform.position, temp + 1, target);
        Destroy(gameObject);
    }
}
