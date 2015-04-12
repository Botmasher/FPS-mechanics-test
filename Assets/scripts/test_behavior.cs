using UnityEngine;
using System.Collections;

public class test_behavior : MonoBehaviour {

	// Use this for initialization
	private GameObject cube1;
	void Start () {
		cube1 = GameObject.Find ("Cube1");
		cube1.transform.position = new Vector3(0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		cube1.transform.Translate(Vector3.up * Time.deltaTime);
	}
}