using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardAdmin : MonoBehaviour
{
    FetchMapSet FMS;
    enum CellTypeNum : int
    {
        Nothing = 0,
        Normal = 10,
        Backward1 = 21,
        Backward2 = 22,
        Backward3 = 23,
        Backward4 = 24,
        Backward5 = 25,
        Backward6 = 26,
        Forward1 = 31,
        Forward2 = 32,
        Forward3 = 33,
        Forward4 = 34,
        Forward5 = 35,
        Forward6 = 36,
        GoStart = 40,
        Start = 50,
        Goal = 60
    }

    int[] cellType = new int[136]
    {
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0,10,23,10,10,10, 0,60,10,10,40, 0, 0, 0, 0, 0,
        0, 0,40, 0, 0, 0,10, 0, 0, 0, 0,10, 0, 0, 0, 0, 0,
        0, 0,10, 0,10,10,24,10,10, 0, 0,32, 0, 0, 0, 0, 0,
        0, 0,33, 0,40, 0, 0, 0,40, 0, 0,34, 0, 0, 0, 0, 0,
        0, 0,10, 0,10, 0, 0, 0,35, 0, 0,40, 0, 0, 0, 0, 0,
       50,10,10,35,10,40,10,34,10,10,32,10, 0, 0, 0, 0, 0,
    };
    List<int>[] junctionList = new List<int>[70];
    List<int>[] junctionConnect = new List<int>[70];
    //Cellnamespace.CellForConvertingJson[] CFCJ = new Cellnamespace.CellForConvertingJson[136];
    //Cellnamespace.JunctionForConvertingJson[] JFCJ = new Cellnamespace.JunctionForConvertingJson[70];
    // Start is called before the first frame update
    void Start()
    {
        junctionList[0] = new List<int>() { 119, 120, 121 };
        junctionList[1] = new List<int>() { 104, 87, 70, 53, 36, 37, 38, 39, 40, 57 };
        junctionList[2] = new List<int>() { 122, 123 };
        junctionList[3] = new List<int>() { 106, 89, 72, 73 };
        junctionList[4] = new List<int>() { 74, 75, 76, 93, 110 };
        junctionList[5] = new List<int>() { 124, 125, 126 };
        junctionList[6] = new List<int>() { 127, 128, 129, 130, 113, 96, 79, 62, 45, 44, 43, 42 };
        
        for(int i =7; i<70; i++)
        {
            junctionList[i] = new List<int>();
        }

        junctionConnect[0] = new List<int>() { 1, 2 };
        junctionConnect[1] = new List<int>() { 4 };
        junctionConnect[2] = new List<int>() { 3, 5 };
        junctionConnect[3] = new List<int>() { 4 };
        junctionConnect[4] = new List<int>() { 6 };
        junctionConnect[5] = new List<int>() { 6 };
        junctionConnect[6] = new List<int>() { 0 };

        //for (int i = 7; i < 70; i++)
        //{
        //    junctionConnect[i] = new List<int>();
        //}

        //for (int i = 0; i < 136; i++)
        //{
        //    CFCJ[i] = new Cellnamespace.CellForConvertingJson();
        //    CFCJ[i].cellTypeNum = cellType[i];
        //}

        //for(int i = 0; i < 70; i++)
        //{
        //    if (junctionList[i].Count != 0)
        //    {
        //        JFCJ[i] = new Cellnamespace.JunctionForConvertingJson();
        //        JFCJ[i].junctionNum = i;
        //        JFCJ[i].junction = junctionList[i];
        //        JFCJ[i].nextJunctionNum = junctionConnect[i];
        //        for (int j = 0; j < junctionConnect[i].Count; j++)
        //        {
        //            CFCJ[junctionConnect[i][j]].janctionID = i;
        //            CFCJ[junctionConnect[i][j]].junctionOrderNum = j;
        //        }
        //    }
        //    else
        //    {
        //        break;
        //    }
        //}

        //Debug.Log("BoardAdmin準備完了");
        //Debug.Log(JsonUtility.ToJson(this));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
