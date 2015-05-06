/// <summary>
/// Before Start.
/// Description of Class - Waits for 3 seconds before going to title menu. This gives scrip enough time to contact Random Word API
/// </summary>

using UnityEngine;
using System.Collections;

public class BeforeStart : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
		StartCoroutine(Wait());
	}
	
	IEnumerator Wait() {
		//wait for 3 seconds
		yield return new WaitForSeconds(3);
		//Load next scene  when 3 seconds is over
		Application.LoadLevel("Title_Menu");
	}
	
}