using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRandomizer : MonoBehaviour
{
    public List<Effect> effects;

    public Effect defaultEffect;

    // Start is called before the first frame update
    void Awake()
    {
        CardsBehaviour[] cards = FindObjectsOfType<CardsBehaviour>();

        foreach (CardsBehaviour card in cards)
        {
            card.mEffect = new CardEffect();
            if(effects.Count == 0)
            {
                card.mEffect.effect = defaultEffect;
            }
            else
            { 
                int queueNum = Random.Range(0, effects.Count);
                card.mEffect.effect = effects[queueNum];
                effects.RemoveAt(queueNum);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
