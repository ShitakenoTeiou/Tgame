using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    DontDestroyObj DDO;
    VH1 VH1;
    // Start is called before the first frame update
    void Start()
    {
        VH1 = GameObject.Find("DontDestroyObj").GetComponent<VH1>();
        VH1.a = 1;
        Debug.Log(VH1.b+"テストの方だよ");
        VH1.b = "Option";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
