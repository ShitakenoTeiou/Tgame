using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCAttachment : MonoBehaviour
{
    GameObject Card;
    //自分の持っているカードの内の一枚を格納する
    Vector3 Defaltepos;
    //自分のカードの元の位置を格納する
    Vector3 DefPosSphere;
    //駒のデフォルト位置を格納する。
    Vector3[] CardsDefPos = new Vector3[6];
    //カードのデフォルト位置を格納する。
    GameObject[] Cardobj = new GameObject[6];
    //カードのゲームオブジェクトを格納する。

    string ThisObjName;
    //カードのオブジェクト名を入れる。

    public int cnt = 0;
    //進んだマスの数を反映する。
    int ThisNum = 0;
    //進む数を格納する。

    bool MouseClickChecker = false;
    //マウスがクリックされて、選択状態にあることを、true,非選択状態にあることを、falseと定義する。

    public int tebancnt = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            Cardobj[i] = GameObject.Find("Card" + (i + 1));
            CardsDefPos[i] = Cardobj[i].transform.position;
        }
        //自分の手札である１～６のカードを、配列に格納する。

        ThisObjName = this.gameObject.name;
        ThisNum = int.Parse(ThisObjName.Substring(4, 1));
        //アタッチするのは、当たり判定の色がないブロックで、その名前は、Card数CDにしてあるから、そこから数字をとってくる。
        Card = Cardobj[ThisNum - 1];
        //当たり判定ブロックに対応したカードを変数に格納

        DefPosSphere = GameObject.Find("Sphere").transform.position;
        //駒の位置を格納。
        Defaltepos = Card.transform.position;
        //該当何も動かしていない位置を格納
    }

    private void OnMouseOver()
    {
        bool OthersColorDetecter = true;
        for (int i = 0; i < 6; i++)
        {
            if (Cardobj[i].GetComponent<Renderer>().material.color == Color.red)
            {
                OthersColorDetecter = false;
            }
        }
        if (OthersColorDetecter)
        { 
            if (Card.transform.position == Defaltepos)
            {
                MouseClickChecker = false;
                //デフォルトのポジションにいれば、マウスのクリック判定をfalseにリセットする。（これがないと、選択状態が他のCardCDにアタッチされたオブジェクトによって戻されたときにMouseClickの
            }

            if (MouseClickChecker == false)
            {
                if (Card.GetComponent<Renderer>().material.color != Color.gray)
                //すでに選択済みのカードは灰色になっているので、選択済みのカードは上に上げないようにする。
                {
                    Card.transform.position = new Vector3(Defaltepos.x, Defaltepos.y, Defaltepos.z + 15f);
                    //デフォルトのポジションにいる場合は、オブジェクトに触れたときに、少し上にカードを移動させる。
                }
            }
        }
    }

    void OnMouseExit()
    {
        if (MouseClickChecker == false)
        {
            Card.transform.position = Defaltepos;
            //クリックが感知されていない限りは、オブジェクトからマウスを外したら、元の位置に戻るようにする。

        }
    }


    private void OnMouseDown()
    {
        if (tebancnt == 1)
        {

            if (Card.GetComponent<Renderer>().material.color != Color.gray)
            {
                StartCoroutine(CardupdownC());
                if (Card.GetComponent<Renderer>().material.color == Color.gray)
                {
                    tebancnt += 1;
                }
            }
        }
        else
        {

        }
    }




    //ここから関数
    

    private IEnumerator CardupdownC()
    {
        if (MouseClickChecker == true)
        {
            //クリックを一度すると、フラグがtrueになる。そのスクリプトはこのelseの中に書いてある。まずは、false状態から入るので、trueの処理はそのあとになる。
            if (Card.transform.position != Defaltepos)
            {
                //クリックが一度されていて、デフォルトの位置にいないとき。→つまり、マウスが合わせられてる選択候補状態（少し上に位置がずれている）になった後に、クリックしてクリックフラグを立てたとき。

                if (Card.GetComponent<Renderer>().material.color != Color.red)
                {
                    //この部分をいじって、進むか進まないかを決める。一致したら、この部分に通さないようにする。
                    Progress(ThisNum, DefPosSphere);
                    Card.GetComponent<Renderer>().material.color = Color.red;
                }
                yield return new WaitForSeconds(1);
                Card.transform.position = Defaltepos;
                Card.GetComponent<Renderer>().material.color = Color.gray;
            }
            else
            {
                //クリックが一度されたが、他のカードをクリックしたことで、デフォルトの位置に戻っている状態の時→つまり、選択候補状態から選択状態にしてはいけず、色を白に戻さないといけない。
                if (Card.GetComponent<Renderer>().material.color != Color.yellow)
                {
                    MouseClickChecker = false;
                }
                else
                {
                    MouseClickChecker = false;
                    Card.GetComponent<Renderer>().material.color = Color.white;
                }
            }
        }
        else
        {
            //非選択状態のとき、オブジェクトにマウスを乗せた状態では、まずここを通る。
            MouseClickChecker = true;
            //Card.GetComponent<Renderer>().material.color = Color.yellow;

            for (int i = 0; i < 6; i++)
            {
                if ((i + 1) == ThisNum)
                //選択状態にしたとき、その数字は、少し上に配置して、他の数字は元の場所へ戻したいので、ThisNum以外のカードを元の場所へ戻す処理。灰色になっている選択済みカードは、白色に戻さず、黄色になっているカードのみ白に戻す。
                {
                    if(Cardobj[i].GetComponent<Renderer>().material.color != Color.gray)
                    { 
                        Cardobj[i].GetComponent<Renderer>().material.color = Color.yellow;
                    }
                }
                else
                {
                    if (Cardobj[i].GetComponent<Renderer>().material.color != Color.gray)
                    {
                        Cardobj[i].GetComponent<Renderer>().material.color = Color.white;
                        Cardobj[i].transform.position = CardsDefPos[i];
                    }
                }
            }
        }
    }

    public void Progress(int ThisNum, Vector3 DefPosSphere)
    {
        //進む数をcntで計上して、１つ進むごとの処理をcntの数だけ行う。
        for (int i = 1; i < ThisNum + 1; i++)
        {
            StartCoroutine(progresser());
            cnt += 1;
        }
    }

    private IEnumerator progresser()
    {
        Vector3 tmp = GameObject.Find("Sphere").transform.position;
        //現在位置を取得

        if (tmp.x - DefPosSphere.x == 0)
        {
            cnt = (int)(tmp.z - DefPosSphere.z) / 20;
            //左辺を進んでいるときの現在地カウント
        }
        else if (tmp.z - DefPosSphere.z == 80)
        {
            cnt = (int)((tmp.x - DefPosSphere.x) / 20) + 4;
            //上底を進んでいるときの現在地カウント
        }
        else if (tmp.x - DefPosSphere.x == 240)
        {
            cnt = (int)(4 - ((tmp.z - DefPosSphere.z) / 20) + 16);
            //右辺を進んでいるときの現在地カウント
        }


        if (cnt < 4)
        {
            GameObject.Find("Sphere").transform.position = new Vector3(tmp.x, tmp.y, tmp.z + 20f);
            //左辺にいるときは、上へ進む。

        }
        else if (cnt < 16)
        {
            GameObject.Find("Sphere").transform.position = new Vector3(tmp.x + 20f, tmp.y, tmp.z);
            //上底にいるときは、右へ進む。
        }

        else
        {
            GameObject.Find("Sphere").transform.position = new Vector3(tmp.x, tmp.y, tmp.z - 20f);
            //右辺にいるときは、下へ進む。
        }
        yield return new WaitForSeconds(1);
    }

}

