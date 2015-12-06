using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Animator playerAnimator;
	private float moveHorizontal;
	private float moveVertical;
	private Vector3 movement;

	private float turningSpeed = 20f;
	private Rigidbody playerRigidbody;

	// Use this for initialization
	void Start () {
		//Gather components from the Player GameObject
		playerAnimator = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		//Gather input from the keyboard
		moveHorizontal = Input.GetAxisRaw ("Horizontal");
		moveVertical = Input.GetAxisRaw ("Vertical");

		movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
	}

	//used to help deal with physics.
	void FixedUpdate () {

		//If the player's movement does not equal zero...
		if (movement != Vector3.zero) {
			//...then create a target rotation based on the movement vector...
			Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);

			//...and create another rotation that moves from the current rotation to the target rotation.
			Quaternion newRotation = Quaternion.Lerp(playerRigidbody.rotation, targetRotation, 
			                                         turningSpeed * Time.deltaTime);
			//...and change the player's rotation to the new incremental rotation...
			playerRigidbody.MoveRotation(newRotation);

			//...then play the jump animation
			playerAnimator.SetFloat ("Speed", 3f); 
			//Note that the f after the 3 indicates that the 3 is a floating point value, not an integer


		} else {
			//...otherwise dont do the jump animation.
			playerAnimator.SetFloat ("Speed", 0f);
		}

	}


}
