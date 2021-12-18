using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetchMapSet : MonoBehaviour
{
    
    GameAdmin GA;

    // Start is called before the first frame update
    void Start()
    {
        GA = GameObject.Find("GameAdmin").GetComponent<GameAdmin>();
    }

   
}
