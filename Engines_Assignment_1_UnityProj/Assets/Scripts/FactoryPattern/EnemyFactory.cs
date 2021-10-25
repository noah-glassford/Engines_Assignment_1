using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://en.wikipedia.org/wiki/Factory_method_pattern#C#
//base code for factory
//modified to work for enemies in this project


public interface IEnemy
{
    Color GetColor();
}

public class PinkEnemy : IEnemy
{
    public Color GetColor()
    {
        return new Color(1, 0.75f, 0.79f);
    }
}

public class RedEnemy : IEnemy
{
    public Color GetColor()
    {
        return Color.red;
    }
}

public enum EnemyType
{
    Pink,
    Red
}


public class EnemyFactory 
{
   public IEnemy GetEnemy(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Pink:
                return new PinkEnemy();
            case EnemyType.Red:
                return new RedEnemy();
            default:
                throw new System.Exception();
        }    
    }
}
