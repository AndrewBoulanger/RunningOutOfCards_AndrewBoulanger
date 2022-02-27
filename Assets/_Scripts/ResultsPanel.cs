using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultsPanel : MonoBehaviour
{
    public TMPro.TextMeshProUGUI resultsText;
    public Button replayButton, quitButton;

    public bool isStartscreen;

  
    // Start is called before the first frame update
    void Start()
    {
        replayButton.onClick.AddListener(OnReplay);
        quitButton.onClick.AddListener(OnQuit);

        if (!isStartscreen)
        {
            gameObject.SetActive(false);
        }
        else
            replayButton.Select();
    }

    public void ShowResults(bool won)
    {
        resultsText.text = (won) ? "You Won" : "sorry, you lose";
        replayButton.Select();
    }

    void OnReplay()
    {

        SceneManager.LoadScene("Main");
    }

    void OnQuit()
    {
        if(isStartscreen)
            Application.Quit();
        else
            SceneManager.LoadScene("Start");
    }

}
