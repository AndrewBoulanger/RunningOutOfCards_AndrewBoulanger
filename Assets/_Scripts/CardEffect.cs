using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public enum EffectsEnum
{
    Nothing, DamageWall, SlowWall, DoubleNext, revealCards
}


public class CardEffect
{

    public Effect effect;

    public int multiplier = 1;

    public Material GetIcon {get => effect.icon;}

    public  void DoEffect(GameManager manager)
    {
        effect.DoEffect(manager, effect.InitialAmount * multiplier);
    }
}

[System.Serializable]
public abstract class Effect : ScriptableObject
{
    public Material icon;
    public int InitialAmount;
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
        for(int i = 0; i < amount ; i++)
            manager.DoubleNextCard();
    }
}

[System.Serializable, CreateAssetMenu(fileName = "reveal", menuName = "Scriptable Objects/RevealEffect")]
public class RevealEffect : Effect
{
    public override void DoEffect(GameManager manager, int amount)
    {
        for (int i = 0; i < amount; i++)
            manager.RevealCollumn();
    }
}
