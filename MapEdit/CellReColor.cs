using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellReColor : MonoBehaviour
{
    Color defaultColor;
    Color choicedColor;
    EditAdmin EA;
    bool isClicked;
    enum NColor : int
    {
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
        isClicked = false;
        defaultColor = this.gameObject.GetComponent<Renderer>().material.color;
        choicedColor = Color.white;
        EA = GameObject.Find("EditAdmin").GetComponent<EditAdmin>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if(isClicked == false)
        {
            ChangeColorOnMouseEnter(choicedColor);
        }
        
    }

    private void OnMouseExit()
    {
        if (isClicked == false)
        {
            ChangeColor(defaultColor);
        }
    }

    private void OnMouseDown()
    {
        if (isClicked)
        {
            isClicked = false;
        }
        else
        {
            isClicked = true;
        }
        
    }

    public void ChangeColorOnMouseEnter(Color choicedColor)
    {
        switch (EA.nowColorNum)
        {
            case (int)NColor.NothingChoiced:
                choicedColor = Color.white;
                break;
            case (int)NColor.Normal:
                choicedColor = EA.NormalColor;
                break;
            case (int)NColor.Back:
                choicedColor = EA.BackColor;
                break;
            case (int)NColor.Foreward:
                choicedColor = EA.ForewardColor;
                break;
            case (int)NColor.GoStart:
                choicedColor = EA.BackStartColor;
                break;
            case (int)NColor.Start:
                choicedColor = EA.StartColor;
                break;
            case (int)NColor.Goal:
                choicedColor = EA.GoalColor;
                break;
        }
        this.gameObject.GetComponent<Renderer>().material.color = choicedColor;
    }

    public void ChangeColor(Color choicedColor)
    {
        this.gameObject.GetComponent<Renderer>().material.color = choicedColor;
    }
}
