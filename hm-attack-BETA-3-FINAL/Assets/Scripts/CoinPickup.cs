/// <summary>
/// Coin Pickup.
/// Description of Class - We don't have coins, but if we decide to add it this controls the collectible coins and their behavior.
/// </summary>

using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

	//how many points to add for each coin picked up.
	public int pointsToAdd;
	//sound that happens when you pick up coin
	public AudioSource coinSoundEffect;
	//what to do when trigger is detected
	void OnTriggerEnter2D(Collider2D other){
	
		//We ONLY want player to be able to pick up coins
		if(other.GetComponent<PlayerController>() == null){
		
			//then we will return because only players can pick up coins
			return;
		}
		
		//Access AddPointsmethod from ScoreManager script
		ScoreManager.AddPoints (pointsToAdd);
		//Play sound effect
		coinSoundEffect.Play ();
		//Destroy coin as soon as it is picked up
		Destroy (gameObject);
	}
	

}
