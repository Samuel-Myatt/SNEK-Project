using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreationScript : MonoBehaviour
{
    public GameObject bodyTemplate;
    public GameObject AOEPrefab;
    public GameObject ProjectilePrefab;
    public GameObject StunPrefab;
    public GameObject DamagePrefab;

    GameObject newClass;

    ClassManager script;

    public int compCounter = 0;

    public int parameterAOE1;
    public int parameterAOE2;
    public int parameterAOE3;

    public int parameterPROJ1;
    public int parameterPROJ2;
    public int parameterPROJ3;
    public int parameterPROJ4;


    public int parameterDAM1;
    public int parameterSTUN1;


    public List<int> temp = new List<int>(6);




    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
           

            CreateClass();

            
            AddComponent(ProjectilePrefab);
            AddComponent(AOEPrefab);
            AddComponent(StunPrefab);

            
            Save();
        }
    }

    public void CreateClass()
	{
        newClass = Instantiate(bodyTemplate, transform.position, Quaternion.identity);
        script = newClass.GetComponent<ClassManager>();
        script.scriptable.instant = false;
        script.scriptable.chargeMax = 40;


 
	}

    public void AddComponent(GameObject component)
	{
        script = newClass.GetComponent<ClassManager>();
        script.scriptable.effectors[compCounter] = component;
        

        if(component == AOEPrefab)
		{
            temp.Add(parameterAOE1);
            temp.Add(parameterAOE2);
            temp.Add(parameterAOE3);

        }
        else if(component == ProjectilePrefab)
		{
            temp.Add(parameterPROJ1);
            temp.Add(parameterPROJ2);
            temp.Add(parameterPROJ3);
            temp.Add(parameterPROJ4);
            
        }
        else if (component == DamagePrefab)
        {
            temp.Add(parameterDAM1);
        }
        else if (component == StunPrefab)
        {
            temp.Add(parameterSTUN1);
        }
		for (int i = 0; i < temp.Count; i++)
		{
            script.scriptable.lists[compCounter].Add(temp[i]);
		}
        temp = new List<int>(6);
        //script.lists[compCounter] = temp;
        compCounter++;
    }

    public void Save()
	{
        string localPath = "Assets/" + gameObject.name + ".prefab";

        localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);

        PrefabUtility.SaveAsPrefabAssetAndConnect(newClass, localPath, InteractionMode.UserAction);

        Destroy(newClass);
    }
}
