using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameObject gameManager;
	private Component[] ps_array;
	public GameObject[] players;
	private bool checkCheat = true;


	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag ("NetPlayers");
		gameManager = gameObject;
	}



	public IEnumerator Wait(float duration) {
		for (float timer = 0; timer < duration; timer += Time.deltaTime){
			yield return 0;
		}
	}

	
	// Update is called once per frame
	void Update () {
		if (checkCheat == true) {
				StartCoroutine (Cheat ());
		}
	}

	public ParticleSystem GetSystem (GameObject obj,string systemName){
		ps_array = obj.GetComponentsInChildren<ParticleSystem> ();
		foreach (ParticleSystem childParticleSystem in ps_array) {
			if (childParticleSystem.name == systemName) {
				return childParticleSystem;
			}
		}
		return null;
	}

	IEnumerator Cheat() {


		checkCheat = false;
		// TODO: Refactor to make it work with many players (right now it's limites to a 2player array :p )
//
//		if ((players [0].transform.position.x - players [1].transform.position.x) > 50) {
//			players[1].GetComponent<PlayerControl>().speedH += players[1].GetComponent<PlayerControl>().maxSpeedH;
//		} else if ((players [1].transform.position.x - players [0].transform.position.x) > 50 ) {
//			players[0].GetComponent<PlayerControl>().speedH += players[0].GetComponent<PlayerControl>().maxSpeedH;
//		}
//
		yield return StartCoroutine(Wait (5.0f));
//
		checkCheat = true;
	}

}
