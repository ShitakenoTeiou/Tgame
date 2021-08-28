using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserNameAdmin : MonoBehaviour
{
    public InputField UserNameInput;
    public string UserName = "";
    public GameObject DDobj;

    // Start is called before the first frame update
    void Start()
    {
        DDobj = GameObject.Find("DontDestroyObj");
        UserName = DDobj.GetComponent<DontDestroyObj>().UserName;
        UserNameInput = GameObject.Find("UserNameInput").GetComponent<InputField>();
        UserNameInput.text = UserName;
    }

    public void GetInputName()
    {
        UserName = UserNameInput.text;
        DDobj.GetComponent<DontDestroyObj>().UserName = UserName;

    }

}
