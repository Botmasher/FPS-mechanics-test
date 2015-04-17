using UnityEngine;
using System.Collections;

public class CoroutineMvmt : MonoBehaviour {
	// inspector variable for our movement target
	public Transform target;
	[Range(0.3f,1f)] public float speed;

	// play the coroutine below -- call for movement outside of update!!
	void Start () {
		StartCoroutine (MyCoroutine(target));
	}


	// Update is called once per frame
	void Update () {
	
	}

	// example coroutine - executes movement outside of Update calls!!!
	IEnumerator MyCoroutine (Transform target1) {
		// loop check the distance between this object and the target (defined above)
		while (Vector3.Distance (transform.position, target1.position) > 0.03f) {
			// move a bit closer to the target, then wait
			transform.position = Vector3.Lerp (transform.position, target1.position, speed*Time.deltaTime);
			yield return null;
		}
		print ("Reached the target!");
		yield return new WaitForSeconds(2f);
		print ("Coroutine done.");
	}
}
