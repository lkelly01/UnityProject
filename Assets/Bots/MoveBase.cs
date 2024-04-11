using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Move", menuName="bots/create New Move")]
public class MoveBase : ScriptableObject
{
    [SerializeField] string moveName;
    [TextArea]
    [SerializeField] string description;
    [SerializeField] BotType type;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int uses;
    
    public string Name {
    get {return moveName;}
   }

    public string Description {
        get {return description;}
    }
    public int Power{
        get {return power;}
    }

    public int Accuracy{
        get {return accuracy;}
    }

    public int Uses{
        get {return uses;}
    }

    public BotType moveType{
        get{return type;}
    }


    public enum BotType
    {
        Normal,
        Fire,
        Water,
        Grass
    }
}