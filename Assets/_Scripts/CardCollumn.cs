using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCollumn : MonoBehaviour
{
    public CardsBehaviour[] cards;

    public void RevealColumn()
    {
        foreach (CardsBehaviour cb in cards)
        {
            cb.Reveal();
        }
    }
}
