using System.Collections;
using Assets.SCRIPTS.Game;
using UnityEngine;
using UnityEngine.UI;

public class GameButtonActions : MonoBehaviour {

    public Shape shape;
	public GameButtonActions otherButton;
    public GameObject spaceShip;

    private GameObject exampleField;
    private GameObject gameField;

    private GameObject leftHUD;
    private GameObject rightHUD;

    // Use this for initialization
    void Start () {
        exampleField = GameObject.Find("EXAMPLE_OBJECT");
        gameField = GameObject.Find("GAME_OBJECT");
        leftHUD = GameObject.Find("LEFT_HUD_PANEL");
        rightHUD = GameObject.Find("RIGHT_HUD_PANEL");

        Button optBtn = this.GetComponent<Button>();
		UnityEngine.Events.UnityAction action1 = () => { this.RotateButton(true); };
        optBtn.onClick.AddListener(action1);

        if (shape.Direction != ShapeDirection.Up)
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
            this.GetComponent<Animation>().Play("button_rotation_up_to_down");
        }
        else if (shape.Direction == ShapeDirection.Down)
        {
            this.GetComponent<Animation>().Play("button_rotation_down_to_up");
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
                print("LEVEL COMPLETED");

                // PANELKI UEBIVAUT
                gameField.GetComponent<Animator>().Play("right_game_field_disappears");
                exampleField.GetComponent<Animator>().Play("game_field_disappears");

                // HUD UEBIVAET
                leftHUD.GetComponent<Animator>().Play("left_hud_panel_disappears");
                rightHUD.GetComponent<Animator>().Play("right_hud_panel_disappears");


                //spaceShip.GetComponent<Animator>().Play("ship_disapearance");

                StartCoroutine(Wait(10f));
            }
        }
    }

    IEnumerator Wait(float time)
    {
        print("WAIT START");
        yield return new WaitForSeconds(time);
        print("WAIT END");
        GameHandler.gameHandler.LoadNextLvl();

    }
}
