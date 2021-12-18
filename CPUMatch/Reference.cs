//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class PlayerCardCD : MonoBehaviour
//{
//    GameObject Card;
//    //自分の持っているカードの内の一枚を格納する
//    GameObject GAdmin;
//    Vector3 DefaultPos;
//    //自分のカードの元の位置を格納する
//    Vector3 DefPosSphere;
//    //駒のデフォルト位置を格納する。
//    Vector3[] CardsDefPos = new Vector3[6];
//    //カードのデフォルト位置を格納する。
//    GameObject[] CardObj = new GameObject[6];
//    //カードのゲームオブジェクトを格納する。
//    GameAdmin GAScript;

//    string ThisObjName;
//    //カードのオブジェクト名を入れる。

//    public int Cnt = 0;
//    //進んだマスの数を反映する。
//    public int ThisNum = 0;
//    //進む数を格納する。

//    bool IsMouseClicked = false;
//    //マウスがクリックされて、選択状態にあることを、true,非選択状態にあることを、falseと定義する。

//    public bool CanPlayerSelect = false;

//    // Start is called before the first frame update
//    void Start()
//    {
//        for (int i = 0; i < 6; i++)
//        {
//            CardObj[i] = GameObject.Find("Card" + (i + 1));
//            CardsDefPos[i] = CardObj[i].transform.position;
//        }
//        //自分の手札である１～６のカードのゲームオブジェクトを、配列に格納する。

//        ThisObjName = this.gameObject.name;
//        ThisNum = int.Parse(ThisObjName.Substring(4, 1));
//        //アタッチするのは、当たり判定の色がないブロックで、その名前は、Card数CDにしてあるから、そこから数字をとってくる。
//        Card = CardObj[ThisNum - 1];
//        //当たり判定ブロックに対応したカードを変数に格納

//        DefPosSphere = GameObject.Find("Sphere").transform.position;
//        //駒の位置を格納。
//        DefaultPos = Card.transform.position;
//        //該当何も動かしていない位置を格納
//        GAdmin = GameObject.Find("GameAdmin");
//        GAScript = GAdmin.GetComponent<GameAdmin>();
//    }




//    private void OnMouseOver()
//    {
//        if (CanPlayerSelect)
//        {
//            bool IsOthersWhiteOrYellow = true;
//            for (int i = 0; i < 6; i++)
//            {
//                if (CardObj[i].GetComponent<Renderer>().material.color == Color.red)
//                {
//                    IsOthersWhiteOrYellow = false;
//                }
//            }
//            if (IsOthersWhiteOrYellow)
//            {
//                if (Card.transform.position == DefaultPos)
//                {
//                    IsMouseClicked = false;
//                    //デフォルトのポジションにいれば、マウスのクリック判定をfalseにリセットする。（これがないと、選択状態が他のCardCDにアタッチされたオブジェクトによって戻されたときにMouseClickの
//                }

//                if (IsMouseClicked == false)
//                {
//                    if (Card.GetComponent<Renderer>().material.color != Color.gray)
//                    //すでに選択済みのカードは灰色になっているので、選択済みのカードは上に上げないようにする。
//                    {
//                        Card.transform.position = new Vector3(DefaultPos.x, DefaultPos.y, DefaultPos.z + 15f);
//                        //デフォルトのポジションにいる場合は、オブジェクトに触れたときに、少し上にカードを移動させる。
//                    }
//                }
//            }
//        }
//    }

//    void OnMouseExit()
//    {
//        if (CanPlayerSelect)
//        {
//            if (IsMouseClicked == false)
//            {
//                Card.transform.position = DefaultPos;
//                //クリックが感知されていない限りは、オブジェクトからマウスを外したら、元の位置に戻るようにする。

//            }
//        }
//    }


//    private void OnMouseDown()
//    {
//        if (CanPlayerSelect)
//        {
//            if (Card.GetComponent<Renderer>().material.color != Color.gray)
//            {
//                StartCoroutine(CardupdownC());
//            }
//        }
//    }


//    //ここから関数


//    private IEnumerator CardupdownC()
//    {
//        if (IsMouseClicked == true)
//        {
//            //クリックを一度すると、フラグがtrueになる。そのスクリプトはこのelseの中に書いてある。まずは、false状態から入るので、trueの処理はそのあとになる。
//            if (Card.transform.position != DefaultPos)
//            {
//                //クリックが一度されていて、デフォルトの位置にいないとき。→つまり、マウスが合わせられてる選択候補状態（少し上に位置がずれている）になった後に、クリックしてクリックフラグを立てたとき。

//                if (Card.GetComponent<Renderer>().material.color != Color.red)
//                {
//                    //二回クリックした時、まずはじめに色を赤にする。もう赤になったらここを通さないようにする。
//                    Card.GetComponent<Renderer>().material.color = Color.red;
//                }

//                //ここで、まず数字をAdminに渡す。ThisNumの値を渡す。Adminは、値を渡されたら、選択フラグをTrueにする。




//                yield return new WaitForSeconds(1);
//                //一秒待つ
//                GAScript.PlayerSelectNum = ThisNum;
//                Card.transform.position = DefaultPos;
//                //元の場所に戻す。
//                Card.GetComponent<Renderer>().material.color = Color.gray;

//            }
//            else
//            {
//                IsMouseClicked = false;
//                //クリックが一度されたが、他のカードをクリックしたことで、デフォルトの位置に戻っている状態の時→つまり、選択候補状態から選択状態にしてはいけず、色を白に戻さないといけない。
//                if (Card.GetComponent<Renderer>().material.color == Color.yellow)
//                {
//                    Card.GetComponent<Renderer>().material.color = Color.white;
//                }

//            }
//        }
//        else
//        {
//            //非選択状態のとき、オブジェクトにマウスを乗せた状態では、まずここを通る。
//            IsMouseClicked = true;
//            //Card.GetComponent<Renderer>().material.color = Color.yellow;

//            for (int i = 0; i < 6; i++)
//            {
//                if ((i + 1) == ThisNum)
//                //選択状態にしたとき、その数字は、少し上に配置して、他の数字は元の場所へ戻したいので、ThisNum以外のカードを元の場所へ戻す処理。灰色になっている選択済みカードは、白色に戻さず、黄色になっているカードのみ白に戻す。
//                {
//                    if (CardObj[i].GetComponent<Renderer>().material.color != Color.gray)
//                    {
//                        CardObj[i].GetComponent<Renderer>().material.color = Color.yellow;
//                    }
//                }
//                else
//                {
//                    if (CardObj[i].GetComponent<Renderer>().material.color != Color.gray)
//                    {
//                        CardObj[i].GetComponent<Renderer>().material.color = Color.white;
//                        CardObj[i].transform.position = CardsDefPos[i];
//                    }
//                }
//            }
//        }
//    }





//}

