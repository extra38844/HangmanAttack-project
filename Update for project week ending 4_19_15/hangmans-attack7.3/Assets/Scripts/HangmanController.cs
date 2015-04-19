using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HangmanController : MonoBehaviour {

	//GameObject tile;
	string tileName;
	//this will be whatever spawn point we want the tiles to respawn at
	public GameObject currentSpawnPoint;
	public GameController gameController;
	
	
	//.....................................................//
	
	//Create game objects out of the body parts. I then dragged the game objects into the empty fields in Unity Inspector.
	public GameObject head;
	public GameObject torso;
	public GameObject arms;
	public GameObject legs;
	//chosen letter
	private char letter;
	//check if letter is right or wrong
	private bool isLetterRight;
	//number of turns that have been played
	private int tries;
	//parts of the body
	private GameObject[] parts;
	//returns state of our hangman - is he dead or is he still hanging in there ... haha
	
	//.....................................................//
	
	public bool isDead{
		//if tries left is less than 0 then he IS DEAD
		get { 
			return tries < 0;
		}
	}
	
	//.....................................................//
	
	
	// Use this for initialization
	void Start () {
		gameController = FindObjectOfType<GameController>();
		letter = ChoseLetter.charLetter;
		//check to see if letter was correct or wrong
		isLetterRight = gameController.check(letter);
		//populating hangman's parts array backwards
		parts = new GameObject[] {legs, arms, torso, head};
		//make sure game is reset at start
		reset();

	
	}
	
	//punish the hangman when answer is wrong
	public void punish(){
		//if turns is great than 0 then...
		if(tries >= 0){
			//one by one...make body parts visible again
			parts[tries--].SetActive(true);
		}
		
	}
	
	//.....................................................//
	
	//reset the game for new turn
	public void reset(){
		//if body parts is null (and it should be null initially) then...
		if(parts == null){
			//inhibit that call
			return;
		}
		//number of tries is the number of body parts - 1
		tries = parts.Length - 1;
		//for each body part...
		foreach(GameObject g in parts){
			//inactivate each body part that is active to make them invisible
			g.SetActive(false);
		}
		
	}
	
	//.....................................................//
	
	// Update is called once per frame
	void Update () {
	
		
	
	}
}
