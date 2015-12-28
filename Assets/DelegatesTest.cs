using UnityEngine;
using System.Collections;

public class DelegatesTest : MonoBehaviour {

	// variables for delegate to manipulate
	public int ammoCount;
	private bool isHealthy;
	private bool isDead;

	// delegates setup
	private delegate void TrackInventory();
	private TrackInventory trackingHandler;

	// test switches for branching into delegate methods
	public bool testInjury;
	public bool testShooting;

	/*
	 *	Coroutine Movement using properties and delegates
	 * (delegate and property in coroutine movement script)
	 */
	public DelegatesCoroutineMovement testMovement;


	void Start () {
		isHealthy = true;
		isDead = false;
	}

	void Update () {
		if (testInjury) {
			trackingHandler += Injure;
			testInjury = false;
		} else if (testShooting) {
			trackingHandler += ShootBullets;
			testShooting = false;
		} else {
			// pass
			//trackingHandler -= ShootBullets;
			//trackingHandler -= Injure;
		}

		if (trackingHandler != null) {
			trackingHandler();
			trackingHandler -= ShootBullets;
			trackingHandler -= Injure;
		}

		// grab a clicked object's position and use property coroutine movement script to lerp that object towards it
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			Physics.Raycast(ray, out hit);
			if (hit.collider != null) {
				testMovement.Pos = hit.point;
			}
		}
	}

	// Not running - using Input.GetMouseButtonDown above:
	// http://answers.unity3d.com/questions/425478/onmousedown-not-firing.html
//	void OnMouseDown () {
//		Debug.Log ("DelegatesTest - OnMouseDown() is firing!");
//		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//		RaycastHit hit;
//		Physics.Raycast(ray, out hit);
//		if (hit.collider.gameObject != null) {
//			testMovement.Pos = hit.point+new Vector3(0f,0.5f,0f);
//		}
//	}


	void Injure () {
		if (isHealthy) {
			isHealthy = false;
			Debug.Log ("You got hit!");
		} else {
			Kill();
		}
	}

	void ShootBullets () {
		ammoCount = ammoCount > 0 ? ammoCount-1 : 0;
	}

	void Kill () {
		isDead = true;
		Debug.Log ("You would be dead now!");
	}
}