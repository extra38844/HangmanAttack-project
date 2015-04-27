using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static int score;
	Text text;
	
	void Start(){
	
		//since text is attached to the score component, use this. Find the text area that we already have on the object.
		text = GetComponent<Text>();
		//set default score
		score = 0;
	}
	
	
	void Update(){
	
		//if score is less than 0, then...
		if(score < 0){
		
			//set score to 0
			score = 0;
		
		}
	
		//access text on the object ... just putting the "" in there to make sure it knows it is a String
		text.text = "" + score;
	}
	
	//Add a variable that anyone can access to add points to our score
	public static void AddPoints(int pointsToAdd){
	
		//add pointsToAdd to the current score
		score += pointsToAdd;
	
	}
	
	//May or may not use this in the future...it is to take all the points away from a player
	public static void Reset() {
	
		//set score to 0
		score = 0;
	
	}
}
