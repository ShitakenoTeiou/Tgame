using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleAttach : MonoBehaviour
{
    public bool isCom = true;
    public bool isTurnStarted = false;
    public bool hasFinishedChoicing = false;
    public bool isNumChoiced = false;
    public int turnNum;
    //GameAdminから来る値
    public int roleNum;
    //Comの何番目か、もしくは、プレイヤーかを判断する値。
    public int choicedNum;
    public string roleName;
    public Vector3 nowPos;
    public int currentPathNum = 0;
    //何番目の分岐かを表す。
    public int currentCellCount = 0;
    //分岐の中の何番目のマスなのかを表す。
    public int turnCount;
    //０からスタートして、4人分回って自分の番になったら、０に戻る。

    GameObject[] CPUCards = new GameObject[6];
    Vector3[] CPUDefPos = new Vector3[6];
    TurnAdmin TA;
    PCardAttach[] PCA = new PCardAttach[6];

    public List<int> pastPathNum = new List<int>() ;

    // Start is called before the first frame update
    void Start()
    {
        roleName = this.gameObject.name;
        roleNum = int.Parse(roleName.Substring(roleName.Length - 1, 1));
        if (roleName == "Role0")
        {
            isCom = false;
        }

        for (int i=0; i < 6; i++)
        {
            if(isCom)
            {
                CPUCards[i] = GameObject.Find("C" + roleNum + "Card" + (i + 1));
                //Debug.Log(this.name + "の" + i + "回目");
                //Debug.Log(CPUCards[i].name);
                CPUDefPos[i] = CPUCards[i].transform.position;
            }
            else
            {
                PCA[i] = GameObject.Find("PlayerCard" + (i + 1)).GetComponent<PCardAttach>();
            }
        }

        TA = GameObject.Find("TurnAdmin").GetComponent<TurnAdmin>();
    }

    // Update is called once per frame
    void Update()
    {
        //三番目にここを通る。
        if (isTurnStarted)
        //TurnAdminから、Trueにされて入れるようになる。isTurnStartedは、値を渡す中で最後にしないといけない。
        {
            isTurnStarted = false;
            ConvertTurnNumToIsCom(turnNum);
            //TurnAdminから値を受け取るので、その番号をComかどうかの判別に使う。0とelseでもいいけど後で見た時に分かりやすいので変数isComを作る。
            if (isCom)
            {
                //CPU（Role１～３）にアタッチされている場合
                choicedNum = Random.Range(1, 7);
                Debug.Log("Com" + roleNum + "は、" + choicedNum + "を選択しました。");
                //MoveComCard(roleNum,choicedNum);
                hasFinishedChoicing = true;
            }
            else
            {
                //プレイヤー（Role0）にアタッチされている場合
                TurnOnPCACanMove();
            }
        }

        if (hasFinishedChoicing)
        //PCardAttachから真偽値を受け取る。もしくは、isComから来る。
        {
            hasFinishedChoicing = false;
            TA.CheckIsLastTrun(TA.turnNum, TA.firstTurnNum);
            Debug.Log("LastTrun判定されました");
            TA.turnNum = ((TA.turnNum % 4) + 1) % 4;
            //TA.isTurnStarted = true;
            
            //ここからTurnAdminへ(数字を選び終わった状態。これが最終ターンか確認し、TAで、終わっていなければ次のターンに。終わっていれば、数字を突合して進めるかを決める処理に進む。
        }
    }

    public void TurnOnPCACanMove()
    {
        for (int i = 0; i < 6; i++)
        {
            PCA[i].canMove = true;
        }
    }

    public void ArrangePlayerCardToHomePos()
    {
        for (int i = 0; i < 6; i++)
        {
            PCA[i].GoBuckHomePos();
            PCA[i].ChangeColor(Color.white);
        }
    }

    public void ConvertTurnNumToIsCom(int TurnNum)
    {
        if(TurnNum == 0)
        {
            isCom = false;
        }
        else
        {
            isCom = true;
        }
    }

    public void MoveComCard(int comNum,int choicedNum)
    {
        switch (comNum)
        {
            case 1:
                CPUCards[choicedNum - 1].transform.position += new Vector3(-100, 0, 0);
                break;
            case 2:
                CPUCards[choicedNum - 1].transform.position += new Vector3(0, 0, -80);
                break;
            case 3:
                CPUCards[choicedNum - 1].transform.position += new Vector3(100, 0, 0);
                break;
        }
    }

    public void GoBackComCard()
    {
        for (int i = 0; i<6; i++)
        {
            CPUCards[i].transform.position = CPUDefPos[i];
        }
    }
}
