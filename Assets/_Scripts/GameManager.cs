using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MovingWall wall;
    public PlayerMovement player;
    public CardsBehaviour[][] cards;
    public int numCardsInTurn = 3;
    public int delayBetweenCards = 3;

    private List<CardsBehaviour> cardsToPlay;
    bool playingCards;
    int setCards;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddCardsToPlay(CardEffect effect)
    {
        if(playingCards == false)
        {
            cardsToPlay[setCards].mEffect = effect;
            setCards++;

            if(setCards >= numCardsInTurn)
               StartCoroutine("PlayCards");
        }
    }

    IEnumerator PlayCards()
    {
        playingCards = true;

        foreach(CardsBehaviour ce in cardsToPlay)
        {
            ce.DoEffect(this);
            yield return new WaitForSeconds(delayBetweenCards);
            ce.OnUsedUp();
        }

        

    }

}
