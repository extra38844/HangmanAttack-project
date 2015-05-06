/// <summary>
/// Kill Player.
/// Description of Class - objects that have KillPlayer attached to it will kill player on contact.
/// </summary>

using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

	//Create an object of LevelManager.cs script and make instance variable levelManager
	public LevelManager levelManager;

	// Use this for initialization
	void Start () {
	
		//searches for any objects in scene that have a LevelManager script attached to it and now that levelManager instance will be in the scene
		levelManager = FindObjectOfType<LevelManager>();
	}

	
	//This is when a player enters a trigger zone 
	void OnTriggerEnter2D(Collider2D other) {
		
		//only want player to get killed
		if(other.name == "Player"){
		
			//Call LevelManager's method reSpawnPlayer() to respawn player
			levelManager.reSpawnPlayer();
		}
	
	}
}
