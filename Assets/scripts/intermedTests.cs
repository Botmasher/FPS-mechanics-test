using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class intermedTests : MonoBehaviour {

	// audio spectrum visualization
	public UnityEngine.Audio.AudioMixer gameAudioMixer;
	private AudioSource audio;

	public GameObject cube;
	private List<GameObject> cubesies = new List<GameObject>();

	private float avgdenom = 0f;
	private float avgnum = 0f;

	// abstract class for all child inventories
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

		for (int i = 0; i<5; i++) {
			cubesies.Add(Instantiate (cube, transform.right*(float)i*2f, Quaternion.identity) as GameObject);
			Debug.Log(cubesies[i]);
		}

		audio = GetComponent<AudioSource> ();

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
		avgnum = 0f;
		avgdenom = 0f;
		float[] spectrum = audio.GetSpectrumData(1024, 0, FFTWindow.BlackmanHarris);

		/*	Unity API code for testing spectrum data display
		int i = 1;
		while (i < 1023) {
			Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
			Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
			Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
			Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.yellow);
			i++;
		} */

		// make this object scale up and down along y axis with bass 
		for (int i = 0; i<200; i++) {
			avgnum += spectrum[i];
			avgdenom++;
			i++;
		}
		this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3 (1f,avgnum/avgdenom*350f,1f), 0.5f);
		//this.transform.localScale = new Vector3 (1f,avgnum/avgdenom*400f,1f);

		// make other objects scale up and down along y axis with various spectra 
		avgnum = 0f;
		avgdenom = 0f;
		for (int i = 200; i<500; i++) {
			avgnum += spectrum[i];
			avgdenom++;
			i++;
		}
		cubesies[0].transform.localScale = new Vector3 (1f,avgnum/avgdenom*500f,1f);

		avgnum = 0f;
		avgdenom = 0f;
		for (int i = 500; i<700; i++) {
			avgnum += spectrum[i];
			avgdenom++;
			i++;
		}
		cubesies[1].transform.localScale = new Vector3 (1f,avgnum/avgdenom*1000f,1f);

		avgnum = 0f;
		avgdenom = 0f;
		for (int i = 700; i<870; i++) {
			avgnum += spectrum[i];
			avgdenom++;
			i++;
		}
		cubesies[2].transform.localScale = Vector3.Lerp(cubesies[1].transform.localScale, new Vector3 (1f,avgnum/avgdenom*10000f,1f), 0.5f);

		avgnum = 0f;
		avgdenom = 0f;
		for (int i = 870; i<1024; i++) {
			avgnum += spectrum[i];
			avgdenom++;
			i++;
		}
		cubesies[3].transform.localScale = new Vector3 (1f,avgnum/avgdenom*5000f,1f);
	}
}
