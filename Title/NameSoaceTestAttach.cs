using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using testnamespace;

public class NameSoaceTestAttach : MonoBehaviour
{
    testnamespace.testnamespace A = new testnamespace.testnamespace();
    // Start is called before the first frame update
    void Start()
    {

        A.Name = "hiroto";
        A.Age = 24;
        A.ShowAgeAndName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
