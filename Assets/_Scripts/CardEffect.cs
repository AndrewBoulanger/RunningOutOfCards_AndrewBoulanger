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

    public AudioClip GetSound {get => effect.sound;}

    public  void DoEffect(GameManager manager)
    {
        effect.DoEffect(manager, effect.InitialAmount * multiplier);
    }
}
