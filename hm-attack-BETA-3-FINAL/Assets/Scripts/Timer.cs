/// <summary>
/// Timer.
/// Description of Class - Script to manage the countdown timer.
/// </summary>

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	
	//start time of timer
	public float startTime;
	//time left on timer
	public float timeLeft;
	//for the text of the health
	Text text;
	//add the level manager in here for when we respawn the player
	private LevelManager levelManager;
	
	// Use this for initialization
	void Start () {
		//since text is attached to the timer component, use this. Find the text area that we already have on the object.
		text = GetComponent<Text>();
		//find out levelManager in the scene
		levelManager = FindObjectOfType<LevelManager>();
		//reset the timer back to starting point
		resetTimer();
	}
	
	// Update is called once per frame
	void Update () {
		
		//set time left to current time
		timeLeft -= Time.deltaTime;
		
		//figure out minutes, seconds, fraction
		float minutes = timeLeft / 60;
		float seconds = timeLeft % 60;
		float fraction = (timeLeft * 100) % 100;
		
		//show the timer countdown
		if (timeLeft>0){
			//time to print to the screen
			text.text = string.Format ("{0:00}", seconds);
		} else if(timeLeft<=0){ //if timer hits 0 or below
			//then time has elapsed and turn is over
			//Call LevelManager's method reSpawnPlayer() to respawn player
			levelManager.reSpawnPlayer();
			//reset timer to start value
			resetTimer();
		}
		
	}
	
	//reset timer
	public void resetTimer(){
		
		//reset timeLeft to the startTime
		timeLeft = startTime;
		
	}
	
}