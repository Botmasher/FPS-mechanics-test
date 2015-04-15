using UnityEngine;
using System.Collections;

public class scene2 : MonoBehaviour {
	// field for below property
	private int myInt;

	/* Accessor Property for above field.
	 *
	 *	Allows you to:
	 *		- make read (get) / write (set) only
	 *		- execute other code before getting/setting
	 *		- return value other than the bare field (e.g. field / 100)
	 *
	 *	Expected Use:
	 *		- named with capitals
	 *		- Object.PropertyName (e.g. int newNum = scene2.MyInt;)
	 */
	public int MyInt
	{
		get {
			return myInt;
		}
		set {
			myInt = value;
		}
	}

	// initializing property read or write only using accessors
	public int Happiness { get; set; }


	// Use this for initialization
	void Start () {
		MyInt = 5;

		/*	Ternary operator test in C#. Syntax is
		 *	booleanTest ? returnIfTrue : returnIfFalse
		 *	
		 *		/!\	For elegance and simplicity, AVOID nested ternaries
		 *
		 */	
		string message = myInt > 0 ? "You are alive!" : "You are dead!";

		Debug.Log (message);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
