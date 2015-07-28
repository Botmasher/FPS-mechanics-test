using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Levels : MonoBehaviour {

	public string levelName;
	[SerializeField]public List<GameObject> buildables = new List<GameObject> ();

	// ref for instantiated level
	public Level thisLevel;


	/**
	 *	level manages items available to player, current stats attributes to player and value of items left in world
	 */
	public class Level {
		
		public string name;					// name of this level
		public List<GameObject> builts;		// which items will be available this level
		public List<int> influences;		// which stats will incur ongoing influence

		public Level (string name, List<GameObject> buildables) {
			this.name = name;
			this.builts = buildables;
		}

	}


	void Start () {
		thisLevel = new Level (levelName, buildables);
	}

}