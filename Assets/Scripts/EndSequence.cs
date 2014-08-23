using UnityEngine;
using System.Collections;

public class EndSequence : MonoBehaviour {

	private string endText;
	public Font font;
	private bool displayMenu = false;
	private string winnerName;
	private Color[] textColors;
	private GameManager gameManager;
	

	// Use this for initialization
	
	// Update is called once per frame

	void Start(){
		gameManager = GetComponent<GameManager>();
	}
	void Update () {
		if (displayMenu && Input.anyKey	)
		{
			Application.LoadLevel("menu");
		}

	}

	public void StartEndSequence(string name){
		winnerName = name;
		StartCoroutine(EndMenu());
	}

	IEnumerator EndMenu() {

		yield return StartCoroutine(gameManager.Wait (2.0f));  //WAIT FOR GAME OVER SCREEN
		displayMenu = true;
		yield return 0;
	}
	
	void OnGUI () {
		if (displayMenu) {
			GUIStyle endSequenceLabel = new GUIStyle (GUI.skin.label);
			endSequenceLabel.font = font;
			endSequenceLabel.fontSize = 150;
			endSequenceLabel.alignment = TextAnchor.MiddleCenter;
			endSequenceLabel.normal.textColor = Color.white;
			GUI.Label(new Rect(0, -128, Screen.width, Screen.height), winnerName + " Wins!", endSequenceLabel);
			endSequenceLabel.fontSize = 75;
			GUI.Label(new Rect(Screen.width/2-256, 128, 512, Screen.height), "Press any key to restart", endSequenceLabel);
		}
	}
}
