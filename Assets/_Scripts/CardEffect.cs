using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public enum EffectsEnum
{
    Nothing, DamageWall, SlowWall, DoubleNext, revealCards
}

[CreateAssetMenu(fileName = "new effect", menuName = "Scriptable Objects/Card Effect")]
public class CardEffect : ScriptableObject
{
    public Material icon;

    public Effect effect;

    public int amount;

    public bool isDoubled;


    public  void DoEffect(GameManager manager)
    {
        if(isDoubled)
            effect.DoEffect(manager, amount * 2);
        else
            effect.DoEffect(manager, amount);
    }
}

[System.Serializable]
public abstract class Effect : ScriptableObject
{
    public abstract void DoEffect(GameManager manager, int amount);
}

[System.Serializable, CreateAssetMenu(fileName = "nothing", menuName = "Scriptable Objects/nothingEffect")]
public class NothingEffect : Effect
    {
    public override void DoEffect(GameManager manager, int amount)
    {
        //does nothing
    }
}

[System.Serializable, CreateAssetMenu(fileName = "DamageWall", menuName = "Scriptable Objects/damageWallEffect")]
public class DamageEffect : Effect
{
    public override void DoEffect(GameManager manager, int amount)
    {
        manager.wall.TakeDamage(amount);
    }
}

[System.Serializable, CreateAssetMenu(fileName = "slow wall", menuName = "Scriptable Objects/slowWallEffect")]
public class SlowEffect : Effect
{
    public override void DoEffect(GameManager manager, int amount)
    {
        manager.wall.PauseWall(amount);
    }
}

[System.Serializable, CreateAssetMenu(fileName = "double", menuName = "Scriptable Objects/DoubleEffect")]
public class DoubleEffect : Effect
{
    public override void DoEffect(GameManager manager, int amount)
    {
        
    }
}
