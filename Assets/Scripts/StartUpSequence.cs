using UnityEngine;
using System.Collections;

public class StartUpSequence : MonoBehaviour {

	private GameManager gameManager;

	private string startTimer;
	private string startTimer2;
	public Font font;

	public AudioClip audioClip;

	private float startTimerInterval = 1.0f;

	// Use this for initialization
	void Start () {
		gameManager = GetComponent<GameManager>();
		StartCoroutine(StartSequence());   //launches startup coroutine	
	}

	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI () {
		GUIStyle startUpLabel = new GUIStyle (GUI.skin.label);
		startUpLabel.font = font;
		startUpLabel.fontSize = 100;
		startUpLabel.alignment = TextAnchor.MiddleCenter;
		startUpLabel.normal.textColor = Color.yellow;
		GUI.Label(new Rect(0, 0, Screen.width, Screen.height/2), startTimer, startUpLabel);
		GUI.Label(new Rect(0, Screen.height/2, Screen.width, Screen.height/2), startTimer2, startUpLabel);
	}

	IEnumerator StartSequence () { 
		//startup coroutine runs every frame until it's done (no need to go thorugh update() )

		startTimer = "GET READY";
		startTimer2 = startTimer;

		yield return StartCoroutine(gameManager.Wait (startTimerInterval));
		startTimer = "3";
		startTimer2 = startTimer;
		AudioSource.PlayClipAtPoint (audioClip, transform.position);
		yield return StartCoroutine(gameManager.Wait (startTimerInterval));
		startTimer = "2";
		startTimer2 = startTimer;
		AudioSource.PlayClipAtPoint (audioClip, transform.position);
		yield return StartCoroutine(gameManager.Wait (startTimerInterval));
		startTimer = "1";
		startTimer2 = startTimer;
		AudioSource.PlayClipAtPoint (audioClip, transform.position);
		yield return StartCoroutine(gameManager.Wait (startTimerInterval));

		startTimer = "Mash W and X !";
		startTimer2 = "Mash Left and Right !";
		AudioSource.PlayClipAtPoint (audioClip, transform.position);
		//activate players
		foreach ( GameObject player in gameManager.players) {
			player.GetComponent<PlayerControl>().on = true;			
		}


		yield return StartCoroutine(gameManager.Wait (startTimerInterval/2));
		startTimer = "";
		startTimer2 = "";
		yield return StartCoroutine(gameManager.Wait (startTimerInterval/2));
		startTimer = "Mash W and X !";
		startTimer2 = "Mash Left and Right !";
		yield return StartCoroutine(gameManager.Wait (startTimerInterval/2));
		startTimer = "";
		startTimer2 = "";
		yield return StartCoroutine(gameManager.Wait (startTimerInterval/2));
		startTimer = "Mash W and X !";
		startTimer2 = "Mash Left and Right !";
		yield return StartCoroutine(gameManager.Wait (startTimerInterval/2));
		startTimer = "";
		startTimer2 = "";
		yield return StartCoroutine(gameManager.Wait (startTimerInterval/2));
		startTimer = "Mash W and X !";
		startTimer2 = "Mash Left and Right !";
		yield return StartCoroutine(gameManager.Wait (startTimerInterval/2));
		startTimer = "";
		startTimer2 = "";
		yield return StartCoroutine(gameManager.Wait (startTimerInterval/2));
		startTimer = "Mash W and X !";
		startTimer2 = "Mash Left and Right !";
		yield return StartCoroutine(gameManager.Wait (startTimerInterval/2));

		//deactivate component so that the loop is not performend anymore
		this.enabled = false;
	}


}
