using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Effect : ScriptableObject
{
    public Material icon;
    public int InitialAmount;
    public AudioClip sound;
    public abstract void DoEffect(GameManager manager, int amount);
}


