using UnityEngine;
using System.Collections;

public class variables : MonoBehaviour {
	// loop test vars -- just to understand behavior of while, do while, for and foreach loops in C#
	private int myInt = 0;
	private bool isLoop = true;
	private string[] strArray1 = new string[5] {"friends","enemies","weapons","potions","ammo"};

	// finds and boxes Inspector component "Light" for this object
	private Light myLight;

	// objects to set active/inactive and check status in hierarchy
	public GameObject myObject;

	// speed factors for keypress transform.Translate and transform.Rotate called in update
	public float moveSpeed = 5f;
	public float turnSpeed = 500f;

	// variable to look at with transform.Target (try putting camera in!)
	public Transform target;


	// Unity method; always called first
	void Awake () {
	}


	// Unity method; may be called after awake to start behavior
	void Start () {
	
		// Turn game objects on and off. Check their status in the parent/child hierarchy
		gameObject.SetActive (true);
		Debug.Log ("Active Self: "+myObject.activeSelf);
		Debug.Log ("Active in hierarchy: "+myObject.activeInHierarchy);

		myLight = GetComponent<Light> ();
	
		// test loops
	
	/*
		while (myInt < 5) {
			myInt += 1;
			Debug.Log (myInt);
		}
	*/

	/*
		do {
			myInt += 1;
			Debug.Log ("Round "+myInt + ". Continue loop = "+ isLoop);
			if (myInt == 5) {
				isLoop = false;
			}
		} while (isLoop == true);
	*/

	/*
		for (int i = 0; i < 5; i++) {
			Debug.Log (i+1);
		}
	*/
	
	/*
		foreach (string x in strArray1) {
			Debug.Log (x);
		}
	*/

	}


	// Unity method; called once per frame. Used for most game elements that change over time
	void Update () {
		// toggle component Light on Player after adding Light component to Player in Inspector
		if (Input.GetKeyUp (KeyCode.Space)) {
			myLight.enabled = !myLight.enabled;
		}

		/* move & rotate player as fast as Speeds (init or in Inspector) & per sec (deltatime) rather than in frames
		 *		transform.Translate changes this object's position in space
		 *		transform.Rotate changes alignment of this object relative to local axes
		 *		/!\  If moving an object with a collider (interacting with physics), use physics functions instead.
		 *		/!\  The only time you want to affect a transform is with a rigid body that is kinematic.
		 */ 
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate (-Vector3.forward * moveSpeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate (Vector3.up, -turnSpeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (Vector3.up, turnSpeed * Time.deltaTime);
		}

	}
	

	// Unity method; called at regular time intervals. Used for physics elements and rigid bodies
	void FixedUpdate () {
	}


	// Sample custom function -- take number and multiply it by 2
	int MultiplyByTwo (int num) {
		int returnVal;
		returnVal = num * 2;
		return returnVal;
	}

}
