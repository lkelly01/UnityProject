using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bots
{
    BotsBase _base;
    int level;

    public Bots(BotsBase bBase,int bLevel)
    {
        _base=bBase;
        level=bLevel;
    }

    public int MaxHP{
        get {return Mathf.FloorToInt((_base.MaxHP*level)/100f)+10; }
    }
    public int Attack{
        get {return Mathf.FloorToInt((_base.Attack*level)/100f)+2; }
    }

    public int Defense{
        get {return Mathf.FloorToInt((_base.Defense*level)/100f)+2; }
    }
    public int Speed{
        get {return Mathf.FloorToInt((_base.Speed*level)/100f)+2; }
    }
}
