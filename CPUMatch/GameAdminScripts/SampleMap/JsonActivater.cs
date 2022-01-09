using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonActivater : MonoBehaviour
{
    const int MapRow = 8;
    const int MapColumn = 17;
    const int pathCount = 7;

    public SaveData.SampleMapData SMD = new SaveData.SampleMapData();
    public SaveData.Path[] pathArr = new SaveData.Path[pathCount];
    List<SaveData.Cell>[] cellInstanceList = new List<SaveData.Cell>[pathCount];

    public int[] cellEffectNumArr;

    List<int>[] nextPathID = new List<int>[100];
    int[] aCellCordinate = new int[2];
    SaveData.Cell aCellInstance;



    public void Start()
    {
        for (int i = 0; i < pathCount; i++)
        {
            cellInstanceList[i] = new List<SaveData.Cell>();
        }
        SetMapData();
        for (int i = 0; i < pathCount; i++)
        {
            SMD.pathList.Add(pathArr[i]);
        }

        Debug.Log(JsonUtility.ToJson(SMD));
        PlayerPrefs.SetString("SaveData", JsonUtility.ToJson(SMD));
    }

    public void SetMapData()
    {
        //サンプルマップの内容データを以下に定義する。

        //まずは、次のパスのID
        nextPathID[0] = new List<int>() { 1, 2 };
        nextPathID[1] = new List<int>() { 4 };
        nextPathID[2] = new List<int>() { 3, 5 };
        nextPathID[3] = new List<int>() { 4 };
        nextPathID[4] = new List<int>() { 6 };
        nextPathID[5] = new List<int>() { 6 };
        nextPathID[6] = new List<int>() { 0 };

        //次に、セルの座標について

        //Path0
        InstantiateCell(0, 7, 0);
        InstantiateCell(0, 7, 1);
        InstantiateCell(0, 7, 2);

        //Path1
        InstantiateCell(1, 6, 2);
        InstantiateCell(1, 5, 2);
        InstantiateCell(1, 4, 2);
        InstantiateCell(1, 3, 2);
        InstantiateCell(1, 2, 2);
        InstantiateCell(1, 2, 3);
        InstantiateCell(1, 2, 4);
        InstantiateCell(1, 2, 5);
        InstantiateCell(1, 2, 6);
        InstantiateCell(1, 3, 6);

        //Path2
        InstantiateCell(2, 7, 3);
        InstantiateCell(2, 7, 4);

        //Path3
        InstantiateCell(3, 6, 4);
        InstantiateCell(3, 5, 4);
        InstantiateCell(3, 4, 4);
        InstantiateCell(3, 4, 5);

        //Path4
        InstantiateCell(4, 4, 6);
        InstantiateCell(4, 4, 7);
        InstantiateCell(4, 4, 8);
        InstantiateCell(4, 5, 8);
        InstantiateCell(4, 6, 8);

        //Path5
        InstantiateCell(5, 7, 5);
        InstantiateCell(5, 7, 6);
        InstantiateCell(5, 7, 7);

        //Path6
        InstantiateCell(6, 7, 8);
        InstantiateCell(6, 7, 9);
        InstantiateCell(6, 7, 10);
        InstantiateCell(6, 7, 11);
        InstantiateCell(6, 6, 11);
        InstantiateCell(6, 5, 11);
        InstantiateCell(6, 4, 11);
        InstantiateCell(6, 3, 11);
        InstantiateCell(6, 2, 11);
        InstantiateCell(6, 2, 10);
        InstantiateCell(6, 2, 9);
        InstantiateCell(6, 2, 8);

        for (int i = 0; i < pathCount; i++)
        {
            pathArr[i] = new SaveData.Path(nextPathID[i], cellInstanceList[i]);
        }
    }

    public void InstantiateCell(int pathID, int row, int column)
    {
        int cellID;
        cellID = (row * MapColumn) + column;

        cellEffectNumArr = new int[136]
                            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0,10,23,10,10,10, 0,60,10,10,40, 0, 0, 0, 0, 0,
                             0, 0,40, 0, 0, 0,10, 0, 0, 0, 0,10, 0, 0, 0, 0, 0,
                             0, 0,10, 0,10,10,25,10,10, 0, 0,32, 0, 0, 0, 0, 0,
                             0, 0,32, 0,40, 0, 0, 0,40, 0, 0,25, 0, 0, 0, 0, 0,
                             0, 0,10, 0,10, 0, 0, 0,25, 0, 0,40, 0, 0, 0, 0, 0,
                            50,10,10,33,10,40,10,25,10,10,33,10, 0, 0, 0, 0, 0};

        aCellCordinate = new int[2] { row, column };
        aCellInstance = new SaveData.Cell(aCellCordinate, cellEffectNumArr[cellID]);

        cellInstanceList[pathID].Add(aCellInstance);
    }
}
