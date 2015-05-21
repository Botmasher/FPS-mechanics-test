using UnityEngine;
using System.Collections;

public class FPSDeathPit : MonoBehaviour {
	
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "FPS Player") {
			Application.LoadLevel (Application.loadedLevel);
		} else {
			Destroy(other.gameObject);
		}
	}

}
