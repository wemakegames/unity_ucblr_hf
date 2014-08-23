using UnityEngine;
using System.Collections;

public class camera_menu : MonoBehaviour {
	
	private Vector3 final_position;
	public float speed;
	public int movement_distance;
	public int initial_offset;

	
	// Use this for initialization
	void Start () {
		//moves camera a bit at the beginning
		Vector3 temp_coord = transform.localPosition;
		temp_coord.x = this.transform.localPosition.x + initial_offset;
		transform.localPosition = temp_coord;

		//hardcoded final position
		final_position = transform.position;
		final_position.x = transform.position.x + movement_distance;

	}
	
	// Update is called once per frame
	
	void Update () {
		
		//Vector3 temp_coord = transform.localPosition;
		//temp_coord.x = this.transform.localPosition.x + 0.1f;
		//transform.localPosition = temp_coord;

		transform.position = Vector3.Lerp(transform.position, final_position, Time.deltaTime * speed);
	}
}
