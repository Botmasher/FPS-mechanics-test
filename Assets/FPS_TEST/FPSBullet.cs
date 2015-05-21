using UnityEngine;
using System.Collections;

public class FPSBullet : MonoBehaviour {

	public GameObject explosion;		// spawn particle effect on kill

	private float speed = 40f;			// bullet travel speed


	void Awake () {
		// initiate countdown to self-destruction
		StartCoroutine ("RemoveFromWorld");
	}


	void Update () {
		// move forward
		this.transform.Translate (Vector3.forward*speed*Time.deltaTime);
	}


	void OnTriggerEnter (Collider other) {
		// kill any hit enemy
		if (other.gameObject.tag == "Enemy") {
			Destroy (other.gameObject);
			Instantiate (explosion, this.transform.position, this.transform.rotation);
			Destroy (this.gameObject);
		}
	}

	IEnumerator RemoveFromWorld () {
		yield return new WaitForSeconds(1.6f);
		Destroy (this.gameObject);
	}

}
