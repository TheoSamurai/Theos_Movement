using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	private Vector3 offset; // Creates a New Vector3 to ensure the distance between the Camera and the player gameObject is constant :))

	public GameObject player; // GameObject is public so that it can be linked in the editor/inspector :)) This was done in the unity project, but it cannot be seen here :( sorry :/


	void Start () {

		offset = transform.position - player.transform.position; // the Vec3 'offset' is equal to the differenc between the camera and the player GameObject!

	}


	void LateUpdate () { //Runs after everything else, I think..

		transform.position = offset + player.transform.position; // the position of the Camera is equal to the difference between the camera and player 'offset' + the player
																 // objects position :)))
	}

}

// Optimisations and issues for this script are in the other script, 'MovingPlayer' :))