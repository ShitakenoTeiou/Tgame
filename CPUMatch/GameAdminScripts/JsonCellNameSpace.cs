using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JsonCellNameSpace
{
   
    public class CellForConvertingJson
    {
        public int posID;
        //0~136までの数で定義。二次元配列にjsonが対応してないので。
        public int janctionID;
        //分岐IDを定義
        public int junctionOrderNum;
        //分岐の中で何番目のマスなのかを定義
        public int cellTypeNum = 0;
        //マスの種類を定義する

        public void getCellField(int posID, int janctionID, int junctionOrderNum, int cellTypeNum)
        {
            this.posID = posID;
            this.janctionID = janctionID;
            this.junctionOrderNum = junctionOrderNum;
            this.cellTypeNum = cellTypeNum;
        }
    }

    public class JunctionForConvertingJson
    {
        //各々できる度にクラスをインスタンス化する。ジャンクション番号ごとに。
        public int junctionNum;
        public List<int> nextJunctionNum = new List<int>();
        public List<int> junction = new List<int>();

        public void getjunctionField(int junctionNum, List<int> junction)
        {
            this.junctionNum = junctionNum;
            this.junction = junction;
        }
    }
    
}
