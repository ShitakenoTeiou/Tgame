using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameAdmin : MonoBehaviour
{
    public bool[] isChoiced = new bool[4];
    public bool canGameAdminStart = false;
    public int choicedNum;
    public int[] pturnNum = new int[4];
    public int moveNum;
    public int turnNum;
    public string NowRole;
    GameObject frontTextObj;
    GameObject oyaNameobj;
    Text frontText;
    Text oyaNameText;
    TurnAdmin TA;
    PCardAttach[] PCA = new PCardAttach[6];

    // Start is called before the first frame update
    void Start()
    {
        choicedNum = 0;
        TA = GameObject.Find("TurnAdmin").GetComponent<TurnAdmin>();
        frontText = GameObject.Find("FrontText").GetComponent<Text>();
        frontTextObj = GameObject.Find("FrontText");
        oyaNameobj = GameObject.Find("OyaName");
        oyaNameText = oyaNameobj.GetComponent<Text>();

        frontTextObj.SetActive(false);
        //テキストオブジェクトをを不可視状態にする。
        SelectTurnNum();

        NowRole = SetTurnRole(turnNum);
        Debug.Log(NowRole + "からスタートです。");
        frontText.text = NowRole.ToString() + "からスタートです。";
        frontTextObj.SetActive(true);
        oyaNameText.text = NowRole.ToString();
        canGameAdminStart = true;
        for (int i = 0; i < 6; i++)
        {
            PCA[i] = GameObject.Find("PlayerCard" + (i + 1)).GetComponent<PCardAttach>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        //１番目にここを通る。
        if (canGameAdminStart)
        {
            canGameAdminStart = false;
            StartCoroutine(thread1());

            //次に、TurnAdminに飛ぶ。
        }
    }

    public string SetTurnRole(int turnNum)
    {
        if(turnNum == 0)
        {
            return "プレイヤー";
        }
        else if(turnNum < 4)
        {
            return "Com" + turnNum;
        }
        else
        {
            return "Error";
        }
        
    }
    public void SelectTurnNum()
    {
        turnNum = Random.Range(1, 4);
    }

    public void MoveOnTheboard()
    {

    }

    public void ChangeFrontText(string fText)
    {

        frontText.text = fText;
        frontTextObj.SetActive(true);
    }

    public void FadeOutfrontText()
    {
        frontTextObj.SetActive(true);
    }

    IEnumerator thread1()
    {
        ManipulatePCard();
        yield return new WaitForSeconds(1);
        frontTextObj.SetActive(false);
        frontTextObj.SetActive(true);
        NowRole = SetTurnRole(turnNum);
        Debug.Log(NowRole + "が親です");
        frontText.text = NowRole.ToString() + "が親です";
        oyaNameText.text = NowRole.ToString();
        Debug.Log("first text through");
        yield return new WaitForSeconds(1);
        frontTextObj.SetActive(false);
        TA.turnNum = turnNum;
        TA.firstTurnNum = turnNum;
        TA.isTurnStarted = true;
    }

    public void ManipulatePCard()
    {
        for (int i = 0; i < 6; i++)
        {
            PCA[i].canMove = false;
        }
    }
    
    
}
