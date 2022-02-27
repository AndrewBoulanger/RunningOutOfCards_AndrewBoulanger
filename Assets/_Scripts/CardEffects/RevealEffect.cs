using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "reveal", menuName = "Scriptable Objects/RevealEffect")]
public class RevealEffect : Effect
{
    public override void DoEffect(GameManager manager, int amount)
    {
        for (int i = 0; i < amount; i++)
            manager.RevealCollumn();
    }
}