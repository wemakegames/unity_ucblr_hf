using UnityEngine;
using System.Collections;

public class menu_manager : MonoBehaviour {
	
	private bool button1;
	private bool button2;
	private bool button3;
	private bool button4;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CheckControls();
	}
	
	void CheckControls(){

		
		if (Input.anyKey) {
			Application.LoadLevel("game");
		}
	}
}
