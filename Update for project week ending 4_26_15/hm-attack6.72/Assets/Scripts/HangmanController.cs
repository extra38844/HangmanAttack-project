using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HangmanController : MonoBehaviour {

	//GameObject tile;
	string tileName;
	//this will be whatever spawn point we want the tiles to respawn at
	public GameObject currentSpawnPoint;
	public GameController gameController;
	public bool completed = false;
	
	//.....................................................//
	
	//Create game objects out of the body parts. I then dragged the game objects into the empty fields in Unity Inspector.
	public GameObject head;
	public GameObject torso;
	public GameObject leftarm;
	public GameObject rightarm;
	public GameObject leftleg;
	public GameObject rightleg;
	//chosen letter
	private char letter;
	//check if letter is right or wrong
	private bool isLetterRight;
	//number of turns that have been played
	private int tries;
	//parts of the body
	private GameObject[] parts;
	//returns state of our hangman - is he dead or is he still hanging in there ... haha
	public static int wrong = 0;
	
	//.....................................................//
	
	
	
	
	public void isDead (){
		//the player is Dead! and game is complete
		completed = true;
		//Load Lose Screen
		Application.LoadLevel ("Lose");
	}
	
	//.....................................................//
	
	
	// Use this for initialization
	void Start () {
		
		gameController = FindObjectOfType<GameController>();
		letter = ChoseLetter.charLetter;
		//check to see if letter was correct or wrong
		isLetterRight = gameController.check(letter);
		//populating hangman's parts array backwards
		parts = new GameObject[] {leftleg, rightleg, leftarm, rightarm, torso, head};
		//make sure game is reset at start
		reset();

	
	}
	
	//punish the hangman when answer is wrong
	public void punish(){
		
		
		
		//on first time you get a wrong
		if(wrong > 0){
		
			head.GetComponent<Renderer>().enabled = true;
			
		} 
		
		if(wrong > 1){
		
			head.GetComponent<Renderer>().enabled = true;
			torso.GetComponent<Renderer>().enabled = true;
			
		} 
		
		if(wrong > 2){
		
			head.GetComponent<Renderer>().enabled = true;
			torso.GetComponent<Renderer>().enabled = true;
			leftarm.GetComponent<Renderer>().enabled = true;
			
		} 
		
		if(wrong > 3){
		
			head.GetComponent<Renderer>().enabled = true;
			torso.GetComponent<Renderer>().enabled = true;
			leftarm.GetComponent<Renderer>().enabled = true;
			rightarm.GetComponent<Renderer>().enabled = true;
			
		}
		
		if(wrong > 4){
		
			head.GetComponent<Renderer>().enabled = true;
			torso.GetComponent<Renderer>().enabled = true;
			leftarm.GetComponent<Renderer>().enabled = true;
			rightarm.GetComponent<Renderer>().enabled = true;
			leftleg.GetComponent<Renderer>().enabled = true;
			
		}
		
		if(wrong > 5){
			
			head.GetComponent<Renderer>().enabled = true;
			torso.GetComponent<Renderer>().enabled = true;
			leftarm.GetComponent<Renderer>().enabled = true;
			rightarm.GetComponent<Renderer>().enabled = true;
			leftleg.GetComponent<Renderer>().enabled = true;
			rightleg.GetComponent<Renderer>().enabled = true;
			
		}
		
		if (wrong >= 6){
			head.GetComponent<Renderer>().enabled = true;
			torso.GetComponent<Renderer>().enabled = true;
			leftarm.GetComponent<Renderer>().enabled = true;
			rightarm.GetComponent<Renderer>().enabled = true;
			leftleg.GetComponent<Renderer>().enabled = true;
			rightleg.GetComponent<Renderer>().enabled = true;
			isDead();
			Application.LoadLevel ("Lose");
		}
		
		//increment the number of wrongs you have
		
		Debug.Log ("number of wrongs " + wrong);
		
	}
	
	//.....................................................//
	
	//reset the game for new turn
	public void reset(){
		//if body parts is null (and it should be null initially) then...
		if(parts == null){
			//inhibit that call
			return;
		}
		//for each body part...
		///foreach(GameObject g in parts){
			//inactivate each body part that is active to make them invisible
			//g.GetComponent<Renderer>().enabled = false;
		//}
	}
	
	//.....................................................//
	
	// Update is called once per frame
	void Update () {
	
		
	
	}
}
