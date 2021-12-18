using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCell : MonoBehaviour
{
    public int cellposNum;
    public Vector3 cellPos;
    public int eventmoveNum = 0;

    public abstract void CellEvent();
}
