using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreSaveData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string loadProductString = PlayerPrefs.GetString("SaveData");
        SaveData.SampleMapData loadProductInstance = JsonUtility.FromJson<SaveData.SampleMapData>(loadProductString);
        for (int i = 0; i < loadProductInstance.pathList.Count; i++)
        {
            for (int j = 0; j < loadProductInstance.pathList[i].nextPath.Count; j++)
            {
                Debug.Log("loadProductInstance.pathList[" + i + "].nextPath[" + j + "]の値：" + loadProductInstance.pathList[i].nextPath[j]);
            }
        }

    }
}
