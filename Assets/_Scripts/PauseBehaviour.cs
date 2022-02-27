using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseBehaviour : MonoBehaviour
{
    [SerializeField]
    Button resumeButton;

    [SerializeField]
    GameObject pauseScreen;

    Inputs inputs;

    bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        inputs = new Inputs();
        inputs.Player.Pause.started += _ => PausePressed();
        inputs.Enable();
        resumeButton.onClick.AddListener(PausePressed);

        pauseScreen.SetActive(false);
    }


    
    private void PausePressed()
    {
        print("Pause button pressed");
        if(isPaused)
        { 
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
            resumeButton.Select();
            isPaused = true;
        }
    }

    private void OnDisable()
    {
        inputs.Player.Pause.started -= _ => PausePressed();
        inputs.Disable();
        resumeButton.onClick.RemoveAllListeners();
    }
}
