using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunScript : MonoBehaviour
{
    public GameObject target;// the object we are stunning

    public int length;//the length of the stun being applied

    public GameObject originalPart;// the class that called this stun

    public int temp;// this stores what position in the classes effectors list this AOE is
    public void Stun()
	{
        Debug.Log("stun being applied for " + length.ToString());
        target.GetComponent<TargetScript>().Stun(length);
        originalPart.GetComponent<ClassManager>().NextComponent(transform.position, temp + 1, target);
        Destroy(gameObject);
    }
}
