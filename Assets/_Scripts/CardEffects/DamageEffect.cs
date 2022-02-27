using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "DamageWall", menuName = "Scriptable Objects/damageWallEffect")]
public class DamageEffect : Effect
{
    public override void DoEffect(GameManager manager, int amount)
    {
        manager.wall.TakeDamage(amount);
    }
}
