using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegionNameAdmin : MonoBehaviour
{
    public InputField RegionInput;
    public string RegionName = "";
    public GameObject DDobj;
    // Start is called before the first frame update
    void Start()
    {
        DDobj = GameObject.Find("DontDestroyObj");
        RegionName = DDobj.GetComponent<DontDestroyObj>().UserRegion;
        RegionInput = GameObject.Find("RegionInput").GetComponent<InputField>();
        RegionInput.text = RegionName;
    }
        public void GetInputName()
    {
        RegionName = RegionInput.text;
        DDobj.GetComponent<DontDestroyObj>().UserRegion = RegionName;
    }
}
