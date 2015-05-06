/// <summary>
/// Quit Game.
/// Description of Class - if user presses the Escape key the game will quit out of the application.
/// </summary>

using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {

	
	void Update() {
	
		//if presses esacpe....
		if (Input.GetKey("escape"))
			//Quit the application
			Application.Quit();
		
	}
}
