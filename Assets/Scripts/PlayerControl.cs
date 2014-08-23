using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public Sprite spr1;
	public Sprite spr2;
	private bool secondSprite = false;

	////////////
	/// Movement
	////////////

	public bool on = false;

	public float speedH;
	public float speedV;


	public float maxSpeedH = 6.0f;
	public float initialMaxSpeedH;
	public float accelH = 0.25f;
	public float decelH = 0.05f;


	public float maxSpeedV = 3.5f;
	public float accelV = 0.5f;
	public float decelV = 0.25f;
	public float maxFallSpeed = 5f;

	private Vector2 amountToMove;

	private bool grounded = false;
	private bool hitWall = false;

	private Transform groundCheck;

	////////////
	/// Controls
	////////////

	private bool button1;
	private bool button2;
	private bool button_next = false;
	
	public string button1_name;
	public string button2_name;

	////////////
	/// Collision
	////////////

	private Vector3[] wallCheckOrigin;
	private Vector3[] wallCheckDestination;
	private float lineLenght = 1.0f;

	////////////
	/// LevelUp
	////////////

	public int playerLevel = 0;
	private float[] MaxSpeedCap = {0,25,50,75,100,125,150,175,200};

	////////////
	/// SpeedBar
	////////////





	// Use this for initialization

	void Start () {
		groundCheck = transform.Find ("groundCheck");
		Physics2D.IgnoreLayerCollision(gameObject.layer,gameObject.layer, true);

		wallCheckOrigin = new Vector3[3];
		wallCheckDestination = new Vector3[3];

		initialMaxSpeedH = maxSpeedH;   //set it up here to make sure the inspector value is respected
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		CheckCollisions ();
		GetControls ();
		CalcHForce ();
		CalcVForce ();
		Move ();


	}


	void CheckCollisions(){
		wallCheckOrigin[0] = new Vector3 (transform.position.x, transform.position.y + 0.8f, transform.position.z);
		wallCheckOrigin[1] = transform.position;
		wallCheckOrigin[2] = new Vector3 (transform.position.x, transform.position.y - 0.8f, transform.position.z);
		
		
		wallCheckDestination[0] = new Vector3 (transform.position.x + lineLenght, transform.position.y + 0.8f, transform.position.z);
		wallCheckDestination[1] = new Vector3 (transform.position.x + lineLenght, transform.position.y, transform.position.z);
		wallCheckDestination[2] = new Vector3 (transform.position.x + lineLenght, transform.position.y - 0.8f, transform.position.z);
		

		for (int i = 0; i < 3; i++) {


			Debug.DrawLine (wallCheckOrigin[i], wallCheckDestination[i], Color.green);
			hitWall = Physics2D.Linecast (wallCheckOrigin[i], wallCheckDestination[i], 1 << LayerMask.NameToLayer ("Ground"));
			if (hitWall){
				break;
			}
		}
	}

	void GetControls(){
		if (on) {
			button1 = Input.GetButton (button1_name);
			button2 = Input.GetButton (button2_name);
		} else  { 
			button1 = false;
			button2 = false;
		}
	}

	void CalcHForce(){

		//check button

		maxSpeedH = initialMaxSpeedH + (initialMaxSpeedH * (MaxSpeedCap[playerLevel]/100 ));

		if (!hitWall) {
			if (( button1 && !button2 && button_next == false ) || (!button1 && button2 && button_next == true)) {
				//accellerate if not against wall
				 
				if  ( speedH < maxSpeedH ){
					speedH += accelH;
				} else {
					//speed is not limited horizontally but once it
					//is over MaxSpeed player can't accellerate
				}
				button_next = !button_next;
				ChangeSprite();
			}

			//decellerate
			if (speedH > 0) {
				speedH -= decelH;
			} else {
				//speed is not limited horizontally but once it
				//is over MaxSpeed player can't accellerate

			}

		} else {
			//stop if next to wall
			speedH = 0;
		}
	}

	void CalcVForce(){

		grounded = Physics2D.Linecast(transform.position,groundCheck.position,1 << LayerMask.NameToLayer("Ground"));
		//hitCeiling = Physics2D.Linecast(transform.position,ceilingCheck.position,1 << LayerMask.NameToLayer("Ground"));

		//Gravity
		if (!grounded) {
			if (speedV < -maxFallSpeed){
				speedV = -maxFallSpeed;
			} else {
				speedV -= decelV;
			}
		} else {
			speedV = 0;
		}

		//Goin up

		if ((transform.localPosition.y < 10.25f)) {
			if (button1 && button2) { 
				if  ( speedV < maxSpeedV ){
					speedV += accelV;
				} 
				else {
					speedV = maxSpeedV;
				}
			}
		}
		else {
			speedV = 0;

		}

		speedV -= decelV;
	}


	void Move(){
		amountToMove = new Vector2 ( speedH, speedV );
		transform.Translate( amountToMove * Time.deltaTime );
	}

	void ChangeSprite() {
		switch (secondSprite) 
		{
			case false:
			GetComponent<SpriteRenderer>().sprite = spr1;
			break;

			case true:
			GetComponent<SpriteRenderer>().sprite = spr2;
			break;
		}

		secondSprite = !secondSprite;
	}



}
