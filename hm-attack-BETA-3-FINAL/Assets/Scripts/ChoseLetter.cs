/// <summary>
/// Chose Letter.
/// Description of Class - This controls the page where the player reviews what letter they chose and sees the hangman and scaffold.
/// </summary>

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
	//letter chosen as a char
	public static char charLetter;
	//letter chosen as a string
	public static string strCharLetter;
	//this will be whatever spawn point we want the tiles to respawn at
	public GameObject currentSpawnPoint;
	//Create an object of GameController.cs script and make instance variable gameController
	public GameController gameController;
	//Create an object of HangmanControlle.cs script and make instance variable hangmanController
	public HangmanController hangmanController;
	//Make an Array List of the letters that have been chosen correctly
	public static List<char> charsChosen = new List<char>();
	//how many letters has the player gotten right?
	public static int numRight = 0;
	
	
	//.....................................................//
	
	
	// Use this for initialization
	void Start () {
		//did the game end already and this is a restart game? 
		OnEnd.didEnd = false;
		//Find all objects that have the WList script attached to it
		wList= FindObjectOfType<WList>();
		//Find all objects that have the GameController script attached to it
		gameController = FindObjectOfType<GameController>();
		//Find all objects that have the HangmanController script attached to it
		hangmanController = FindObjectOfType<HangmanController>();
		//what tile was chosen?
		letterIndicator.text = TilePickup.strChosenTile;
		//convert this string to char
		charLetter = TilePickup.strChosenTile[0];
		//we need a string version as well
		strCharLetter = "" + charLetter;
		
		//if letter is correct then...
		if(gameController.check(charLetter) == true){
			//number of letters right increase by 1
			numRight++;
			//if the number of answers right >= to the word length then you win
			if(numRight >= OnStart.wordLengthKeep){
				//go to win screen
				Application.LoadLevel ("Win");
			}
			//add it to the list of correct letters chosen
			charsChosen.Add(charLetter);
			// Get distinct elements and convert into a list again.
			charsChosen = charsChosen.Distinct().ToList();
			//if there is a dupe letter showing up - make sure it is gone
			for(int i=0; i<charsChosen.Count; i++){
				string strCharsChosen = "" + charsChosen[i];
				wList.removeTiles (strCharsChosen);
			} 
			////////////////////////
			//if we decide to add a score, then this will increment it
			GameController.score++;
			//go to punish() to show the hangman on the scaffold - even though nothing else is being added to it
			hangmanController.punish();
			//gameController.check(charLetter);
			gameController.buildHangman();
			
		} 
		else{
		//if player guesses wrong then increment wrong variable and call the following methods
		HangmanController.wrong++;
		hangmanController.punish();
		gameController.buildHangman();
		}
		//increase level by 1 - just in case we decide to call levels in order
		GameController.currentLevel++;
		
	}

}
