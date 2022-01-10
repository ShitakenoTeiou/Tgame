using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCardAttach : MonoBehaviour
{
    Vector3 homePos;
    string thisObjName;
    public int thisObjNum;
    public bool clicked = false;
    public bool doubleClicked = false;
    public bool canMove = false;
    PCardAttach[] PCA = new PCardAttach[6];
    RoleAttach RA;

    // Start is called before the first frame update
    void Start()
    {
        homePos = this.gameObject.transform.position;
        thisObjName = this.gameObject.name;
        thisObjNum = int.Parse(thisObjName.Substring(thisObjName.Length - 1, 1));

        for (int i = 0; i<6; i++)
        {
            PCA[i] = GameObject.Find("PlayerCard" + (i+1)).GetComponent<PCardAttach>();
        }

        RA = GameObject.Find("Role0").GetComponent<RoleAttach>();
        canMove = false;
    }
    private void OnMouseEnter()
    {
        if(canMove == true)
        {
            //オブジェクトにマウスを合わせると黄色にする。
            ChangeColor(Color.yellow);
        }
        if(clicked == true)
        {
            //一回クリックしたら、オブジェクトにマウスを合わせても、黄色にならなくする。
            ChangeColor(Color.white);
        }
    }
    private void OnMouseExit()
    {
        //マウスがオブジェクトの上から外れたら、黄色から白に戻す。
        if(clicked == false)
        {
            ChangeColor(Color.white);
        }
    }
    private void OnMouseDown()
    {
        if (canMove)
            //canMoveは、TurnAdminから受け取る。ホームポジションに戻すのもターンAdminの中で。
            //自分のターンになった時
        {       
            if (clicked)
            //一度クリックされた状態で、もう一度クリックされた際の際の反応 RoleAdminにその情報を送る。
            {
                doubleClicked = true;
                ChangeColor(Color.red);
                for (int i = 0; i < 6; i++)
                {
                    PCA[i].canMove = false;
                    if ((i + 1) != thisObjNum)
                    {
                        PCA[i].GoBackwardPos();
                    }
                }
                RA.choicedNum = thisObjNum;
                RA.hasFinishedChoicing = true;
                Debug.Log("プレイヤーは、" + thisObjNum + "を選択しました。");
            }
            else
            {
            //まだ一度もクリックされておらず、一度クリックされた際の反応
                clicked = true;
                ChangeColor(Color.white);
                GoForwardPos();
                for (int i = 0; i < 6; i++)
                {
                    if ((i + 1) != thisObjNum)
                    {
                        PCA[i].GoBuckHomePos();
                        PCA[i].clicked = false;
                        PCA[i].ChangeColor(Color.white);
                        
                    }
                }
            }
        }
    }

    public void GoBuckHomePos()
    {
        this.gameObject.transform.position = homePos;
        clicked = false;
    }

    public void ChangeColor(Color choicedColor)
    {
        this.gameObject.GetComponent<Renderer>().material.color = choicedColor;
    }

    public void GoForwardPos()
    {
        this.gameObject.transform.position = homePos + new Vector3(0, 0, 20);
    }

    public void GoBackwardPos()
    {
        this.gameObject.transform.position = homePos + new Vector3(0, 0, -50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
