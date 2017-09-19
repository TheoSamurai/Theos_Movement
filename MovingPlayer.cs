using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayer : MonoBehaviour {


	public float speed = 25.0f;

	public float JumpSpeed = 300.0f;

	private Rigidbody rb;

	private bool isJumping = false;

	private bool RunningJump = false;

	private bool SpeedUp = false;


	void Start () {

		rb = GetComponent<Rigidbody> (); // rb is defined as the RigidBody on the player object.

	}


	void FixedUpdate () {

		float MoveX = Input.GetAxis ("Horizontal"); // all inputs and values for Horizontal movement are defined in the float MoveX? I think thats how it works...
		float MoveZ = Input.GetAxis ("Vertical"); // Same as MoveX but for the Vertical Axis (z axis) :)

		Vector3 movement = new Vector3 (MoveX, 0.0f, MoveZ); // 'movement' is equal to a new Vec3 with the values of all Horizontal movement on x, 0 for y  and Vertical Movement
															 // for the z axis :D

		rb.AddForce (movement * speed); // Adds a force to the player object based on the Vector3 movement multiplied by the speed of the ball 'speed' :))

		if (RunningJump == true && isJumping == false) {

			Jump (); // Runs the Jump function! :D

		}

		if (SpeedUp == true) {

			speed = 50.0f;

		}

	}


	void Update () {

		RunningJump = Input.GetKey (KeyCode.Space); // Jump () will only run when 'RunningJump' is true, and by setting its value to the user input for jump (spacebar), the false
													// is automatically set to being when the spacebar is not being pressed!! Much easier than using if/else statements! :DD

		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {

			SpeedUp = true;

		} else {

			SpeedUp = false;

			speed = 25.0f;

		}
	}												


	void Jump () {

		rb.AddForce (JumpSpeed * Vector3.up); // Adds a force to the Vector3's up (y values) multiplied by the Jumpspeed to make the player object hop :)

	}


	void OnCollisionStay (Collision other) { // When touching the plane, the object has a y value of 0, therefore 'IsJumping' is false :))

		if (other.gameObject.tag == "plane") {

			isJumping = false;

		}

	}


	void OnCollisionExit (Collision other) { // When not touching the plane, the object is in the air, so 'IsJumping' is true :)

		if (other.gameObject.tag == "plane") {

			isJumping = true;

		}

	}






/* OPTIMISATIONS (for both Scripts):
 * 
 * 
 * 		• When off the gound plane, the player cannot Jump.
 * 
 * 		• If holding Left or Right Shift, the player will increase Speed.
 * 
 * 		• By using the Input.GetAxis method, both the 'WASD' and 'Arrow keys' work for movement.
 * 
 * 		• The Camera follows the PLayer Around the play area.
 * 
 * 
 * 	ISSUES THAT STILL NEED FIXING (both Scripts) :
 * 
 * 		• The camera does not rotate, so it is hard to navigate the play area efficiently - To fix this, I may implement a system that makes the front facing direction of
 * 		  both the main camera and the player object to the position of the mouse cursor: This may be difficult however since I do not know how to use Quaternions well yet :P
 */

}