using UnityEngine;
using System.Collections;

public class targetMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.up * 0.40f * Time.deltaTime);
	}
}
