using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Items : MonoBehaviour {

	public int statsCost;
	public int peopleCost;
	public int moneyCost;
	[SerializeField]public List<Item> dependencies;
	[SerializeField]public List<int> statsInfluences;
	Sprite icon;
	GameObject mesh;

	// script for instantiated item object
	private Item thisItem;


	/**
 	 *	created items:
 	 *		- show up in player inventory
 	 *		- can be built in world
 	 *		- impact player stats
 	 *		- have dependencies
 	 *		- have costs
 	 */
	public class Item {

		Sprite icon;							// player inventory UI image
		GameObject mesh;						// world footprint and built visual
		List<int> influences;					// player's influenced stats

		// costs
		int peopleCost;
		int moneyCost;
		int statsCost;
		List<Item> requirements;

		// use player script?
		Transform player;						// determine player possession for stats influence

		public Item (Sprite icon, GameObject mesh, List<int> influences, int people, int money, int stats, List<Item> dependencies) {
			this.icon = icon;
			this.mesh = mesh;
			this.influences = influences;
			this.peopleCost = people;
			this.moneyCost = money;
			this.statsCost = stats;
			this.requirements = dependencies;
		}

		// influence the player's stats
		void Stats () {
			for (int i=0; i<influences.Count; i++) {
				// select stat from instantiated player stats
				// impact player stats script
			}
		}
	
	}


	void Start () {
		thisItem = new Item (icon, mesh, statsInfluences, peopleCost, moneyCost, statsCost, dependencies);
	}


}