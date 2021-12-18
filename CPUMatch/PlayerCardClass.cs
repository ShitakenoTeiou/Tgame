using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CardNameSpace
{
    public class PlayerCardClass
    {
        public int targetCardNum;
        public int touchedCardNum;
        public int choicedCardNum;
        public bool isOvered = false;
        public bool isClicked = false;
        public bool isChoiced = false;
        public GameObject targetCardObj;
        public GameObject touchedCard;
        public GameObject choicedCard;
        public Vector3 targetCardPos;
        public Vector3 OriginalPos;
        public Vector3 touchedCardDefPos;
        public Vector3 transformedPos;

        public PlayerCardClass(int CardNum)
        {
            targetCardNum = CardNum;
            targetCardObj = GameObject.Find("PlayerCard" + CardNum);
            targetCardPos = targetCardObj.transform.position;
            OriginalPos = targetCardPos;
        }

        public void Goforward()
        {
            targetCardObj.transform.position += new Vector3(0, 0, 20);
        }

        public void GetBackHomePos()
        {
            targetCardObj.transform.position = OriginalPos;
        }

        
    }
}