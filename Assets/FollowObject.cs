using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour {

	public GameObject camTarget;

	void Update () {
		transform.position = new Vector3 (camTarget.transform.position.x, this.transform.position.y, this.transform.position.z);
	}

}
