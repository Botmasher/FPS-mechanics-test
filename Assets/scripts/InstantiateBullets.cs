using UnityEngine;
using System.Collections;

public class InstantiateBullets : MonoBehaviour {
	// gameobject to store created bullets
	private GameObject bullet;
	// gameobject to store existing empty (bullet spawn location) 
	private GameObject empty;


	// Start runs at beginning of gameplay, but after Awake
	void Start() {
		// assign to parented empty
		empty = GameObject.Find("bulletsEmpty");
	}


	// Update is called once per frame
	void Update () {

		/* create and move bullet primitive on input fire1
		 * 
		 * 		/!\	This is standardly done using Instantiate() and a public prefab
		 * 			(assigned in Inspector) with rigidbody component enabled.
		 */
		if (Input.GetButtonDown("Fire1")) {
			Invoke ("MakeBullet", 0.1f);
			Invoke ("DestroyBullet", 0.15f);
		}

		// continue moving bullets if they exist in the world
		if (bullet != null) {
			bullet.transform.Translate (Vector3.forward * 5 * Time.deltaTime);
		}
	}


	// object creation function called when player presses fire
	void MakeBullet() {
		// make a sphere and store it in bullet object declared above
		bullet = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		// make bullet a rigidbody for physics effects (mostly so it drops with gravity)
		bullet.AddComponent<Rigidbody>();
		bullet.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
		// set bullet's position and rotation relative to empty (instead of spawning at world origin)
		bullet.transform.position = empty.transform.position;
		bullet.transform.rotation = empty.transform.rotation;
	}


	// previous object destruction called when player presses fire 
	void DestroyBullet() {
		// get rid of existing bullet after certain number of seconds
		if (bullet != null) {
			Destroy (bullet, 0.5f);
		}
	}

}
