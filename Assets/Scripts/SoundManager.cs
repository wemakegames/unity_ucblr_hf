using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public AudioClip gotHeart;
	public AudioClip levelUp;
	public AudioClip death;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlaySound(string name){
		AudioClip clip = null;

		switch (name) 		
		{
			case ("gotHeart"):
			clip = gotHeart;
			break;

			case ("levelUp"):
			clip = levelUp;
			break;

			case ("death"):
			clip = death;
			break;
		}
		AudioSource.PlayClipAtPoint (clip, transform.position);

	}
}
