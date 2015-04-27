using UnityEngine;
using System.Collections;

public class QuickSand : MonoBehaviour {
	
	//this script slows down a user when they land in the quicksand
	
	//public AudioSource sandSoundEffect;
	private PlayerController player;
	
	//determine the speed player is moving
	public float speed;
	
	//what to do when trigger in quicksand is detected
	void OnTriggerEnter2D(Collider2D other){
		
		//we ONLY want player to get stuck in the quicksand
		if(other.GetComponent<PlayerController>() == null){
			
			//then we will return because only players can get stuck
			return;
		}else {//If it IS player then...
		
			//slow down player until exit
			other.GetComponent<PlayerController>().moveSpeed = 1.0f;
		}
		
		
	}
	
	//when player exits quicksand
	void OnTriggerExit2D(Collider2D other){
		
		//we ONLY want player to get stuck in the quicksand
		if(other.GetComponent<PlayerController>() == null){
			
			//then we will return because only players can get stuck
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
	
	// Update is called once per frame
	void Update () {
		
	}
}
