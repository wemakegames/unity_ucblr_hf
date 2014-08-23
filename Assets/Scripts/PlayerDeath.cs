using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {

	private GameObject mark;
	private GameObject gameManager;
	private SoundManager soundManager;


	// Use this for initialization
	void Awake(){

	}

	void Start () {
		soundManager = GetComponent<SoundManager>();
		gameManager = GameObject.Find("GameManager");
		mark = GameObject.Find ("deathMark");
	}
	
	// Update is called once per frame
	void Update () {
		if (mark && transform.position.x > mark.transform.position.x) {
			kill_player();
		}
	}

	void kill_player () {


		foreach ( GameObject player in gameManager.GetComponent<GameManager>().players) {
			player.renderer.enabled = false;
			soundManager.PlaySound("death");
			ParticleSystem myPart = gameManager.GetComponent<GameManager>().GetSystem(player, "particles_stars");
			myPart.Play();
			
			myPart = gameManager.GetComponent<GameManager>().GetSystem(player, "particles_blood");
			myPart.Play();
			
			myPart = gameManager.GetComponent<GameManager>().GetSystem(player, "particles_rainbow");
			myPart.Stop();

			player.collider2D.enabled = false;
			player.GetComponent<PlayerControl>().on = false;
		}
		//DestroyObject (gameObject);
		DestroyObject(mark);

		gameManager.GetComponent<EndSequence>().StartEndSequence(gameObject.name);   //launches startup coroutine
	}
}


