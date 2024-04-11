using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    public MoveBase Base {get; set;}
    public int Uses(MoveBase pBase, int uses)
    {
        Base=pBase;
    }
}
