using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Projectile")]
public class Classtype : ScriptableObject
{
   
    public bool instant;// whether a class uses its ability straight away or when it comes in range of an enemy

    public int chargeMax;// what the max charge value for the class ability is

    public int level;//the level of the class

    public int multiplier;// the multiplier for damage and stun 

    public string Name;//Name of class

    public string Description;//Description

    public List<int> ComponentParameters = new List<int>(6); //used to save parameters for components in ability
    public List<int> ComponentParameters2 = new List<int>(6);
    public List<int> ComponentParameters3 = new List<int>(6);
    public List<int> ComponentParameters4 = new List<int>(6);
    public List<int> ComponentParameters5 = new List<int>(6);
    public List<int> ComponentParameters6 = new List<int>(6);
    public List<int> ComponentParameters7 = new List<int>(6);
    public List<int> ComponentParameters8 = new List<int>(6);
    public List<int> ComponentParameters9 = new List<int>(6);

    public List<List<int>> lists = new List<List<int>>(20); //store the previous lists

    public List<GameObject> effectors;//a list of the 

}
