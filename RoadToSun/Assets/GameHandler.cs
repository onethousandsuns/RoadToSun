using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour {

    public Button optionButton;
    public GameObject gameField;
    public GameObject GameButtonPrefab; 
	public GameObject GameTriangleExample;
    public static GameHandler gameHandler;
    public int currentLvl;

    private Vector2[] coords = new [] {
		new Vector2(-1.326451f, 0.001922755f),
		new Vector2(-0.4302004f, 0.001922755f), 
		new Vector2(0.4660505f, 0.001922755f), 
		new Vector2(1.362301f, 0.001922755f) };
    private bool gameFieldVisible = false;

    // Use this for initialization
    void Start () {
        gameHandler = this;

        //SpawnExample ();
        Button optBtn = optionButton.GetComponent<Button>();
        optBtn.onClick.AddListener(GoToMainMenu);

        ShowGameField();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void ShowGameField()
    {
        gameFieldVisible = true;
        //gameField.GetComponent<Animation>().Play("game_field_appearance");
    }

    IEnumerable<WaitForSeconds> HideGameField()
    {
        gameFieldVisible = false;
        gameField.GetComponent<Animation>().Play("game_field_disappearance");
        yield return new WaitForSeconds(2);
    }

    void GoToMainMenu()
    {
        IEnumerable<WaitForSeconds> runEnumerable = HideGameField();
        Debug.Log("You have clicked IN_GAME_OPTION button!");
        SceneManager.LoadScene("MainMenu");
    }

	void SpawnExample()
	{
		for (int x = 0; x < 4; x++)
		{
			if (x % 2 == 0) {
				print (coords [x]);
				Instantiate (GameButtonPrefab, coords[x], Quaternion.identity);		
			} else {
				Instantiate (GameButtonPrefab, coords[x], Quaternion.Euler(0, 0, 180));	
			}

		}
	}

    void SpawnButtons()
    {
        for (int x = 0; x < 4; x++)
        {
			if (x % 2 == 0) {
				Instantiate (GameButtonPrefab, coords[x], Quaternion.identity);		
			} else {
				Instantiate (GameButtonPrefab, coords[x], Quaternion.Euler(0, 0, 180));	
			}

        }
    }

    public void LoadNextLvl()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Level6")
        {
            SceneManager.LoadScene("Level6.1");
        }

        else if (currentLvl > 0)
        {
            currentLvl += 1;
            SceneManager.LoadScene("Level" + currentLvl.ToString());
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
