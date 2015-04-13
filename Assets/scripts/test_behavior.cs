using UnityEngine;
using System.Collections;

public class test_behavior : MonoBehaviour {

	// Use this for initialization
	private GameObject cube1;
	void Start () {
		cube1 = GameObject.Find ("Cube 1");
		cube1.transform.position = new Vector3(0.0f,0.0f,0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		int 	listPos 	= 	3;
		string 	name 		=	"Josh";
		cube1.transform.Translate(Vector3.up * Time.deltaTime);
		if (listPos < 3) {
			for (int i =1; i<=5; i++) {
				Debug.Log (i);
			}
		} else if (listPos == 1) {
				Debug.Log ("Still in position");
		} else {
				Debug.Log ("My time is up. Thank you for yours.");
		}
		Debug.Log ("Your name is " + name + ". You aren't " + listPos + "!");
		bool gameOver = true;
		Debug.Log ("gameOver = " + gameOver);
		string[] inventory = new string[] {"health", "bullets", "potions"};
		foreach (string i in inventory) {
			Debug.Log (i);
		}
	}
}