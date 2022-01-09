using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SaveData
{
    [System.Serializable]
    public class SampleMapData
    {
        public List<Path> pathList = new List<Path>();
    }

    [System.Serializable]
    public class Path
    {
        public List<int> nextPath = new List<int>();
        public List<Cell> holdingCell = new List<Cell>();

        public Path(List<int> nextPath, List<Cell> holdingCell)
        {
            this.nextPath = nextPath;
            this.holdingCell = holdingCell;
        }
    }

    [System.Serializable]
    public class Cell
    {
        public int[] cordinates = new int[2];
        public int effectNum;

        public Cell(int[] cordinates, int effectNum)
        {
            this.cordinates = cordinates;
            this.effectNum = effectNum;
        }
    }
}