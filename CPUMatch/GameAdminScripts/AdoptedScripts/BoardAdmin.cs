using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardAdmin : MonoBehaviour
{
    public bool isBoardAdminActivated = false;
    GameAdmin GA;
    public int cellRow;
    public int cellColumn;
    public int cellEffectNum;
    // Update is called once per frame
    private void Start()
    {
        GA = GameObject.Find("GameAdmin").GetComponent<GameAdmin>();
    }

    void Update()
    {
        if (isBoardAdminActivated)
        {
            isBoardAdminActivated = false;
            string loadProductString = PlayerPrefs.GetString("SaveData");
            SaveData.SampleMapData loadProductInstance = JsonUtility.FromJson<SaveData.SampleMapData>(loadProductString);
            for (int i = 0; i < loadProductInstance.pathList.Count; i++)
            {
                for (int j = 0; j < loadProductInstance.pathList[i].holdingCell.Count; j++)
                {
                    cellRow = loadProductInstance.pathList[i].holdingCell[j].cordinates[0];
                    cellColumn = loadProductInstance.pathList[i].holdingCell[j].cordinates[1];
                    cellEffectNum = loadProductInstance.pathList[i].holdingCell[j].effectNum;
                }
            }

            GA.canGameAdminStart = true;
        }
    }

    public void InstantiateCells(int row, int column, GameObject originalCell)
    {

    }
}
