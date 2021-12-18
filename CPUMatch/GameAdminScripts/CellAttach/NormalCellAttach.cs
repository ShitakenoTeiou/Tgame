using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCellAttach : AbstractCell
{
    public override void CellEvent()
    {
        Debug.Log("ノーマルマスに止まりました。");
    }
}
