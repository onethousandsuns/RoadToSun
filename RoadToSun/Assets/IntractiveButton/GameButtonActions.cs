using System.Collections;
using System.Collections.Generic;
using Assets.SCRIPTS.Game;
using UnityEngine;
using UnityEngine.UI;

public class GameButtonActions : MonoBehaviour {

    public Shape shape;
	public GameButtonActions otherButton;

	// Use this for initialization
	void Start () {
	    Button optBtn = this.GetComponent<Button>();
		UnityEngine.Events.UnityAction action1 = () => { this.RotateButton(true); };
        optBtn.onClick.AddListener(action1);

        if (shape.Direction != ShapeDirection.Down)
        {
            this.GetComponent<Animation>().Play("button_rotation_up_to_down");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void PlayAnimation()
    {
        if (shape.Direction == ShapeDirection.Up)
        {
            this.GetComponent<Animation>().Play("button_rotation_down_to_up");
        }
        else if (shape.Direction == ShapeDirection.Down)
        {
            this.GetComponent<Animation>().Play("button_rotation_up_to_down");
        }
        //yield WaitForSeconds(animation["die"].length);
    }

    void RotateButton(bool isClick)
    {
        PlayAnimation();
        shape.ChangeDirection();
		if(isClick)
		{
			otherButton.RotateButton(false);

            if (GameLevel.gameLevel.IsSequencesEqual())
            {
                GameHandler.gameHandler.LoadNextLvl();
            }
        }
    }
}
