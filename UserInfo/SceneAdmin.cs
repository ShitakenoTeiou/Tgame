using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAdmin : MonoBehaviour
{
    UserNameAdmin UNA;
    RegionNameAdmin RNA;
    string UserName;
    string RegionName;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UserName = UNA.UserName;
    }
}
