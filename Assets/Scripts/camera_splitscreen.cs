using UnityEngine;
using System.Collections;

public class camera_splitscreen : MonoBehaviour {

	public GameObject myTarget;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	
	void FixedUpdate () {
		if (myTarget) {

			Vector3 temp_coord = transform.localPosition;
			//TODO: make this dependant on screen width (like 95% of screen width or so).
			temp_coord.x = myTarget.transform.localPosition.x + ((Screen.width/100));  //hardcoded value
			transform.localPosition = temp_coord;

		} else {
			myTarget = null;
		}
		
	}
}
