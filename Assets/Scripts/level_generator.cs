using UnityEngine;
using System.Collections;

public class level_generator : MonoBehaviour {
	//number of chunks in the entire game
	public static int chunks = 12;

	public GameObject tiles_0;
	public Sprite[] tiles;
	int[][] map_data;

	// Use this for initialization
	void Start () {
		levels the_levels;
		the_levels = GetComponent<levels> ();
		tiles = Resources.LoadAll<Sprite>("sprite/tiles");
		the_levels.Start ();
		map_data = the_levels.map_data_array;
		GenerateLevel (0);
	}
	
	// Update is called once per frame
	void Update () {
				
	}
	
	void GenerateLevel(int the_step){
		int x, y, z;

		for (z = 0; z < chunks; z++)   				//chunks generation (12, hardcoded at the top of the class)
		
		{			
			the_step = z;

			for (y = 0; y < 12; y++) {   			// rows generation (12)
				for (x = 0; x < 96; x++) {			// columns generation (96)


					switch (map_data [z] [y * 96 + x]) {
						case 1:			//dark blue block
							tiles_0.GetComponent<SpriteRenderer> ().sprite = tiles [0];
							break;
						case 2:			//white block							
							tiles_0.GetComponent<SpriteRenderer> ().sprite = tiles [1];
							break;
						case 3:			//red block
							tiles_0.GetComponent<SpriteRenderer> ().sprite = tiles [2];
							break;
						case 4:			//yellow block
							tiles_0.GetComponent<SpriteRenderer> ().sprite = tiles [3];
							break;
						case 5:			//aqua blue block
							tiles_0.GetComponent<SpriteRenderer> ().sprite = tiles [4];
							break;
						case 6:			//hearts
							tiles_0.GetComponent<SpriteRenderer> ().sprite = tiles [5];							
							tiles_0.GetComponent<BoxCollider2D> ().isTrigger = true;
							tiles_0.GetComponent<BoxCollider2D> ().tag = "heart";
							tiles_0.layer = LayerMask.NameToLayer("Default");
							break;
						case 7:			//green block
							tiles_0.GetComponent<SpriteRenderer> ().sprite = tiles [6];
							break;
						case 8:			//pink
							tiles_0.GetComponent<SpriteRenderer> ().sprite = tiles [7];
							break;
						case 9:			//spike up
							tiles_0.GetComponent<SpriteRenderer> ().sprite = tiles [8];
						break;
						case 10:		//spike down
							tiles_0.GetComponent<SpriteRenderer> ().sprite = tiles [9];
							break;
						case 11:		//spike left
							tiles_0.GetComponent<SpriteRenderer> ().sprite = tiles [10];
							break;
					}

					if (map_data [z] [y * 96 + x] != 0){    //create the block

						if (tiles_0.GetComponent<SpriteRenderer> ().sprite != tiles [5]){
							tiles_0.GetComponent<BoxCollider2D> ().isTrigger = false;
							tiles_0.GetComponent<BoxCollider2D> ().tag = "Untagged";
							tiles_0.layer = LayerMask.NameToLayer("Ground");
						}

						tiles_0.GetComponent<BoxCollider2D> ().enabled = true;
						GameObject temp = Instantiate (tiles_0, new Vector3 ((1f * x) + 96f * the_step, (1f * -y) + 11f, 0), Quaternion.identity) as GameObject;
						temp.transform.parent = transform;	//adds the level inside the GameManager object


					}
				}
			}
		}

		GameObject.Destroy (tiles_0); // cleans original tile object
	}
}




