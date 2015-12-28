using UnityEngine;
using System.Collections;

public class EnumerableTest : MonoBehaviour {

	private bool runTestOnce;

	void Start() {
		runTestOnce = false;
	}

	void Update () {
		if (!runTestOnce) {
			foreach(int testVar in Test ()){
				Debug.Log (testVar);
			}
			runTestOnce=true;
		}
	}

	IEnumerable Test() {
		for (int i=0; i<5; i++) {
			yield return (i);
		}
		yield return (25);
	}

}
