/// <summary>
/// Kill Player.
/// Description of Class - Pauses for a bit of time to give time for the IP Generator to Generate an IP address.
/// </summary>

using UnityEngine;
using System.Collections;

public class prescreenWait : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		StartCoroutine(Wait());
	}
	IEnumerator Wait() {
		//wait for 5 seconds
		yield return new WaitForSeconds(5);
		//Load next scene  when 5 seconds is over
			Application.LoadLevel("BeforeStart");
	}
	
}
