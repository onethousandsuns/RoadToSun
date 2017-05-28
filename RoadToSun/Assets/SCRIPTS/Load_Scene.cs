using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

//About mini intro scene
public class Load_Scene : MonoBehaviour {

	private string next_scene="Main_Scene";
	private GameObject logo;
	private GameObject logo_;
	private GameObject Intro;
	private float aux_var=0;
	private bool sw1=false;
	private bool sw2=false;
	private bool sw3=false;
	private Animator anim;
	private bool intro_finished=false;
	private bool one_clip=false;

	// Use this for initialization
	void Start () {
		setLayer();
		logo = GameObject.Find("logo");
		logo_ = GameObject.Find("logo_");
		Intro = GameObject.Find("Intro");
		Invoke ("fade_out_Logo",1);
	}

	void setLayer(){
		if(LayerMask.NameToLayer("Default")!=-1){
			this.gameObject.layer = LayerMask.NameToLayer("UI");
		}else{
			Debug.Log("No ''UI'' layer was found, please create it on Inspector");
		}
	}

	// Update is called once per frame
	void Update () {
		Color aux = logo_.GetComponent<SpriteRenderer>().material.color;
		if((aux.a >=0)&&(sw1==true)){
			aux.a = aux.a - 0.005f;
			logo_.GetComponent<SpriteRenderer>().material.color = aux;
			if(sw3==false){Invoke ("fade_in_Logo",3);}
		}
		if((aux.a <=1)&&(sw2==true)){
			aux.a = aux.a + 0.01f;
			logo_.GetComponent<SpriteRenderer>().material.color = aux;
			sw3=true;
			Invoke ("fade_out_Logo",3);
		}
		if(intro_finished==true){fade_out_Intro ();}
	}

	void fade_out_Logo(){
		if(sw3==true){
			NextScene();
			Destroy(logo);
		}
		sw1=true;
		sw2=false;
	}

	void fade_in_Logo(){
		sw1=false;
		sw2=true;
	}

    void NextScene()
    {
        Pause(15);
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerable<WaitForSeconds> Pause(int time)
    {
        yield return new WaitForSeconds(time);
    }

	void fade_out_Intro(){
		Color auxi = Intro.GetComponent<SpriteRenderer>().material.color;
		if((auxi.a >=0)){
			auxi.a = auxi.a - 0.01f;
			Intro.GetComponent<SpriteRenderer>().material.color = auxi;
		}else{
			NextScene ();
		}
	}
}
