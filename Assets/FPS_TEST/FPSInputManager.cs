using UnityEngine;
using System.Collections;

public class FPSInputManager : MonoBehaviour {

	// Game objects for instantiation
	public GameObject bullet;			// bullets to spawn on fire
	public GameObject playerGunBarrel;	// spawned bullet loc and rot
	public GameObject explosion;		// short particle system spawned on key events
	public GameObject playerGun;		// gun with animation states

	// UI elements to update during play
	public UnityEngine.UI.Text hudTxt;	// display bullets and status

	// Audio to play on effects
	public AudioClip sfxShoot;
	public AudioClip sfxClipEmpty;
	public AudioClip sfxReload;
	private AudioSource soundSource;	// audio component for sfx playback

	// Game objects that change with input
	private GameObject player;			// player gameobject
	private GameObject playerCam;		// camera parented to player gameobject
	private Animator playerGunAnims;	// pulls animator from playerGun object (for sway, reload, ...)

	// Stored input
	private float strafeHoriz;			// strafe key movements
	private float strafeVert;				//
	private float lookHoriz;			// mouse look movements
	private float lookVert;					//

	// movement factors
	private float sensitivity = 0.1f;	// turn sensitivity
	private float speed = 5f;			// strafe speed
	private float rotHoriz = 0f;		// rotation point along player midline in world space
	private float rotVert = 0f;			// rotation point along horizon in world space

	// state checks (flipped during relevant event)
	private bool isJumping = false;
	private bool isCrouching = false;
	private bool isFiring = false;

	// projectile firing checks
	private int clipTotal = 10;			// total number of bullets in clip
	private int clipCurrent;			// current number of bullets in clip
	private float fireRate = 0.3f;		// real num passed to coroutine to wait between bullets

	
	void Awake () {
		// load in gameobjects that change with input
		player = GameObject.FindGameObjectWithTag ("FPS Player");
		playerCam = GameObject.FindGameObjectWithTag ("MainCamera");

		// animations and state machine on player gun (for reloads, sway, ...)
		playerGunAnims = playerGun.GetComponent<Animator>();

		// store this object's audio source for audio clip load and playback (see SFX method)
		soundSource = gameObject.GetComponent<AudioSource>();

		// load bullets
		clipCurrent = clipTotal;

		// smooth player speed by time
		speed *= Time.deltaTime;

		// hide mouse cursor
		Cursor.visible = false;
	}


	void Update () {
		// Print UI updates to screen
		DisplayBulletCount (clipCurrent, clipTotal);

		// get strafe input
		strafeHoriz = Input.GetAxis ("Strafe Horizontal");
		strafeVert = Input.GetAxis ("Strafe Vertical");

		// strafe player movement
		player.transform.Translate (new Vector3(strafeHoriz * speed, 0f, strafeVert * speed));

		// get look input
		lookHoriz = Input.GetAxis ("Rotate Horizontal");
		lookVert = Input.GetAxis ("Rotate Vertical");

		// determine how much player cam will look up and down
		rotVert += lookVert * sensitivity * Time.deltaTime;
		rotVert = Mathf.Clamp (rotVert, -40f, 30f);

		// determine how much player will look along horizon
		rotHoriz += lookHoriz * sensitivity * Time.deltaTime;

		// tilt player camera (or implement head with parented cam!) along x
		playerCam.transform.localEulerAngles = new Vector3(rotVert, player.transform.rotation.y, 0f);

		// turn player around y
		player.transform.localEulerAngles = new Vector3(player.transform.rotation.x, rotHoriz, 0f);


		// place force under player to jump
		if (Input.GetButtonDown ("Jump") && isJumping == false) {
			StartCoroutine ("PlayerJump");
			// play jump sfx
		}

		// bullets from player
		if (Input.GetButton ("Fire") && isFiring == false) {
			StartCoroutine ("PlayerShoot");
		}

		// player reload timing and animation
		if (Input.GetButtonDown ("Reload")) {
			playerGunAnims.SetTrigger("triggerReload");		// state machine trigger for reload anim
			clipCurrent = clipTotal;						// reset bullets to clip total
			// play reload sfx
			PlaySFX (sfxReload);
		}
		
		// crouch player
		if (Input.GetButtonDown ("Crouch")) {
			if (isCrouching == false) {
				// shrink parent collider and recenter it to give crouching effect on camera
				player.GetComponent<BoxCollider>().size = new Vector3(1f,0.2f,1f);
				player.GetComponent<BoxCollider>().center = new Vector3(0f,-0.2f,0f);
				speed *= 0.25f;			// move slower while crouching
				isCrouching = true;
			} else {
				player.GetComponent<BoxCollider>().size = new Vector3(1f,1f,1f);
				player.GetComponent<BoxCollider>().center = Vector3.zero;
				speed *= 4f;			// return to regular move speed
				isCrouching = false;
			}
		}

	}


	/**
	 *	Jump:
	 *		-  toggle jumping on to prohibit stacking jumps (coroutine call again while jumping)
	 *		-  place force below player rigidbody component
	 *		-  wait for jump time
	 *		-  toggle jump off to allow jump coroutine call again
	 */
	IEnumerator PlayerJump () {
		isJumping = true;
		player.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up*130f,new Vector3(player.transform.position.x, player.transform.position.y-1f, player.transform.position.z));
		yield return new WaitForSeconds (0.5f);
		isJumping = false;
	}


	/**
	 * 	Shoot:
	 * 		-  spawn bullet (has own movement script)
	 * 		-  toggle firing on to prohibit stacking shots (coroutine call again while shooting)
	 * 		-  raycast for objects to shoot
	 * 		-  wait for fire rate
	 * 		-  toggle firing off to allow shoot coroutine call again
	 */
	IEnumerator PlayerShoot () {
		if (clipCurrent > 0) {
			clipCurrent --;		// remove bullet from clip count
			Instantiate (bullet, playerGunBarrel.transform.position, playerGunBarrel.transform.rotation);
			// play fire sfx
			PlaySFX (sfxShoot);
		} else {
			// play empty sfx
			PlaySFX (sfxClipEmpty);
		}

		isFiring = true;

		/*
		// Check for and destroy hit enemies (raycast from gun barrel)
		// THIS IS NOW DONE WITH COLLISION CHECKED BY PLAYER BULLET
		//		Reasoning: raycast gives immediate results when gun fired and makes bullet destruction an indirect process
		RaycastHit hit;
		if (Physics.Raycast (playerGunBarrel.transform.position, playerGunBarrel.transform.forward, out hit, 100f)) {
			if (hit.transform.gameObject.tag == "Enemy") {
				Instantiate (explosion, hit.transform.position, hit.transform.rotation);
				Destroy (hit.transform.gameObject);
			}
		}
		*/

		yield return new WaitForSeconds (fireRate);
		isFiring = false;
	}


	/**
	 * 	Load sound effect into this audio source, then play it
	 * 			ARGS:
	 * 		 	 1  clip 		// REQUIRED sfx file to play
	 * 			(2	sfxPlayer 	// OPTIONAL playback source; defaults to this object's audiosource)  
	 */
	void PlaySFX (AudioClip clip) {
		soundSource.clip = clip;
		soundSource.Play ();
	}

	void DisplayBulletCount (int clipCurrent, int clipTotal) {
		hudTxt.text = "";
		for (int i=0; i<clipCurrent; i++) {
			hudTxt.text += "|";
		}
		for (int i=0; i<clipTotal-clipCurrent; i++) {
			hudTxt.text += ".";
		}
	}

}