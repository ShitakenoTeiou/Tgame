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
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            RA[i] = GameObject.Find("Role" + i).GetComponent<RoleAttach>();
            Hasblocked[i] = false;
        }
        GA = GameObject.Find("GameAdmin").GetComponent<GameAdmin>();
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
                DebugName[i] = "プレイヤー";
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
        yield return new WaitForSeconds(1);
        GA.ChangeFrontText("これから、進行の判定を行います");
        yield return new WaitForSeconds(1);
        GA.FadeOutfrontText();

        yield return new WaitForSeconds(1);
        GA.ChangeFrontText("親のカードは・・・");
        yield return new WaitForSeconds(1);
        GA.FadeOutfrontText();

        RA[firstTurnNum].MoveComCard(firstTurnNum, RA[firstTurnNum].choicedNum);
        yield return new WaitForSeconds(1);
        GA.ChangeFrontText(RA[firstTurnNum].choicedNum + "でした！");
        yield return new WaitForSeconds(1);
        GA.FadeOutfrontText();

        yield return new WaitForSeconds(1);
        GA.ChangeFrontText("子の皆さんの予想したカードはこちら！");
        yield return new WaitForSeconds(1);
        GA.FadeOutfrontText();


        for (int i = 1; i < 4; i++)
        {
            if(i != firstTurnNum)
            {
                RA[i].MoveComCard(i, RA[i].choicedNum);
                Debug.Log("Role" + i + "のカードが動きました");
            }
            

        }
        yield return new WaitForSeconds(1);

        if (PieceCanMove)
        {
            Debug.Log(DebugName[firstTurnNum] + "はブロックされませんでした。" + RA[firstTurnNum].choicedNum + "マス進みます");
            GA.ChangeFrontText(DebugName[firstTurnNum] + "はブロックされませんでした。\n" + RA[firstTurnNum].choicedNum.ToString() + "マス進みます");
            yield return new WaitForSeconds(2);
            GA.FadeOutfrontText();
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
}
