using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleAttach : MonoBehaviour
{
    EditAdmin EA;
    int thisColorNum;
    // Start is called before the first frame update
    void Start()
    {
        EA = GameObject.Find("EditAdmin").GetComponent<EditAdmin>();

        Debug.Log(this.gameObject.name);
        switch (this.gameObject.name){
            case "Frame1":
                this.thisColorNum = 0;
                break;
            case "NormalCell":
                thisColorNum = 1;
                break;
            case "MoveBackwardCell":
                thisColorNum = 2;
                break;
            case "MoveForewardCell":
                thisColorNum = 3;
                break;
            case "MoveToStartCell":
                thisColorNum = 4;
                break;
            case "StartCell":
                thisColorNum = 5;
                break;
            case "GoalCell":
                thisColorNum = 6;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        EA.nowColorNum = thisColorNum;
    }
}
