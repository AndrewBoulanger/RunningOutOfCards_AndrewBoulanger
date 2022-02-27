using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MovingWall wall;
    public PlayerMovement player;
    public List<CardCollumn> cardCollumns;
    public int numCardsInTurn = 3;
    public float delayBetweenCards = 0.5f;

    [SerializeField]
    private List<CardsBehaviour> cardsToPlay;
    bool playingCards;
    int setCards;

    int revealedColumns;

    [SerializeField]
    ResultsPanel resultsPanel;

    // Start is called before the first frame update
    void Start()
    {
        HideDisplayCards();
        RevealCollumn();
        wall.GameEndAction += OnGameEnd;
    }


    public bool AddToCardsToPlay(CardEffect effect)
    {
        if(playingCards == false)
        {
            cardsToPlay[setCards].mEffect = effect;
            cardsToPlay[setCards].gameObject.SetActive(true);
            cardsToPlay[setCards].Reveal();
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
        setCards = 0;
        playingCards = false;

        yield return null;

    }

    void HideDisplayCards()
    {
        foreach (CardsBehaviour cb in cardsToPlay)
        {
            cb.gameObject.SetActive(false);
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


    private void OnGameEnd(bool won)
    {
        resultsPanel.gameObject.SetActive(true);
        resultsPanel.ShowResults(won);

        Time.timeScale = 0;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }

}
