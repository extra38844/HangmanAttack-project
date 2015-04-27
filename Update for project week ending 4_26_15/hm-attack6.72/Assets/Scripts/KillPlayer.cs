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
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//This is when a player enters a trigger zone (aka spikes in our game)
	void OnTriggerEnter2D(Collider2D other) {
		
		//only want player to worry about spikes...enemies can hit them and be fine
		if(other.name == "Player"){
		
			//Call LevelManager's method reSpawnPlayer() to respawn player
			levelManager.reSpawnPlayer();
		}
	
	}
}
