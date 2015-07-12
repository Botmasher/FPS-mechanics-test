using UnityEngine;
using System.Collections;

public class InventoryManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BuildItem (string item) {
		Debug.Log ("Here's a footprint for your " + item + "!");
	}

}
