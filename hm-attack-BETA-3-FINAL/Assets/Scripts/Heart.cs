/// <summary>
/// Heart.
/// Description of Class - Controlls the heart collectible so that you get an extra life.
/// </summary>

using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour {
	
	//add a sound effect
	public AudioSource coinSoundEffect;
	
	//what to do when trigger is detected
	void OnTriggerEnter2D(Collider2D other){
		
		//we ONLY want player to be able to pick up heart
		if(other.GetComponent<PlayerController>() == null){
			
			//then we will return because only players can pick up hearts
			return;
		}
		//Destroy heart as soon as it is picked up
		Destroy (gameObject);
		//Add 1 Life to Player
		LivesManager.lives++;
		//Play sound effect
		coinSoundEffect.Play ();
		
	}

}
