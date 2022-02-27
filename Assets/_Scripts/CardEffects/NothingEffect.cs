using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "nothing", menuName = "Scriptable Objects/nothingEffect")]
public class NothingEffect : Effect
{
    public override void DoEffect(GameManager manager, int amount)
    {
        //does nothing
    }
}
