/// <summary>
/// Check Point.
/// Description of Class - Keeps track of where the player is in each level so if player passes a certain point he can start further on
/// </summary>

using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	//Create an object of LevelManager.cs script and make instance variable levelManager
	LevelManager levelManager=new LevelManager();
	
	// Use this for initialization
	void Start () {
		
		//searches for any objects in scene that have a LevelManager script attached to it and now that levelManager instance will be in the scene
		levelManager = FindObjectOfType<LevelManager>();
	}
	
	//This is when a player enters a trigger zone (aka spikes in our game)
	void OnTriggerEnter2D(Collider2D other) {
		
		//if the object colliding with trigger is the player then...
		if(other.name == "Player"){
			
			//takes the levelManager's current checkpoint and changes it to this current object that this script is attached to
			levelManager.currentCheckpoint = gameObject;

		}
		
	}
}
