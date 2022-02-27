using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MovingWall wall;
    public PlayerMovement player;
    public List<CardCollumn> cardCollumns;
    public int numCardsInTurn = 3;
    public int delayBetweenCards = 3;

    [SerializeField]
    private List<CardsBehaviour> cardsToPlay;
    bool playingCards;
    int setCards;

    int revealedColumns;


    // Start is called before the first frame update
    void Start()
    {
        HideDisplayCards();
        RevealCollumn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool AddToCardsToPlay(CardEffect effect)
    {
        if(playingCards == false)
        {
            cardsToPlay[setCards].mEffect = effect;
            setCards++;

            if(setCards >= numCardsInTurn)
               StartCoroutine("PlayCards");

            return true;
        }
        else
            return false;
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

        HideDisplayCards();

    }

    void HideDisplayCards()
    {
        foreach (CardsBehaviour cb in cardsToPlay)
        {
            cb.transform.parent.gameObject.SetActive(false);
        }
    }

    public void DoubleNextCard()
    {
        foreach (CardsBehaviour cb in cardsToPlay)
        {
            cb.DoubleCard();
        }
    }

    public void RevealCollumn()
    {
        if(revealedColumns < cardCollumns.Count)
        {
            cardCollumns[revealedColumns].RevealColumn();
            revealedColumns++;
        }
    }

}
