/// <summary>
/// Preload.
/// Description of Class - go to BeforeStart page if player presses space bar..
/// </summary>

using UnityEngine;
using System.Collections;

public class Preload : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//if presses spacebar then...
		if(Input.GetKeyDown(KeyCode.Space)){
			
			//Load up BeforeStart page
			Application.LoadLevel ("BeforeStart");
			
		}
	}
}
