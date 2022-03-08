using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TargetScript : MonoBehaviour
{
    public int maxHealth;// the max health of the target

    public int currentHealth;//the current health

    public bool stunned = false;//whether the target is stunned
    public void TakeDamage(int dam)//take damage
	{
        Debug.Log("Target taking " + dam.ToString() + " damage");
        currentHealth -= dam;

	}
    void Heal(int heal)//heal the target
	{
        currentHealth = +heal;
	}
    public void Stun(int dur)//stun the target
	{
        Debug.Log("Target taking " + dur.ToString() + " stun");
        stunned = true;
        Invoke(nameof(Unstun), dur);
    }
    public void Unstun()//unstun the target
	{
        Debug.Log("Unstunned");
        stunned = false;
	}
}
