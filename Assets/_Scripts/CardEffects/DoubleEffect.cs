using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "double", menuName = "Scriptable Objects/DoubleEffect")]
public class DoubleEffect : Effect
{
    public override void DoEffect(GameManager manager, int amount)
    {
        for (int i = 0; i < amount; i++)
            manager.DoubleNextCard();
    }
}
