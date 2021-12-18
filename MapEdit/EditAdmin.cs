using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditAdmin : MonoBehaviour
{
    GameObject NormalCellSample;
    GameObject MoveBackwardCellSample;
    GameObject MoveForewardCellSample;
    GameObject MoveBackStartCellSample;
    GameObject StartCellSample;
    GameObject GoalCellSample;
    public Color NormalColor;
    public Color BackColor;
    public Color ForewardColor;
    public Color BackStartColor;
    public Color StartColor;
    public Color GoalColor;
    public int nowColorNum = 0;
    enum NColor : int {
        NothingChoiced = 0,
        Normal = 1,
        Back = 2,
        Foreward = 3,
        GoStart = 4,
        Start = 5,
        Goal = 6
    }


    // Start is called before the first frame update
    void Start()
    {
        NormalCellSample = GameObject.Find("NormalCell");
        NormalColor = NormalCellSample.GetComponent<Renderer>().material.color;
        MoveBackwardCellSample = GameObject.Find("MoveBackwardCell");
        BackColor = MoveBackwardCellSample.GetComponent<Renderer>().material.color;
        MoveForewardCellSample = GameObject.Find("MoveForewardCell");
        ForewardColor = MoveForewardCellSample.GetComponent<Renderer>().material.color;
        MoveBackStartCellSample = GameObject.Find("MoveToStartCell");
        BackStartColor = MoveBackStartCellSample.GetComponent<Renderer>().material.color;
        StartCellSample = GameObject.Find("StartCell");
        StartColor = StartCellSample.GetComponent<Renderer>().material.color;
        GoalCellSample = GameObject.Find("GoalCell");
        GoalColor = GoalCellSample.GetComponent<Renderer>().material.color;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(nowColorNum);
    }
}
