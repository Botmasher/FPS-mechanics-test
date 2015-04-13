using UnityEngine;
using System.Collections;

public class variables : MonoBehaviour {
	int myInt = 5;

	void Start () {
		Debug.Log (MultiplyByTwo (myInt));	
	}

	int MultiplyByTwo (int num) {
		int returnVal;

		returnVal = num * 2;
		return returnVal;
	}

}
