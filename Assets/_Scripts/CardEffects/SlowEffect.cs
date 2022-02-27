using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "slow wall", menuName = "Scriptable Objects/slowWallEffect")]
public class SlowEffect : Effect
{
    public override void DoEffect(GameManager manager, int amount)
    {
        manager.wall.PauseWall(amount);
    }
}
