using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MouseMenuClick : MonoBehaviour {

	// name, tag and label strings for tracking down game objects
	public string playerTag = "Player";
	public string worldName = "World";
	public GameObject rightPlayer;
	public GameObject leftPlayer;
	public GameObject topPlayer;
	public GameObject bottomPlayer;
	public GameObject world;

	private string currentName;			// name of the current target
	private string currentTag;			// tag of the current target

	// mouse click variables
	private RaycastHit hit;
	private Ray ray;
	private Transform viewer;
	private Vector3 viewTarget;
	public List<GameObject> realms = new List<GameObject> ();

	// UI elements
	public Canvas menu;
	public Text menuText;
	public RectTransform menuImage;


	void Awake () {

		// camera for raycasts
		viewer = Camera.main.transform as Transform;
		viewTarget = viewer.position;			// camera lerp position initially set to self

		// list of on-screen world realms for controller following and selection
		for (int i=0; i < GameObject.FindGameObjectsWithTag (playerTag).Length; i++) {
			realms.Add ( GameObject.FindGameObjectsWithTag (playerTag) [i] );
		}
		realms.Add ( GameObject.Find (worldName) );

	}


	void Update () {

		/* 	Conceptualize board space and choose move target when mouse
		 * 	moves to edge of screen. "Realm" is the term for game spaces.
		 *  
		 *	BOARD LAYOUT:
		 * 
		 * 				   Top
	 	 *				 	| 			
		 * 		  Left - (world) - Right
		 *					|
		 * 				   Down
		 * 
		 * 	Branches choose a target relative to current board target.
		 * 	/!\  This five-point layout is currently hard-coded below.
		 * 
		 */
		if (Input.mousePosition.y < Screen.height * 0.1f) {
			if (Mathf.Abs (viewer.position.z - world.transform.position.z) < 1f) {
				viewTarget = bottomPlayer.transform.position;
			} else if (Mathf.Abs (viewer.position.z - topPlayer.transform.position.z) < 1f) {
				viewTarget = world.transform.position;
			} else {
				// do not lerp down realms
			}
		} else if (Input.mousePosition.y > Screen.height * 0.9f) {
			if (Mathf.Abs (viewer.position.z - world.transform.position.z) < 1f) {
				viewTarget = topPlayer.transform.position;
			} else if (Mathf.Abs (viewer.position.z - bottomPlayer.transform.position.z) < 1f) {
				viewTarget = world.transform.position;
			} else {
				// do not lerp up realms
			}

		} else if (Input.mousePosition.x > Screen.width * 0.9f) {
			if (Mathf.Abs (viewer.position.x - world.transform.position.x) < 1f) {
				viewTarget = rightPlayer.transform.position;
			} else if (Mathf.Abs (viewer.position.x - leftPlayer.transform.position.x) < 1f) {
				viewTarget = world.transform.position;
			} else {
				// do not lerp right realms
			}
		} else if (Input.mousePosition.x < Screen.width * 0.1f) {
			if (Mathf.Abs (viewer.position.x - world.transform.position.x) < 1f) {
				viewTarget = leftPlayer.transform.position;
			} else if (Mathf.Abs (viewer.position.x - rightPlayer.transform.position.x) < 1f) {
				viewTarget = world.transform.position;
			} else {
				// do not lerp left realms
			}

		} else {
			// do not lerp realms at all
		}


		// raycast mouse button click
		if ( Input.GetMouseButtonDown (0) ) {
			// close UI any open menu
			if (menu.GetComponent<Canvas> ().enabled) {
				menu.GetComponent<Canvas> ().enabled = false;
			}
			// check for target, open its UI menu and focus on it
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				// make sure not to lerp away from hit target
				viewTarget = hit.transform.position;
				// bring up UI menu
				ShowMenu (hit.transform);
			}
		}

		MoveCamera (viewTarget);

	}


	/**
	 * 	Move camera view towards game object
	 * 		- identify target that camera should "lock"
	 * 		- camera lerps towards until locks
	 */
	public void MoveCamera (Vector3 viewTarget) {
		if (viewer.position != viewTarget) {
			viewer.position = Vector3.Lerp (viewer.position, new Vector3 (viewTarget.x, viewer.position.y, viewTarget.z), 2f*Time.deltaTime);
		}
	}


	/**
	 * 	Bring up the stats menu contextualized to a particular object
	 */
	public void ShowMenu (Transform statsObject) {
		menu.GetComponent<Canvas> ().enabled = true;
		menuImage.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, 200f);
		menuText.text = statsObject.name.ToUpper() + ":\n" +
				"Nooopies!" + "\n" +
				"I am " + statsObject.name + " and you found the menu that is mine of the menus!" + "\n" +
				"Wha... how could you?";

		// change font colors based on player
		if (statsObject.name == "Player 1") {
			menuText.color = Color.blue;
		} else if (statsObject.name == "Player 2") {
			menuText.color = Color.red;
		} else if (statsObject.name == "Player 3") {
			menuText.color = Color.magenta;
		} else if (statsObject.name == "Player 4") {
			menuText.color = Color.cyan;
		} else if (statsObject.name == "World") {
			menuText.color = Color.green;
		}

	}

}
