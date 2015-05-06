/// <summary>
/// Clock.
/// Description of Class - Controls the collectible clock that allows the player to gain time from the countdown clock. 
/// </summary>

using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {

	//sounds that happens when you grab the clock
	public AudioSource coinSoundEffect;
	//add the timer in here 
	private Timer timer;
	
	// Use this for initialization
	void Start () {
	
		//find out where timer is in the scene
		timer = FindObjectOfType<Timer>();
	}
	
	//what to do when trigger is detected
	void OnTriggerEnter2D(Collider2D other){
		
		//we ONLY want player to be able to pick up clock
		if(other.GetComponent<PlayerController>() == null){
			
			//then we will return because only players can pick up clock
			return;
		}
		//Destroy clock as soon as it is picked up
		Destroy (gameObject);
		//Add 15 seconds to the clock
		timer.timeLeft = timer.timeLeft + 15.0f;
		//Play sound effect
		coinSoundEffect.Play ();
		
	}
	
	
}
