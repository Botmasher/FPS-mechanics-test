using UnityEngine;
using System.Collections;

public class Player2Variables : MonoBehaviour {
	// setup attributes for this player
	public class Speed {
		public float moveSpeed;
		public float turnSpeed;
	
		// speed constructor -- used when multiple values input
		public Speed (float mov, float turn) {
			moveSpeed = mov;
			turnSpeed = turn;
		}

		// speed constructor -- used when single value input
		public Speed (float mov) {
			moveSpeed = mov;
		}
	}

	// instantiate speed assignments for this session
	public Speed mySpeeds = new Speed (7.0f, 350.0f);


	// Update is called once per frame
	void Update () {
		// variable initializations for this frame

		/* get button input axis strength -- see InputManager to adjust:
		 *		gravity			-	how hard the input pulls
		 *		sensitivity		- 	how hard the input pushes
		 *		dead zone		-	distance from true before any input registers (for e.g. joystick)
		 *		snap 			-	whether conflicting pos+neg inputs along same axis cancel out
		 */
		float move = Input.GetAxis ("Move");
		float turn = Input.GetAxis ("Rotate");

		// object methods for this frame

		// if pressed, use "move" axis input value to translate this object at a certain speed (factor in movespeed and time)
		if(Input.GetButton ("Move")) {
			transform.Translate (0, 0, move * mySpeeds.moveSpeed * Time.deltaTime);
		}

		// if pressed, use "rotate" axis input value to turn this object at a certain rate (factor in turnspeed and time)
		if(Input.GetButton ("Rotate")) {
			transform.Rotate (0, turn * mySpeeds.turnSpeed * Time.deltaTime, 0);
		}

	}
}
