using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cellnamespace
{
    public class CellClass : MonoBehaviour
    {
        //初期に作ったクラス
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

        private int cellPosNum;
        private Vector3 cellPos;
        private int cellTypeNum;
        private string cellTypeStr;

        public CellClass(int cellPosNum, int cellTypeNum)
        {
            Debug.Log("CellClass has been instantiated");
            this.cellPosNum = cellPosNum;
            this.cellTypeNum = cellTypeNum;
            cellPos = new Vector3((13 * ((cellPosNum - (cellPosNum % 8)) / 8)) - 100, 1, 56 - (13 * (cellPosNum % 8)));
        }

        public void InstantiateCellObject(int cellTypeNum)
        {
            int cellTypeNumTenPlace;
            int cellTypeNumOnePlace;
            GameObject originalCell;
            GameObject instantiatedCell;
            GameObject onBoardCell;

            instantiatedCell = null;
            cellTypeNumTenPlace = (cellTypeNum - (cellTypeNum % 10)) / 10;
            cellTypeNumOnePlace = cellTypeNum % 10;
            onBoardCell = GameObject.Find("OnBoardCells");

            switch (cellTypeNumTenPlace)
            {
                case 0:
                    break;
                case 1:
                    Debug.Log("Normal");
                    originalCell = GameObject.Find("NormalCell");
                    InstantiateAndRenameBranch(originalCell, onBoardCell, ref instantiatedCell);
                    //instantiatedCell = (Instantiate(originalCell, cellPos, Quaternion.identity, onBoardCell.transform));
                    //instantiatedCell.name = "Cell" + cellPosNum;
                    break;
                case 2:
                    originalCell = GameObject.Find("BackwardCell");
                    InstantiateAndRenameBranch(originalCell, onBoardCell, ref instantiatedCell);
                    //instantiatedCell.GetComponent<BackwardCellAttach>().eventmoveNum = cellTypeNumOnePlace;
                    break;
                case 3:
                    originalCell = GameObject.Find("ForwardCell");
                    InstantiateAndRenameBranch(originalCell, onBoardCell, ref instantiatedCell);
                    //instantiatedCell.GetComponent<ForawardCellAttach>().eventmoveNum = cellTypeNumOnePlace;
                    break;
                case 4:
                    originalCell = GameObject.Find("BackToStartCell");
                    InstantiateAndRenameBranch(originalCell, onBoardCell, ref instantiatedCell);
                    break;
                case 5:
                    originalCell = GameObject.Find("GoalCell");
                    InstantiateAndRenameBranch(originalCell, onBoardCell, ref instantiatedCell);
                    break;
                case 6:
                    originalCell = GameObject.Find("StartCell");
                    InstantiateAndRenameBranch(originalCell, onBoardCell, ref instantiatedCell);
                    break;

            }
        }

        public void InstantiateAndRenameBranch(GameObject originalCell, GameObject onBoardCell, ref GameObject instantiatedCell)
        {
            instantiatedCell = (Instantiate(originalCell, cellPos, Quaternion.identity, onBoardCell.transform));
            instantiatedCell.name = "Cell" + cellPosNum;
        }
    }

    
}

