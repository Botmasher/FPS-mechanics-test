using UnityEngine;
using System.Collections;

public class TempPlayer : MonoBehaviour {

	private float horiz;
	private float vert;
	private float speed = 10f;
	private Ray ray;
	private RaycastHit hit;

	void Update () {
		// mvmt
		horiz = Input.GetAxis ("Strafe Horizontal");
		vert = Input.GetAxis ("Strafe Vertical");
		transform.Translate (Vector3.right * Time.deltaTime * vert * speed);
		transform.Translate (Vector3.back * Time.deltaTime * horiz * speed);

		// raycast
		if (Input.GetButton("Jump")) {
			ray.origin = this.transform.position;
			ray.direction = Vector3.right;
			if (Physics.Raycast (ray, out hit)) {
				Debug.Log ("CHOMMO, HIT THAT DUDE!");
				Destroy (hit.transform.gameObject);
			}
			Debug.DrawRay(ray.origin, ray.direction*10000f, Color.red);
		}

	}

}
