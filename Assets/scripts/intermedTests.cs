using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class intermedTests : MonoBehaviour {
	// abstract class for inventories
	public class Items {
		public int count;
		public string name;

		// base class constructor
		public Items(string inv, int num=0) {
			name = inv;
			count = num;
		}

		// some general inventory management methods to inherit
		public int Count() {
			return count;
		}
		public string Name() {
			return name;
		}
		public void Add(int i=1) {
			count += i;
		}
	}

	// weapons implementation of inventories
	public class Weapons : Items {
		public Weapons(): base ("weapons", 1) {}
	}

	// potions implementation of inventories
	public class Potions : Items {
		public Potions(): base ("potions", 0) {}
	}

	// create instances of each child
	Weapons WeaponInv = new Weapons ();
	Potions PotionInv = new Potions ();


	// call after Awake when gameplay begins
	void Start () {
		// create a list to store inventories - dict vs list test
		List<Items> myInventories = new List<Items>();
		myInventories.Add (WeaponInv);
		myInventories.Add (PotionInv);

		// create a dictionary to store inventories - dict vs list test
		Dictionary<string,int> myInvDict = new Dictionary<string,int>();
		myInvDict.Add (WeaponInv.Name (), WeaponInv.Count ());
		myInvDict.Add (PotionInv.Name (), PotionInv.Count ());

		// iterate over list of inventories - dict vs list test
		foreach (Items inv in myInventories) {
			Debug.Log ( "In my list, this is the number of "+inv.Name()+": "+inv.Count() );
		}

		// iterate over dict of inventories - dict vs list test
		foreach (KeyValuePair<string,int> inv in myInvDict) {
			Debug.Log ( "In my dict, this is the number of "+inv.Key+": "+inv.Value );
		}
	}

	// Update is called once per frame
	void Update () {
	}
}
