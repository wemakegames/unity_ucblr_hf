using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class level_bg : MonoBehaviour {
	public GameObject hills;

	public GameObject stars;

	public List<GameObject> stars_array = new List<GameObject>();

	// Use this for initialization
	void Start () {
		GenerateParallax ();
		GenerateStars ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GenerateParallax () {
		for (var i = -12; i< (12 * (level_generator.chunks+1)); i++) { //-12 and (level_generator.chunks+1) are there to create some buffer at the beginning and the end
			var j = 8 * i;
			GameObject temp = Instantiate(hills, new Vector3(j,3,2), Quaternion.identity) as GameObject;
			temp.transform.parent = transform;	//adds the level inside the GameManager object
		}
	}

	void GenerateStars () {

		for (var i = -1; i< (12 * (level_generator.chunks / 3)); i++) {
			var j = 32 * i;
			GameObject temp = Instantiate(stars, new Vector3(j,6,2), Quaternion.identity) as GameObject;
			temp.transform.parent = transform;
			temp.transform.parent = transform;	//adds the level inside the GameManager object
		}
	}
}
