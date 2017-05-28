using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuActions : MonoBehaviour {

    public Button startButton;
    public Button exitButton;

    // Use this for initialization
    void Start () {
        Button exitBtn = exitButton.GetComponent<Button>();
        Button startBtn = startButton.GetComponent<Button>();
        exitBtn.onClick.AddListener(ExitGame);
        startBtn.onClick.AddListener(StartGame);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame()
    {
        Debug.Log("You have clicked the START button!");
        SceneManager.LoadScene("Level1");
    }

    public void ExitGame()
    {
        Debug.Log("You have clicked the EXIT button!");
        Application.Quit();
    }
}
