using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthManager : MonoBehaviour {
	
	//will be reset when player dies
	public int maxPlayerHealth;
	//will be modified the whole time
	public static int playerHealth;
	//for the text of the health
	Text text;
	//add the level manager in here for when we respawn the player
	private LevelManager levelManager;
	//is player dead?
	public bool isDead;
	
	// Use this for initialization
	void Start () {
	
		//since text is attached to the health component, use this. Find the text area that we already have on the object.
		text = GetComponent<Text>();
		//set player's health to the max allowed
		playerHealth = maxPlayerHealth;
		//find out levelManager in the scene
		levelManager = FindObjectOfType<LevelManager>();
		//player is NOT dead
		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		//check to see if player's health is less than 0 then AND Alive then...
		if(playerHealth <= 0 && !isDead){
			//set player's health to 0 to keep from going negative
			playerHealth = 0;
			//then player dies
			isDead = true;
			//then respawn player
			levelManager.reSpawnPlayer();
			
			
		}
		
		//look for text component of that text obect and update on screen health of player
		text.text = "" + playerHealth;//the "" are just to make sure c# knows is String
	}
	
	// For When Player Gets Hurt
	public static void HurtPlayer(int damageToGive){
		//reduce the damage from the player's health
		playerHealth -= damageToGive;
	}
	
	//Resetting the Player's Health Back to Full
	public void FullHealth(){
		//set player's health to the max allowed
		playerHealth = maxPlayerHealth;
	}
}
