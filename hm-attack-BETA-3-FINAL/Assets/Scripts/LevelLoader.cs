/// <summary>
/// Level Loader.
/// Description of Class - Load levels up.
/// </summary>

using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	//is player in a TriggerZone
	private bool playerInZone;
	//name of level we are going to load
	public string levelToLoad;
	// Use this for initialization
	void Start () {
		//when we start this the player will not be in a trigger zone
		playerInZone = false;
	}
	
	// Update is called once per frame
	void Update () {
		//press up button to get into the door AND the player IS IN the trigger zone then...
		if(Input.GetKey(KeyCode.UpArrow) && playerInZone){
				//then load the level that this door leads to
				Application.LoadLevel (levelToLoad);
		}
	}
	
	//check whether the player is in a trigger zone
	void OnTriggerEnter2D(Collider2D other){
		//if the thing that entered the trigger zone is player, then...
		if(other.name == "Player"){
			//then we know that player IS in the trigger zone
			playerInZone = true;
		}
	}
	
	//check to see if player has left the trigger zone
	void OnTriggerExit2D(Collider2D other){
		//if the thing that exited the trigger zone is player, then...
		if(other.name == "Player"){
			//then we know that player IS NOT in the trigger zone
			playerInZone = false;
		}
	}
}
