using UnityEngine;
using System.Collections;

public class BeforeStartDelay : MonoBehaviour {
	

	
	// Use this for initialization
	void Start () {
		StartCoroutine(Wait());
	}
	IEnumerator Wait() {
		//wait for 5 seconds
		yield return new WaitForSeconds(3);
		//Load next scene  when 5 seconds is over
			Application.LoadLevel("Title_Menu");
	}
	
}
