using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Levels : MonoBehaviour {

	public string levelName;
	[SerializeField]public List<Items.Item> buildables;

	// ref for instantiated level
	private Level thisLevel;


	/**
	 *	level manages items available to player, current stats attributes to player and value of items left in world
	 */
	public class Level {

		string name;				// name of this level
		List<Items.Item> builts;	// which items will be available this level
		List<int> influences;		// which stats will incur ongoing influence

		public Level (string name, List<Items.Item> buildables) {
			this.name = name;
			this.builts = buildables;
		}

	}


	void Start () {
		thisLevel = new Level (levelName, buildables);
	}

}