using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TilePickup : MonoBehaviour {
	
	//choose how many points to add for each time a correct tile is picked up
	public int pointsToAdd;
	//sound effect for picking up a tile
	//public AudioSource tileSoundEffect;
	//make a tilemanager object
	WList wList = new  WList();
	//NEW 4-16...string variable for chosen tile naem
	public static string strChosenTile;
	//NEW 4-16...instance ID
	int strChosenTileID;
	//NEW 4-16..name of level we are going to load
	public string levelToLoad = "TileChosen";
	
	void Start(){
	
		wList= FindObjectOfType<WList>();
	}

	
	// Update is called once per frame
	void Update () {

	}
	
	//what to do when trigger is detected (when picking up tile)
	void OnTriggerEnter2D(Collider2D other){
		
		//we ONLY want player to be able to pick up tiles - so if not a player, can't pick up tile
		if(other.GetComponent<PlayerController>() == null){
			
			//then we will return because only players can pick up tile
			return;
		}

		
		//Access AddPointsmethod from ScoreManager script
		ScoreManager.AddPoints (pointsToAdd);
		//NEW 4-16...save chosen tile to a variable
		strChosenTile = gameObject.name;
		//NEW 4-16...take (Clone) out of name
		strChosenTile = strChosenTile.Replace("(Clone)", ""); 
		//NEW 4-16...instance ID just in case we need it
		strChosenTileID = gameObject.GetInstanceID();
		
		wList.removeTiles (strChosenTile);
		OnStart.wordLength--; 
		//Destroy (gameObject);
		//then load the level that this door leads to
		
		Application.LoadLevel (levelToLoad);
		
	}
}
