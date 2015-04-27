using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {
	
	//this will be whatever spawn point we want the tiles to respawn at
	public GameObject currentSpawnPoint;
	//we also want to know what the tile is by accessing the TileManager
	private TileManager tiles_A;
	private TileManager tiles_B;
	//Create an object of TileManager and make instance variable tileManager
	public TileManager tileManager;
	//has OnTriggerEnter2D been called yet?
	private bool isTriggered = false;
	
	// Use this for initialization
	void Start () {
		
		
		//searches for any objects in scene that have a TileManager script attached to it and now that tileManager instance will be in the scene
		tileManager = FindObjectOfType<TileManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//When a player collides with this trigger zone we spawn the letter tiles
	void OnTriggerEnter2D(Collider2D other) {
		
		//only want player to worry about spikes...enemies can hit them and be fine - also only want this to be called once
		if((other.name == "Player") && (isTriggered == false)){
			
			//takes the tileManager's current spawnpoint and changes it to this current object that this script is attached to
			//tiles_A.currentSpawnPoint = gameObject;
			//tiles_B.currentSpawnPoint = gameObject;
			//Spawn tile
			tileManager.spawnTiles();
			//Debug out to Log
			Debug.Log ("Activated SpawnPoint " + transform.position);
			//yes, OnTriggerEnter2D HAS been called 
			isTriggered = true;
			
		}
		
		
	}
}