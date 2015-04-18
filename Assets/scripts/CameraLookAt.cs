using UnityEngine;
using System.Collections;

public class CameraLookAt : MonoBehaviour {
	// assign target to this camera in Inspector
	public Transform target;

	void Start(){
	}

	void Update(){
		// focus camera on target
		transform.LookAt(target);
	}
}