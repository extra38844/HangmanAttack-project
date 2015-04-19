using UnityEngine;
using System.Collections;

public class HurtPlayerOnContact : MonoBehaviour {

	public int damageToGive;
	
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//This is when a player enters a trigger zone (aka spikes in our game)
	void OnTriggerEnter2D(Collider2D other) {
		
		//only want player to worry about spikes...enemies can hit them and be fine
		if(other.name == "Player"){
			
			//call Healthmanager's method HurtPlayer() to give damage to player
			HealthManager.HurtPlayer(damageToGive);
			//play audiosource attached to the game object that this script is on
			other.GetComponent<AudioSource>().Play();
			
			//create a variable to determine which object is the player
			var player = other.GetComponent<PlayerController>();
			//start the knockBackCount at the length of time we set in public variables
			player.knockBackCount = player.knockBackLength;
			//should we knoc the player to the left or right
			//if the x position of the other (what the enemy is colliding with) is less than enemy's position then...
			if(other.transform.position.x < transform.position.x){
				//this means the other(what enemy is colliding with) is on the LEFT and player WILL be knocked from RIGHT
				player.knockFromRight = true;
			} else { //other is on the RIGHT and player will be knocked from LEFT
				player.knockFromRight = false;
			}
		}
		
	}
}
