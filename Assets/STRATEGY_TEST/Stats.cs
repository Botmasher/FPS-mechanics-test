using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// statistics for each player
public class Stats : MonoBehaviour {

	int playerID;
	Dictionary<string,int> map = new Dictionary<string,int>();
	List <string> names = new List<string>();

	public Stats (int playerID) {
		this.playerID = playerID;

		// build list of attributes
		this.names.Add ("tradition progress");
		this.names.Add ("fear wonder");
		this.names.Add ("authority liberty");

		// map attributes to starting values
		for (int x=0; x<names.Count; x++) {
			this.map.Add(this.names[x], 0);
		}
	}

	// use dictionary key or list name id to change stat value

	public void ChangeStat (string statName, int valueAdd) {
		this.map[statName] += valueAdd;
	}

	public void ChangeStat (int statID, int valueAdd) {
		this.map [names [statID]] += valueAdd;
	}

}
