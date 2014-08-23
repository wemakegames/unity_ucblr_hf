using UnityEngine;
using System.Collections;

public class PlayerHeartsGrab : MonoBehaviour {

	public int heartCount = 0;
	private PlayerControl playerControl;
	private SoundManager soundManager;

	// Use this for initialization
	void Start () {
		playerControl = GetComponent<PlayerControl> ();
		soundManager = GetComponent<SoundManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (heartCount == 8) {
			if (playerControl.playerLevel < 8) {
					playerControl.playerLevel += 1;
					soundManager.PlaySound("levelUp");
					ParticleSystem myPart = GameManager.gameManager.GetComponent<GameManager>().GetSystem(gameObject, "particles_levelup");
					myPart.Play();
					heartCount = 0;
			}
		}
	}


	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.transform.tag == "heart") {

			heartCount += 1;
			soundManager.PlaySound("gotHeart");

			ParticleSystem myPart = GameManager.gameManager.GetComponent<GameManager>().GetSystem(gameObject, "particles_stars");
			myPart.Play();
			Destroy(collision.gameObject);

		}
	}

}
