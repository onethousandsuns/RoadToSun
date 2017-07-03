using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NarativeHandler : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
        StartCoroutine(Wait(47f));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Wait(float time)
    {
        print("WAIT START");
        Scene scene = SceneManager.GetActiveScene();
        yield return new WaitForSeconds(time);
        print("WAIT END");
        if (scene.name == "Level1.1")
        {
            SceneManager.LoadScene("Level1");
        }
        if (scene.name == "Level6.1")
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
