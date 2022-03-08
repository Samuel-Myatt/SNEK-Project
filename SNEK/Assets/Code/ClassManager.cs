using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassManager : MonoBehaviour
{
    public Classtype scriptable;//the scriptable object that stores the class data

    public int[,] parameters;// a 2d array that stores the components parameters

    public GameObject AOEPrefab;//the possible components for the classes abilities are stored here in prefabs
    public GameObject ProjectilePrefab;
    public GameObject StunPrefab;
    public GameObject DamagePrefab;

    public Slider slider;//the slider for the charge of the ability

    public int chargeCurrent = 0;//the current charge

    float buffer = 0;// the buffer used for charging up the ability

    public List<List<int>> lists = new List<List<int>>(20);// stores the lists for the component parameters

    List<int> temporary = new List<int>(6);
    
	public void Awake()
	{
        parameters = new int[20, 20];
        lists.Add(scriptable.ComponentParameters);
        lists.Add(scriptable.ComponentParameters2);
        lists.Add(scriptable.ComponentParameters3);
        lists.Add(scriptable.ComponentParameters4);
        lists.Add(scriptable.ComponentParameters5);
        lists.Add(scriptable.ComponentParameters6);
        lists.Add(scriptable.ComponentParameters7);
        lists.Add(scriptable.ComponentParameters8);
        lists.Add(scriptable.ComponentParameters9);

		for (int j = 0; j < scriptable.effectors.Count; j++)// this stores the component parameters into the parameters 2d array
		{
            temporary = lists[j];
            for (int i = 0; i < temporary.Count; i++)
            {
                parameters[j, i] = temporary[i];
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        chargeIncrament();//incrament the charge of the ability
        if((scriptable.instant) && (chargeCurrent == scriptable.chargeMax))// if the ability activates instantly and is ready to activate
		{
            Debug.Log("Using Ability");
            chargeCurrent = 0;//set charge to 0
            slider.value = chargeCurrent;   //update slider
            NextComponent(transform.position, 0,this.gameObject);//activate 
		}
    }

    public void NextComponent(Vector3 pos, int counter, GameObject target)// this is the system that runs each component 
	{
        if(counter < scriptable.effectors.Count)// if there is another component to be used
		{
            if (scriptable.effectors[counter] == AOEPrefab)//first we check for what type of component it is
            {
                Debug.Log("Creating AOE");
                GameObject component = Instantiate(scriptable.effectors[counter], pos, Quaternion.identity);//create the prefab of the component
                component.GetComponent<AOEScript>().originalPart = this.gameObject;
                component.GetComponent<AOEScript>().temp = counter;
                component.GetComponent<AOEScript>().sizeX = parameters[counter, 0];
                component.GetComponent<AOEScript>().sizeY = parameters[counter, 1];
                component.GetComponent<AOEScript>().delay = parameters[counter, 2];//set the parameters of the component to be that of what was set in the scriptable object

            }
            else if (scriptable.effectors[counter] == ProjectilePrefab)
            {
                Debug.Log("Creating Projectile");
                GameObject component = Instantiate(scriptable.effectors[counter], pos, Quaternion.identity);
                component.GetComponent<ProjectileScript>().originalPart = this.gameObject;
                component.GetComponent<ProjectileScript>().temp = counter;
                component.GetComponent<ProjectileScript>().sizeX = parameters[counter, 0];
                component.GetComponent<ProjectileScript>().sizeY = parameters[counter, 1];
                component.GetComponent<ProjectileScript>().speed = parameters[counter, 2];
                component.GetComponent<ProjectileScript>().delay = parameters[counter, 3];
            }
            else if (scriptable.effectors[counter] == StunPrefab)
            {
                Debug.Log("Creating Stun");
                GameObject component = Instantiate(scriptable.effectors[counter], pos, Quaternion.identity);
                component.GetComponent<StunScript>().target = target;
                component.GetComponent<StunScript>().length = (parameters[counter, 0] * (scriptable.multiplier * scriptable.level));
                component.GetComponent<StunScript>().temp = counter;
                component.GetComponent<StunScript>().originalPart = this.gameObject;
                component.GetComponent<StunScript>().Stun();

            }
            else if (scriptable.effectors[counter] == DamagePrefab)
            {
                Debug.Log("Creating Damage");
                GameObject component = Instantiate(scriptable.effectors[counter], pos, Quaternion.identity);
                component.GetComponent<DamageScript>().target = target;
                component.GetComponent<DamageScript>().ammount = (parameters[counter, 0] * (scriptable.multiplier * scriptable.level)); ;
                component.GetComponent<DamageScript>().temp = counter;
                component.GetComponent<DamageScript>().originalPart = this.gameObject;
                component.GetComponent<DamageScript>().Damage();
            }
        }
    }

    void chargeIncrament()//incraments the charge
    {
        buffer++;
        if (buffer == 120)
        {
            buffer = 0;
            if (chargeCurrent < scriptable.chargeMax)
            {
                chargeCurrent++;
                slider.value = chargeCurrent;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)// if the ability isn't on instant then it will trigger when an enemy is in range
    {
        if ((!scriptable.instant) && (chargeCurrent == scriptable.chargeMax))
		{
            if (col.gameObject.tag == "Enemy")
            {
                Debug.Log("Using Ability");
                chargeCurrent = 0;
                if(scriptable.effectors[0] == ProjectilePrefab)
				{
                    NextComponent(transform.position, 0, col.gameObject);
                }
                else
				{
                    NextComponent(col.transform.position, 0, col.gameObject);
                }
                
            }
        }
        
    }
}
