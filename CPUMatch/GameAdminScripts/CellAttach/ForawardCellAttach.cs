using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForawardCellAttach : AbstractCell
{
    public override void CellEvent()
    {
        Debug.Log("前進マスに止まりました。");
    }
}
