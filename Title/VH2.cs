using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VH2 : MonoBehaviour
{
    int a = 1;
    string b = "bだよ";
    VH1 VH1;
    GameObject VH1obj;
    // Start is called before the first frame update
    void Start()
    {
        VH1obj = GameObject.Find("DontDestroyObj");
        VH1 = VH1obj.GetComponent<VH1>();

        a += 1;
        Debug.Log(a + b);
        string VH1b = VH1.b;
        Debug.Log(VH1.a);
        Debug.Log(VH1b);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
