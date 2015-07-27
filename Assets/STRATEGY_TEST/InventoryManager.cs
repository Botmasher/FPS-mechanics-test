using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryManager : MonoBehaviour {

	private MouseMenuClick mainScript;		// reference to main game menu manager script

	public RectTransform menuItems;			// inventory list menu

	public Sprite iconA;					// inventory test icon 1
	public Sprite iconB;					// inventory test icon 2

	public GameObject footprintA;			// inventory test footprint 1
	public GameObject footprintB;			// inventory test footprint 2
	private GameObject footprint;			// reference to instantiated footprint

	// controlflow
	private bool isOnWorld;					// is mouse cursor near world
	private string playerID;				// the player whose inventory manager this is

	// raycast building placement
	private Ray ray = new Ray ();
	private RaycastHit hit;


	void Start () {
		// grab existing world objects for UI inventory and play menu manager script
		menuItems = GameObject.Find ("Inventory").GetComponent<RectTransform> ();
		mainScript = GameObject.Find ("Play Manager").GetComponent<MouseMenuClick> ();

		// build the right images into the right inventory slots
		menuItems.GetChild(0).GetComponent<Image> ().sprite = iconA;
		menuItems.GetChild(1).GetComponent<Image> ().sprite = iconB;

		// make sure that slots onclick functions will send the build items for that icon
		menuItems.GetChild(0).GetComponent<Button> ().onClick.AddListener (() => BuildItem(iconA));
		menuItems.GetChild(1).GetComponent<Button> ().onClick.AddListener (() => BuildItem(iconB));

		// make sure this object does not start out clickable or visible
		menuItems.gameObject.SetActive (false);
	}


	void Update () {

		// raycast from camera to mouse to determine inventory pointer
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Physics.Raycast (ray, out hit);

		// check if current mouse is hovering over world
		if (hit.transform != null && Mathf.Abs (hit.transform.position.x) <= Mathf.Abs (0.5f) && Mathf.Abs (hit.transform.position.z) <= Mathf.Abs (0.5f)) {
			isOnWorld = true;
		} else {
			isOnWorld = false;
		}

		// move any existing footprint around screen with mouse; place footprint if click on world; delete footprint if click outside of world
		if (footprint != null) {
			footprint.transform.position = new Vector3 (hit.point.x, hit.point.y, hit.point.z);
			// click to use footprint
			if (Input.GetMouseButton (0)) {
				// place building if click within x-z range of on top of world

				if (isOnWorld) {
					// place building in world and start impacting stats
					Debug.Log ("Adding bldg " + footprint.name + " to world!");
					WorldManager.thisWorld.AddItem (footprint.name, this.transform.parent.gameObject.name);
				}
				Destroy (footprint.gameObject);
			}

		}

	}


	/**
	 * 	create the building associated with clicked icon
	 *		/!\	 called via button onclick listener
	 */ 
	public void BuildItem (Sprite icon) {

		if (icon == iconA) {
			// instantiate footprintA
			footprint = Instantiate (footprintA, Input.mousePosition, Quaternion.identity) as GameObject;
		} else if (icon == iconB) {
			// instantiate footprintB
			footprint = Instantiate (footprintB, Input.mousePosition, Quaternion.identity) as GameObject;
		}

		// disable item


		menuItems.gameObject.SetActive (false);
		
	}

}
