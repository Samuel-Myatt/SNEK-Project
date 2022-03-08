using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBodyDynamic : MonoBehaviour
{
    [SerializeField] GameObject obj1;
    [SerializeField] GameObject obj2;
    [SerializeField] GameObject obj3;
    [SerializeField] GameObject obj4;
   
    SnakeManager snakeM;
    // Start is called before the first frame update
    void Start()
    {
        snakeM = GetComponent<SnakeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1"))
		{
            snakeM.AddBodyParts(obj1);
		}
        if (Input.GetKeyDown("2"))
        {
            snakeM.AddBodyParts(obj2);
        }
        if (Input.GetKeyDown("3"))
        {
            snakeM.AddBodyParts(obj3);
        }
        if (Input.GetKeyDown("4"))
        {
            snakeM.AddBodyParts(obj4);
        }
    }
}
