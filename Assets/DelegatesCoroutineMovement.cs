using UnityEngine;
using System.Collections;

public class DelegatesCoroutineMovement : MonoBehaviour {

	// this object's movement delegate
	private delegate void MovementHandler (Vector3 position);
	MovementHandler moveHandler;

	// accessible property for target position
	public Vector3 Pos {
		get {
			return pos;
		} set {
			pos = value;
			StopCoroutine("ObjectMovementRoutine");
			StartCoroutine ("ObjectMovementRoutine",pos);
		}
	} Vector3 pos; // private variable set by this property


	// Overarching object movement coroutine
	// uses movehandler to run specific funcitons at specific times
	IEnumerator ObjectMovementRoutine (Vector3 targetPosition) {
		moveHandler -= LogTarget;
		moveHandler += LogTarget;
		while (Vector3.Distance (transform.position, targetPosition) > 0.1f) {
			moveHandler -= MoveToTarget;
			moveHandler += MoveToTarget;
			moveHandler (targetPosition);
			yield return new WaitForEndOfFrame();
		}
		yield return null;
	}

	
	/**
	 * 	Movement functions for this object's movement delegate
	 */

	// Lerp to (or very close to) a target position over time
	void MoveToTarget (Vector3 targetPosition) {
		transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime);
	}

	// Record the location of the target to the console
	void LogTarget (Vector3 targetPosition) {
		Debug.Log (""+targetPosition);
	}
	
}
