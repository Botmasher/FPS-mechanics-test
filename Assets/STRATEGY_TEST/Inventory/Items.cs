using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Items : MonoBehaviour {

	public int statsCost;
	public int peopleCost;
	public int moneyCost;
	public Sprite icon;
	public GameObject mesh;
	[SerializeField]public List<GameObject> dependencies;
	[SerializeField]public List<int> statsInfluences;


	// ref for instantiated item object
	public Item thisItem;


	/**
 	 *	created items:
 	 *		- show up in player inventory
 	 *		- can be built in world
 	 *		- impact player stats
 	 *		- have dependencies
 	 *		- have costs
 	 */
	public class Item {

		public Sprite icon;							// player inventory UI image
		public GameObject mesh;						// world footprint and built visual
		public List<int> influences;				// player's influenced stats

		// costs
		public int peopleCost;
		public int moneyCost;
		public int statsCost;
		public List<GameObject> requirements;

		// use player script?
		public Transform player;					// determine player possession for stats influence

		public Item (Sprite icon, GameObject mesh, List<int> influences, int people, int money, int stats, List<GameObject> dependencies) {
			this.icon = icon;
			this.mesh = mesh;
			this.influences = influences;
			this.peopleCost = people;
			this.moneyCost = money;
			this.statsCost = stats;
			this.requirements = dependencies;
		}

		// influence the player's stats
		void ChangeStats () {
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