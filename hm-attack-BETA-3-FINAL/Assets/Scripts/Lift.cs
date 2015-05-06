/// <summary>
/// Lift.
/// Description of Class - This script makes a platform go up and down automatically like an elevator.
/// </summary>

using UnityEngine;
using System.Collections;

public class Lift : MonoBehaviour {

	//public Vector3 pointB;
	
	IEnumerator Start () {
		//first point position
		Vector3 pointA = transform.position;
		//second point position
		Vector3 pointB = new Vector3(transform.position.x, transform.localScale.y+3 ,0f);
		while (true) {
			yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
			yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
		}
	}
	
	IEnumerator MoveObject (Transform thisTransform, Vector3 startPos, Vector3 endPos, float time) {
		float i = 0.0f;
		float rate = 4.0f / time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}
}
