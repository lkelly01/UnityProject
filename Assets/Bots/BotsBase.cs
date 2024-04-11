using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="bots",menuName="bots/create new bot")]
public class BotsBase : ScriptableObject
{
    [SerializeField] string nameBot;

    [TextArea]
    [SerializeField] string description;
    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;
    [SerializeField] BotType botType;
    [SerializeField] int maxHP;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int speed;
    [SerializeField] List <LearnableMove>;

   public string Name {
    get {return nameBot;}
   }

    public string Description {
        get {return description;}
    }

    public int MaxHP {
        get { return maxHP;}
    }

    public int Attack {
        get {return attack;}
    }

    public int Defense{
        get {return defense;}
    }

    public int Speed{
        get {return speed;}
    }
    
    public class LearnableMove
    {
        [SerializeField] MoveBase moveBase
        [SerializeField] int level;
    }
 
    public enum BotType
    {
        Normal,
        Fire,
        Water,
        Grass
    }
}