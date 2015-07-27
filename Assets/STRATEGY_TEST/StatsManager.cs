using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatsManager : MonoBehaviour {

	public int playerID;					// player number to pass to stats object
	Stats.Statistics stats;					// player attributes
	List<int> updates = new List<int> ();	// stats to update this round
	public bool isStatsChange = false;		// control flow for updating stats


	void Start () {
		stats = new Stats.Statistics (playerID);		// initialize new stats for this player
	}


	void Update () {

		// update stats when time to
		if (isStatsChange) {
			for (int i = 0; i < updates.Count; i++) {
				this.stats.Change (i, 1);
			}
			this.stats.Display ();
			isStatsChange = false;
		}

	}

}
