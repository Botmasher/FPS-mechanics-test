using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/**
 *	class for creating items:
 *		- show up in player inventory
 *		- built in world
 *		- impact player stats
 */
public class Items : MonoBehaviour {

	public class Item {

		Sprite icon;							// player inventory UI image
		GameObject mesh;						// world footprint and built visual
		List<int> influences;					// player's influenced stats

		// use player script?
		Transform player;						// determine player possession for stats influence

		public Item (Sprite icon, GameObject mesh, List<int> influences) {
			this.icon = icon;
			this.mesh = mesh;
			this.influences = influences;
		}

		// influence the player's stats
		void Stats () {
			for (int i=0; i<influences.Count; i++) {
				// select stat from instantiated player stats
				// impact player stats script
			}
		}
	
	}

}