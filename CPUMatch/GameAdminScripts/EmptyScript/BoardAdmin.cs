using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardAdmin : MonoBehaviour
{
    public bool isBoardAdminActivated = false;
    GameAdmin GA;
    public int cellRowID;
    public int cellColumnID;
    public int cellEffectNum;
    public int cellEffectNumtenPlace;
    public int cellEffectNumOnePlace;
    public Vector3 cellPos;
    GameObject originalCell;
    GameObject onBoardCell;
    GameObject instantiatedCell;
    GameObject PlayerPiece;
    GameObject Com1Piece;
    GameObject Com2Piece;
    GameObject Com3Piece;

    // Update is called once per frame
    private void Start()
    {
        GA = GameObject.Find("GameAdmin").GetComponent<GameAdmin>();
        PlayerPiece = GameObject.Find("PlayerPiece");
        Com1Piece = GameObject.Find("Com1Piece");
        Com2Piece = GameObject.Find("Com2Piece");
        Com3Piece = GameObject.Find("Com3Piece");

    }

    void Update()
    {
        if (isBoardAdminActivated)
            //GameAdminで、ゲームを開始する前にtrueになる。
        {
            isBoardAdminActivated = false;
            string loadProductString = PlayerPrefs.GetString("SaveData");
            SaveData.SampleMapData loadProductInstance = JsonUtility.FromJson<SaveData.SampleMapData>(loadProductString);
            for (int i = 0; i < loadProductInstance.pathList.Count; i++)
            {
                for (int j = 0; j < loadProductInstance.pathList[i].holdingCell.Count; j++)
                {
                    cellRowID = loadProductInstance.pathList[i].holdingCell[j].cordinates[0];
                    cellColumnID = loadProductInstance.pathList[i].holdingCell[j].cordinates[1];
                    cellEffectNum = loadProductInstance.pathList[i].holdingCell[j].effectNum;
                    cellEffectNumtenPlace = (cellEffectNum - (cellEffectNum % 10)) / 10;
                    cellEffectNumOnePlace = cellEffectNum % 10;
                    cellPos = new Vector3((cellColumnID * 13) - 100 , 1,(43 - ((cellRowID - 1) * 12)));
                    onBoardCell = GameObject.Find("OnBoardCells");

                    switch (cellEffectNumtenPlace)
                    {
                        case 0:
                            break;
                        case 1:
                            originalCell = GameObject.Find("NormalCell");
                            break;
                        case 2:
                            originalCell = GameObject.Find("BackwardCell");
                            break;
                        case 3:
                            originalCell = GameObject.Find("ForwardCell");
                            break;
                        case 4:
                            originalCell = GameObject.Find("BackToStartCell");
                            break;
                        case 5:
                            originalCell = GameObject.Find("StartCell");
                            PlayerPiece.transform.position = cellPos + new Vector3(-2, 1, -2);
                            Com1Piece.transform.position = cellPos + new Vector3(2, 1, 2);
                            Com2Piece.transform.position = cellPos + new Vector3(-2, 1, 2);
                            Com3Piece.transform.position = cellPos + new Vector3(2, 1, -2);
                            break;
                        case 6:
                            originalCell = GameObject.Find("GoalCell");
                            break;
                    }
                    InstantiateAndRenameBranch(originalCell, onBoardCell, ref instantiatedCell, i , j);
                }
            }
            GA.canGameAdminStart = true;
        }
    }

    public void InstantiateAndRenameBranch(GameObject originalCell, GameObject onBoardCell, ref GameObject instantiatedCell,int i, int j)
    {
        instantiatedCell = (Instantiate(originalCell, cellPos, Quaternion.identity, onBoardCell.transform));
        instantiatedCell.name = "Cell" + i + "" +  j;
    }


}
