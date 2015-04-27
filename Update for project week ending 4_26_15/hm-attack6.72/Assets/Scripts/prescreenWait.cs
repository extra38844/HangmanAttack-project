using UnityEngine;
using System.Collections;

public class prescreenWait : MonoBehaviour {
	

	
	// Use this for initialization
	void Start () {
		StartCoroutine(Wait());
	}
	IEnumerator Wait() {
		//wait for 5 seconds
		yield return new WaitForSeconds(4);
		//Load next scene  when 5 seconds is over
			Application.LoadLevel("BeforeStart");
	}
	
}
