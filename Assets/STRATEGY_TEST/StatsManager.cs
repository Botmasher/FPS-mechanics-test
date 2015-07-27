using UnityEngine;
using System.Collections;

public class StatsManager : MonoBehaviour {

	Stats.Statistics stats = new Stats.Statistics(1);
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.S)) {
			this.stats.Change (1,1);
			this.stats.Display ();
		}

	}

}
