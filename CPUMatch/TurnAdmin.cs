using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAdmin : MonoBehaviour
{
    bool CanDecideTurn;
    int OyaNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        CanDecideTurn = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (CanDecideTurn)
        {
            OyaNum = (int)Random.Range(0, 4);


        }
    }
}
