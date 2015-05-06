/// <summary>
/// Lives Manager.
/// Description of Class - Manage Player's Lives.
/// </summary>

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesManager : MonoBehaviour {

	//set default number of lives
	public static int lives = 4;
	//Create a UI text object
	Text text;


	// Use this for initialization
	void Start () {
	
		//since text is attached to the lives component, use this. Find the text area that we already have on the object.
		text = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
		//access text on the object ... just putting the "" in there to make sure it knows it is a String
		text.text = "" + lives;
	}
	
	//Add a variable that anyone can access to subtract lvies
	public static void SubtractLives(){
		
		//subtract lives
		lives--;
		
	}
	
	//May or may not use this in the future...give all the lives back to the player
	public static void Reset() {
		
		//set lives back to default
		lives = 4;
		
	}
}
