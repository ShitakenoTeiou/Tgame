using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Text.Json;

public class JsonTest2 : MonoBehaviour
{
    public string jsonStr;

    private void Start()
    {
        jsonTest.JsonTestNSClass JTC = new jsonTest.JsonTestNSClass();
        Debug.Log(JsonUtility.ToJson(JTC));
        Debug.Log("JsonUtilityのやつ起動したよ。");
    }
}
