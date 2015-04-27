using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

	public int pointsToAdd;
	
	public AudioSource coinSoundEffect;
	
	//what to do when trigger is detected
	void OnTriggerEnter2D(Collider2D other){
	
		//if other game object entered the trigger...so if other has the component PlayerController
		//so...if that is NOT on the other...we ONLY want player to be able to pick up coins
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
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
