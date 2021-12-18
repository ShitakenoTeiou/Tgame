using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackwardCellAttach : AbstractCell
{
    public override void CellEvent()
    {
        Debug.Log("後退マスに止まりました。");
    }
}
