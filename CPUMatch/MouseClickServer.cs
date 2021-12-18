using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickServer : MonoBehaviour
{
    GameObject trgCard;
    Vector3 trgVector;
    string trgName;
    int CardNum;
    public bool[] IsClicked = new bool[6];
    public bool []IsDoubleClicked = new bool[6];
    public bool []CanMove = new bool[6];
    GameAdmin GA;
    CardNameSpace.PlayerCardClass[] PC = new CardNameSpace.PlayerCardClass[6];
    // Start is called before the first frame update
    void Start()
    {
        //trgCard = this.gameObject;
        //trgVector = trgCard.transform.position;
        //trgName = trgCard.name;
        //CardNum = int.Parse(trgName.Substring(trgName.Length - 1, trgName.Length));
        int tmpNum = 1;
        for (int i = 0; i < 6; i++)
        {
            IsClicked[i] = false;
            IsDoubleClicked[i] = false;
            PC[i] = GameObject.Find("PlayerCard" + tmpNum).GetComponent<CardNameSpace.PlayerCardClass>();
            tmpNum++;
        }
        //ゲームオブジェクトにアタッチされると、クラスがインスタンス化するので、当該インスタンスを格納する。
        GA = GameObject.Find("GameAdmin").GetComponent<GameAdmin>();
    }

    void Update()
    {

    }


}
