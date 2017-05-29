using System.Collections;
using System.Collections.Generic;
using Assets.SCRIPTS.Game;
using UnityEngine;
using UnityEngine.UI;

public class GameButtonActions : MonoBehaviour {

    private Shape shape = new Shape(ShapeDirection.Down); 

	// Use this for initialization
	void Start () {
        print(this.ToString());
	    Button optBtn = this.GetComponent<Button>();
	    optBtn.onClick.AddListener(RotateButton);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void RotateButton()
    {
        if (shape.Direction == ShapeDirection.Up)
        {
            this.GetComponent<Animation>().Play("button_rotation_down_to_up");
        }
        else if (shape.Direction == ShapeDirection.Down)
        {
            this.GetComponent<Animation>().Play("button_rotation_up_to_down");
        }
        shape.ChangeDirection();
    }
}
