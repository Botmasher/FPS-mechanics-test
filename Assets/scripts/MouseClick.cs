using UnityEngine;
using System.Collections;

public class MouseClick : MonoBehaviour {
	// create vars for this object's components
	private Rigidbody rigid;

	// create var to access another object's components
	private GameObject otherObject;
	private Light playerLight;

	/* create var to access another object's script
 	 *
 	 *		/!\	The TYPE is its NAME. It is not SCRIPT. Notice how your scripts are CLASSES that inherit from MonoBehaviour!
	 */
	private PlayerVariables playerVariablesScript;


	// Unity method run first on gameplay
	void Awake () {
		// assign other object to player
		otherObject = GameObject.Find("player");

		/* assign to access other object's script component. GetComponent retrieves a <TYPE>.
		 *
		 *		/!\	GetComponent is EXPENSIVE. Please call once in Awake/Start and AS INFREQUENTLY AS POSSIBLE!
		 */
		playerVariablesScript = otherObject.GetComponent<PlayerVariables>();

		// use that script to grab the player's light component. We'll mess with player's light on clicks (below).
		playerLight = playerVariablesScript.GetComponent<Light>();
	}


	// Unity method for mouseclick
	void OnMouseDown () {

		Debug.Log ("HEY! You clicked on me! I'm the " + (gameObject.name).ToUpper() + "! \n Fine. I'll toggle your light!");

		// assign this object's rigidbody component
		rigid = GetComponent<Rigidbody>();
		/* Apply a force to this object through its rigidbody component.
		 *
		 *		/!\	This works because script is attached to object with RIGID BODY and BOX COLLIDER components!
		 */
		rigid.AddForce (-transform.forward *500);
		rigid.useGravity = true;

		// mess with the player's light
		playerLight.enabled = !playerLight.enabled;
	}

}
