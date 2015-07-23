using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldManager : MonoBehaviour {

	public static World thisWorld;


	/**
	 *	Data and behaviors for world that sits in center of game board
	 */
	public sealed class World {
		string name;
		Dictionary<string, string> builts;

		// initialize world
		public World (string name) {
			this.name = name;
			this.builts = new Dictionary<string, string> ();
		}

		// add built item to world
		public void AddItem (string itemName, string playerName) {
			this.builts [itemName] = playerName;
			Debug.Log ("added " + this.builts[itemName] + "\'s " + itemName + " to the dictionary!");
		}

	}


	void Awake () {
		thisWorld = new World ("World");
	}

}
