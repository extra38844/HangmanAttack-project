/// <summary>
/// Ice Slip.
/// Description of Class - Makes object slippery for the player, like it is ice. This script makes the player go faster when they land on the ice
/// </summary>

using UnityEngine;
using System.Collections;

public class IceSlip : MonoBehaviour {
	
	//public AudioSource sandSoundEffect;
	private PlayerController player;
	
	//determine the speed player is moving
	private float speed;
	
	//what to do when trigger on ice is detected
	void OnTriggerEnter2D(Collider2D other){
		
		//we ONLY want player to slip on the ice
		if(other.GetComponent<PlayerController>() == null){
			
			//then we will return because only players can slide
			return;
			
		}else {//If it IS player then...
			
			//player slides until exit
			other.GetComponent<PlayerController>().moveSpeed = 12.0f;
		}
		
		
	}
	
	//when player exits ice
	void OnTriggerExit2D(Collider2D other){
		
		//we ONLY want player to slip on ice
		if(other.GetComponent<PlayerController>() == null){
			
			//then we will return because only players can slip
			return;
			
		}else {//If it IS player then...
			
			//player can move normal speed again
			other.GetComponent<PlayerController>().moveSpeed = 6.0f;
		}
		
		
	}
	
	// Use this for initialization
	void Start () {
		player = GetComponent<PlayerController>();	
		
	}
	
}
