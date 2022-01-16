using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAdmin : MonoBehaviour
{
    public int turnNum;
    public int firstTurnNum;
    public bool[] Hasblocked = new bool[4];
    public bool PieceCanMove = true;
    //駒が動かせるかの真偽値を入れる。
    public bool isTurnStarted = false;
    public bool HasGivenPrmToRA = false;
    RoleAttach[] RA = new RoleAttach[4];
    GameAdmin GA;
    GameObject PlayerPiece;
    GameObject Com1Piece;
    GameObject Com2Piece;
    GameObject Com3Piece;
    string loadProductString;
    SaveData.SampleMapData loadProductInstance;
    enum CellTypeNum : int
    {
        Nothing = 0,
        Normal = 1,
        Backward = 2,
        Forward = 3,
        GoStart = 4,
        Start = 5,
        Goal = 6
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            RA[i] = GameObject.Find("Role" + i).GetComponent<RoleAttach>();
            Hasblocked[i] = false;
        }
        GA = GameObject.Find("GameAdmin").GetComponent<GameAdmin>();
        PlayerPiece = GameObject.Find("PlayerPiece");
        Com1Piece = GameObject.Find("Com1Piece");
        Com2Piece = GameObject.Find("Com2Piece");
        Com3Piece = GameObject.Find("Com3Piece");

        loadProductString = PlayerPrefs.GetString("SaveData");
        loadProductInstance = JsonUtility.FromJson<SaveData.SampleMapData>(loadProductString);
    }

    // Update is called once per frame
    void Update()
    {
        //二番目にここを通る。
        if (isTurnStarted)
        {
            isTurnStarted = false;
            RA[turnNum].turnNum = turnNum;
            RA[turnNum].isTurnStarted = true;
            //RAの内の一つへ飛ぶ。
        }
    }

    public void CheckIsLastTrun(int turnNum, int firstTurnNum)
    {
        if ((firstTurnNum + 3) % 4 == turnNum)
        //0(プレイヤー)のTurnNumが始まった時、終わりになるのは、3同様に、1なら2 2なら3 3なら0これを満たす条件式がこれ。
        {
            CheckPieceCanMove();
        }
        else
        {
            isTurnStarted = true;
        }
    }

    public void CheckPieceCanMove()
    {
        //最後にここに戻ってくる。
        string[] DebugName = new string[4];
        for (int i = 0; i < 4; i++)
        {
            Hasblocked[i] = false;
            //まず、親をブロックをした子ロールの真偽値を格納する変数をfalseに戻す。
        }

        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
            {
                DebugName[i] = "Player";
                Debug.Log(DebugName[i] + "の数字は、" + RA[i].choicedNum);
            }
            else
            {
                DebugName[i] = "Com" + i;
                Debug.Log(DebugName[i] + "の数字は、" + RA[i].choicedNum);
            }
        }

        PieceCanMove = true;

        for (int i = 0; i < 4; i++)
        {
            if (i != firstTurnNum)
            //親になっているロールと、その他のロールを比べるので、今親になっているロールの数を表すfirstTurnNum以外の場合としている。
            {
                if (RA[firstTurnNum].choicedNum == RA[i].choicedNum)
                {
                    PieceCanMove = false;
                    Hasblocked[i] = true;
                }
            }
        }

        StartCoroutine(MoveComCards(DebugName));
        
    }

    IEnumerator MoveComCards(string[] DebugName)
    {
        Debug.Log("これから、進行の判定を行います");
        //yield return new WaitForSeconds(1);
        GA.ChangeFrontText("これから、進行の判定を行います");
        yield return new WaitForSeconds(0.5f);
        GA.FadeOutfrontText();

        //yield return new WaitForSeconds(1);
        GA.ChangeFrontText("親のカードは・・・");
        yield return new WaitForSeconds(0.5f);
        GA.FadeOutfrontText();

        RA[firstTurnNum].MoveComCard(firstTurnNum, RA[firstTurnNum].choicedNum);
        //yield return new WaitForSeconds(1);
        GA.ChangeFrontText(RA[firstTurnNum].choicedNum + "でした！");
        yield return new WaitForSeconds(0.5f);
        GA.FadeOutfrontText();

        //yield return new WaitForSeconds(1);
        GA.ChangeFrontText("子の皆さんの予想したカードはこちら！");
        yield return new WaitForSeconds(0.5f);
        GA.FadeOutfrontText();


        for (int i = 1; i < 4; i++)
        {
            if(i != firstTurnNum)
            {
                RA[i].MoveComCard(i, RA[i].choicedNum);
                Debug.Log("Role" + i + "のカードが動きました");
            }
        }
        yield return new WaitForSeconds(0.5f);

        if (PieceCanMove)
        {
            Debug.Log(DebugName[firstTurnNum] + "はブロックされませんでした。" + RA[firstTurnNum].choicedNum + "マス進みます");
            GA.ChangeFrontText(DebugName[firstTurnNum] + "はブロックされませんでした。\n" + RA[firstTurnNum].choicedNum.ToString() + "マス進みます");

            //ここで進行処理
            int isGoalCheckNum;
            for (int i = 0; i< RA[firstTurnNum].choicedNum; i++)
            {
                isGoalCheckNum = PieceMoveForward(DebugName[firstTurnNum]);
                if(isGoalCheckNum == 1)
                {
                    break;
                }
                yield return new WaitForSeconds(0.5f);
            }

            //ここで、マスの処理
            GA.FadeOutfrontText();
            GA.ChangeFrontText(InvokeCellEffect(DebugName[firstTurnNum]));
            yield return new WaitForSeconds(0.5f);
            GA.FadeOutfrontText();

            yield return new WaitForSeconds(0.5f);
            
        }
        else
        {
            for (int j = 0; j < 4; j++)
            {
                if (Hasblocked[j])
                {
                    Debug.Log(DebugName[firstTurnNum] + "は、" + DebugName[j] + "に進行をブロックされました");
                    GA.ChangeFrontText(DebugName[firstTurnNum] + "は、\n" + DebugName[j] + "に進行をブロックされました");
                    yield return new WaitForSeconds(1);
                    GA.FadeOutfrontText();
                }
            }
        }

        if (PieceCanMove)
        {


            GA.choicedNum = RA[firstTurnNum].choicedNum;
        }

        GA.turnNum = ((GA.turnNum % 4) + 1) % 4;
        RA[0].ArrangePlayerCardToHomePos();
        for (int j = 1; j < 4; j++)
        {
            RA[j].GoBackComCard();
        }
        Debug.Log("ターンが終了しました。");
        GA.canGameAdminStart = true;
    }

    public int PieceMoveForward(string OyaPlayer)
    {

        int currentPathNum = RA[firstTurnNum].currentPathNum;
        int currentCellCount = RA[firstTurnNum].currentCellCount;
        int currentCellCordinateRowID = loadProductInstance.pathList[currentPathNum].holdingCell[currentCellCount].cordinates[0];
        int currentCellCordinateColumnID = loadProductInstance.pathList[currentPathNum].holdingCell[currentCellCount].cordinates[1];
        int nextPathNum;
        int nextCellCordinateRowID;
        int nextCellCordinateColumnID;
        int PathMaxCellCount = loadProductInstance.pathList[currentPathNum].holdingCell.Count;
        int tmpPathNum = 0;/*loadProductInstance.pathList[currentPathNum].nextPath.Count - 1;*/


        if (currentCellCount + 1 < PathMaxCellCount)
        {
            //同じパス内で進むとき
            nextCellCordinateRowID = loadProductInstance.pathList[currentPathNum].holdingCell[currentCellCount + 1].cordinates[0];
            nextCellCordinateColumnID = loadProductInstance.pathList[currentPathNum].holdingCell[currentCellCount + 1].cordinates[1];
            RA[firstTurnNum].currentCellCount += 1;
        }
        else
        {
            //一旦、ネクストパスの選択を固定にしている。nextPath[]の数字の中身を選択させることで、分岐を選択できるようにする。
            nextPathNum = loadProductInstance.pathList[currentPathNum].nextPath[tmpPathNum];
            nextCellCordinateRowID = loadProductInstance.pathList[nextPathNum].holdingCell[0].cordinates[0];
            nextCellCordinateColumnID = loadProductInstance.pathList[nextPathNum].holdingCell[0].cordinates[1];
            RA[firstTurnNum].pastPathNum.Add(nextPathNum);
            RA[firstTurnNum].currentPathNum = nextPathNum;
            if (loadProductInstance.pathList[currentPathNum].nextPath[0] == 0)
            {
                return 1;
            }
            RA[firstTurnNum].currentCellCount = 0;
        }
    

            if(currentCellCordinateRowID == nextCellCordinateRowID)
        {
            GameObject.Find(OyaPlayer + "Piece").transform.position += new Vector3(13 * (nextCellCordinateColumnID - currentCellCordinateColumnID), 0, 0);
        }
        else
        {
            GameObject.Find(OyaPlayer + "Piece").transform.position += new Vector3(0, 0, -12 * (nextCellCordinateRowID - currentCellCordinateRowID));
        }

        return 0;

    }

    public int PieceMoveBackward(string OyaPlayer)
    {
        int currentPathNum = RA[firstTurnNum].currentPathNum;
        int currentCellCount = RA[firstTurnNum].currentCellCount;
        int currentCellCordinateRowID = loadProductInstance.pathList[currentPathNum].holdingCell[currentCellCount].cordinates[0];
        //ここで、なんかエラー
        int currentCellCordinateColumnID = loadProductInstance.pathList[currentPathNum].holdingCell[currentCellCount].cordinates[1];
        int pastPathNumLastNum = RA[firstTurnNum].pastPathNum.Count - 1;
        //pastPathNumの最後のカウントから１を引いた数。要素数の最大値を取得するためのもの
        int previousPathNum = RA[firstTurnNum].pastPathNum[pastPathNumLastNum - 1];
        //カウントをそのまま入れちゃうと、配列に入れたらオーバーフローしちゃうので、いつもマイナス１して最後の数を表してた。最後の数よりももう一つ前なので、２を引く。
        //RAのpastPathNumは、これ。public List<int> pastPathNum = new List<int>() { 0 };
        int nextCellCordinateRowID;
        int nextCellCordinateColumnID;

        if(currentCellCount == 0)
        {
            //ひとつ前のカウントに戻る場合
            nextCellCordinateRowID = loadProductInstance.pathList[previousPathNum].holdingCell[0].cordinates[0];
            nextCellCordinateColumnID = loadProductInstance.pathList[previousPathNum].holdingCell[0].cordinates[1];
            RA[firstTurnNum].pastPathNum.RemoveAt(pastPathNumLastNum);
            RA[firstTurnNum].currentPathNum = previousPathNum;
            RA[firstTurnNum].currentCellCount = loadProductInstance.pathList[previousPathNum].holdingCell.Count-1;
            if ((RA[firstTurnNum].currentPathNum == 0) && (RA[firstTurnNum].currentCellCount == 0))
            {
                //スタート地点に戻った場合は、これ以上戻らないようにする。
                return 1;
            }
        }
        else
        {
            //現在のパスの中で戻る場合
            nextCellCordinateRowID = loadProductInstance.pathList[currentPathNum].holdingCell[currentCellCount - 1].cordinates[0];
            nextCellCordinateColumnID = loadProductInstance.pathList[currentPathNum].holdingCell[currentCellCount - 1].cordinates[1];
            RA[firstTurnNum].currentCellCount -= 1;
        }

        if (currentCellCordinateRowID == nextCellCordinateRowID)
        {
            //現在のRowと前のRowのIDが同じ場合は、Columnが変わっているということになる。
            GameObject.Find(OyaPlayer + "Piece").transform.position += new Vector3(13 * (nextCellCordinateColumnID - currentCellCordinateColumnID), 0, 0);
        }
        else
        {
            GameObject.Find(OyaPlayer + "Piece").transform.position += new Vector3(0, 0, -12 * (nextCellCordinateRowID - currentCellCordinateRowID));
        }

        return 0;
    }


        public string InvokeCellEffect(string OyaPlayer)
    {
        int currentPathNum = RA[firstTurnNum].currentPathNum;
        int currentCellCount = RA[firstTurnNum].currentCellCount;
        int currentCellEffectNum = loadProductInstance.pathList[currentPathNum].holdingCell[currentCellCount].effectNum;
        int cellEffectNumTenPlace = (currentCellEffectNum - (currentCellEffectNum % 10)) / 10;
        int cellEffectNumOnePlace = currentCellEffectNum % 10;

        Vector3 defaultPos = new Vector3(0, 0, 0);
        switch (firstTurnNum)
        {
            case 0:
                defaultPos = new Vector3(-2, 1, -2);
                break;
            case 1:
                defaultPos = new Vector3(2, 1, 2);
                break;
            case 2:
                defaultPos = new Vector3(-2, 1, 2);
                break;
            case 3:
                defaultPos = new Vector3(2, 1, -2);
                break;
        }


        switch (cellEffectNumTenPlace)
        {
            case (int)CellTypeNum.Nothing:
                return "エラーだわ、これ";
            case (int)CellTypeNum.Normal:
                return "つまんね";
            case (int)CellTypeNum.Backward:

                for (int i = 0; i < cellEffectNumOnePlace; i++)
                {
                    int isGoalCheckNum;
                    isGoalCheckNum = PieceMoveBackward(OyaPlayer);
                    if (isGoalCheckNum == 1)
                    {
                        return "はい、初めから";
                    }
                }

                return "ざまあ";
            case (int)CellTypeNum.Forward:
                for (int i = 0; i<cellEffectNumOnePlace; i++)
                {
                    int isGoalCheckNum;
                    isGoalCheckNum = PieceMoveForward(OyaPlayer);

                    if(isGoalCheckNum == 1)
                    {
                        return "おめー";
                    }
                }
                return "は？何進んでんだよ";
            case (int)CellTypeNum.GoStart:
                GameObject.Find(OyaPlayer + "Piece").transform.position = new Vector3((loadProductInstance.pathList[0].holdingCell[0].cordinates[1] * 13) - 100, 2, 43 - ((loadProductInstance.pathList[0].holdingCell[0].cordinates[0] - 1) * 12)) + defaultPos;
                RA[firstTurnNum].pastPathNum = new List<int>() { 0 };
                RA[firstTurnNum].currentPathNum = 0;
                RA[firstTurnNum].currentCellCount = 0;
                return "はい、初めから";
            case (int)CellTypeNum.Start:
                return "この文章も出たらエラーね。";
            case (int)CellTypeNum.Goal:
                return "おめー";
            default:
                return "これも出たらエラー";
        }    
    }

}
