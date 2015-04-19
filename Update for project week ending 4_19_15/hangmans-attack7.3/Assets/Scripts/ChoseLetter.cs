using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ChoseLetter : MonoBehaviour {
	
	//keep track of letter that was chosen
	public Text letterIndicator;
	//make a tilemanager object
	WList wList = new  WList();
	//GameObject tile;
	string tileName;
	public static char charLetter;
	public static string strCharLetter;
	//this will be whatever spawn point we want the tiles to respawn at
	public GameObject currentSpawnPoint;
	public GameController gameController;
	//Make an Array List of the letters that have been chosen correctly
	public static List<char> charsChosen = new List<char>();

	
	//.....................................................//
	
	
	// Use this for initialization
	void Start () {
		wList= FindObjectOfType<WList>();
		gameController = FindObjectOfType<GameController>();
		//make sure game is reset at start
		//reset();
		//put the Hangman word on the top of the screen
		letterIndicator.text = TilePickup.strChosenTile;
		//convert this string to char
		charLetter = TilePickup.strChosenTile[0];
		strCharLetter = "" + charLetter;
		
		Debug.Log(charLetter);
		
		//if letter is correct then...
		if(gameController.check(charLetter) == true){
			//add it to the list of correct letters chosen
			charsChosen.Add(charLetter);
			//wList.removeTiles (strCharLetter);
			//OnStart.wordLength--; 
			//check for duplicates and make a new list
			// Get distinct elements and convert into a list again.
			charsChosen = charsChosen.Distinct().ToList();
			for(int i=0; i<charsChosen.Count; i++){
				//Debug.Log ("charsChosen: " + charsChosen[i]);
			}
			GameController.score++;
			//gameController.check(charLetter);
			gameController.buildHangman();
		}
		//increase level by 1
		GameController.currentLevel++;
		//Find a tile with this letter
		//tile = GameObject.Find(TilePickup.strChosenTile);
		
		//Debug.Log (tile);
		//Debug.Log (tile.name);
		
		//Instantiate the correct letter Tile
		//Instantiate (tile, currentSpawnPoint.transform.position, currentSpawnPoint.transform.rotation);
		
	}
	

	// Update is called once per frame
	void Update () {
		
		
		
	}
}
