/// <summary>
/// Game Controller.
/// Description of Class - This script controls most of the major aspects of the game.
/// </summary>

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Util;
using System.Collections.Generic;
using InControl;

public class GameController : MonoBehaviour {

	//keep track of score
	public Text scoreIndicator;
	//keep track of word
	public Text wordIndicator;
	//what is the word they are guessing?
	private string word;
	//create a character array each time word is set
	public static char[] revealed;
	//connect wList to WList script
	WList wList = new  WList();
	//score keeper
	public static int score;
	//has the game been completed yet?
	private bool completed;
	//connected hangman to players tag in Unity
	private HangmanController hangman;
	//connect livesManager to LivesManager script
	private LivesManager livesManager;
	private char letter;
	//check if letter is right or wrong
	private bool isLetterRight;
	//set up a list of levels available
	private List<string> levelsList = new List<string>();
	//set up a list of chars/letters that have been chosen correctly so far
	private List<char> charsChosen = new List<char>();
	//current level game is on...set default to Level01 (01)
	public static int currentLevel = 0;
	//the string that is displayed at the top such as _ _ A_ _ B L E
	public static string displayed;

	MyCharacterActions characterActions;//preparing for new object in Start

	//.....................................................//
	
	// Use this for initialization
	void Start () {

		characterActions = new MyCharacterActions();//creates new characterAction Object from PlayerActionScript binding the touch button to select(used to continue)
		characterActions.Continue.AddDefaultBinding( InputControlType.Action3 );
	
		if(OnEnd.didEnd == true){
			Application.LoadLevel ("Preload");
		}
		//add to levels list
		levelsList.Add ("Level01");
		levelsList.Add ("Level02");
		levelsList.Add ("Level03");
		levelsList.Add ("Level04");
		levelsList.Add ("Level05");
		levelsList.Add ("Level06");
		levelsList.Add ("Level07");
		levelsList.Add ("Level08");
		levelsList.Add ("Level09");
		
		OnEnd.didEnd = false;
		
		//find all objects with the LivesManager script attached to it
		livesManager = FindObjectOfType<LivesManager>();
		//find the game object tagged Player, then get component from that named HangmanController
		hangman = GameObject.FindGameObjectWithTag("Hangman").GetComponent<HangmanController>();
		//find all objects with the WList script attached to it
		wList= FindObjectOfType<WList>();
		//assign the letter that was chosen to letter variable
		letter = ChoseLetter.charLetter;
		//reset score
		score = 0;
		//game not completed yet
		completed = false;
		//reset hangman game so body parts on staffold disappear
		hangman.reset();
		//set current level to 1
		currentLevel = 1;
		//call next function
		next();

	}
	
	//.....................................................//
	
	// Update is called once per frame
	void Update () {
	
		//move to the next word if game is done
		if(completed){
			Application.LoadLevel ("Win");
			
			//just return
			return;
		}
		//if any of these keys are pressed then...
		if (Input.GetKeyDown("space")||Input.GetButtonDown("Fire1")||Input.GetButtonDown("Fire2")||Input.GetButtonDown("Fire3")||characterActions.Continue.WasPressed){
			//call nextRound() function
			nextRound();
		}
	
		//s is equal to inputted string
		string s = "" +  letter;
		//make sure only 1 character long AND that you are getting 1st character of the string
		if (s.Length == 1 && TextUtils.isAlpha(s[0])) {
			//Check for Player Failure here...use check() function to check the first element of the inputted String
			//if guess is wrong then...
			if(!check(s.ToUpper()[0])){
				//call punish() function to punish player
				checkToPunish();
				//if Hangman died then...
				if (hangman.completed){
					//write the entire word on the screen so player knows the word that he got wrong
					wordIndicator.text = word;
					//game is done
					completed = true;
					
				}
			}
		}
		
		
		
	}
	
	public void checkToPunish(){
	
		//check to see if letter was correct or wrong
		isLetterRight = check(letter);
		//check to see if letter was correct or wrong- if wrong then punish
		if(isLetterRight == false){
			//he must be punished
			hangman.punish ();
		}
	
	}
	
	
		//.....................................................//
	
	
		//indicates whether the check in Update() was successful. Bring in the character that was inputted as a String as c
		public bool check(char c) {
			//by default we fail the check and return false
			bool ret = false;
			//not completed yet
			int complete = 0;
			//no score yet
			int score = 0;
			//loop thru 
			for(int i=0; i<revealed.Length; i++){
				
				//if c (current letter guess) is equal to the letter that is at index i in word (so i.e. 
				//if the word is CALIBRE and word[4]=B && c=B then...check returns true
				if (c == word[i]){
					//then check is true, found a match
					ret = true;
					string strC = "" + c;
					wList.removeTiles(strC);
					//if revealed word placeHolder is still set to blank then...
					if(revealed[i] == 0){
						//set that letter place to current letter guess
						revealed[i] = c;
						//and increase score by 1
						score++;
					}
				}	
				//if revealed word placeHolder is NOT set to blank then...
				if (revealed[i]  != 0){
					//number of letters guessed / completed goes up by 1
					complete++;
						
					
				}
				
			}
			
			//if score is NOT 0 then...
			if (score != 0){
				//add the points to the score
				score++;
				//when number of letters in word completed is equal to number of letters in the word then...
				if(complete == revealed.Length){
					//the game IS done
					this.completed = true;
					//Add a bonus for solving word...add words length to score...longer words get more points
					score += revealed.Length;
				}
				//display word
				updateWordIndicator();
				//display score
				updateScoreIndicator();
			}
			
			return ret;
		}
	
	
	
	public void buildHangman(){
		//string showIt = "";
		//Go thru each correct letter that has been chosen and fill in the spaces
		for(int i=0; i<ChoseLetter.charsChosen.Count; i++){
			//check for the correct letters in the word
			for(int j=0; j<word.Length; j++){
				if (ChoseLetter.charsChosen[i] == word[j]){
					//set that letter place to current letter guess
					revealed[j] = ChoseLetter.charsChosen[i];
				} 
				if ((revealed[j] == 0) || (revealed[j] == '_')){ //if the spot is empty 
					//then fill with underscore
					revealed[j] = '_';
				} 
			}
		}
		//then display the word
		displayWord();
	}
	
	//this method will display the word and call the updateWordIndicator method
	public void  displayWord() {
		string showIt = "";
		for(int j=0; j<revealed.Length; j++){
			
			showIt = showIt + revealed[j];
			//display word
			updateWordIndicator();
		}
	
	}

	
	//.....................................................//
	
	public string updateWordIndicator(){
		//set blank string
		displayed = "";
		//build up the display string...length is number of characters in the word
		for (int i = 0; i < revealed.Length; i++){
		
			//initially these characters will have the 0 
			//value which in ascii is null
			//c holds the current letter in the word
			char c = revealed[i];
			//if c is equal to 0 then this means that this letter hasn't been guessed yet so...
			if(c == 0){
				// use a blank or underscore there instead
				c = '_';
			}
			//Add a space in between each letter so doesn't shrink
			displayed += ' ';
			//display value of c (either a letter or an underscore)
			displayed += c; 
			

		}
		
		//Dispaly the word and _ on the screen
		wordIndicator.text = displayed;
		return displayed;
		
	}
				
		//.....................................................//
		
		private void updateScoreIndicator(){
			
			//if we decide to add a score this will be where we put it
			Debug.Log ("Score is " + score);
		}	
		
		
		//.....................................................//	
	
		//pass the word into this function
		private void setWord(string word) {
			//change the word to all uppercase letters
			word = word.ToUpper();
			this.word = word;
			//set a new character array with length being number of characters in the word...set to revealed var
			revealed = new char[word.Length];
			//go to updateWordIndicator function
			updateWordIndicator();
		}
		
	//.....................................................//
	
	public void nextRound() {
	
		//Get a Random Level Number
		int randomLevel = Random.Range(0,levelsList.Count);
		// load next level
		Application.LoadLevel(levelsList[randomLevel]);
		
	}
	
	//.....................................................//
			
			
		public void next() {
			//reset the hangman game
			hangman.reset();
			//Start a new round
			currentLevel = 1;
			//game is still going on
			completed = false;
			//set the word that they will be guessing by calling setWord function and the word you choose
			setWord (WList.str);
		}
			
	//.....................................................//
			
		public void reset() {
			//set all letters back to blanks
			for (int i = 0; i < revealed.Length; i++){
			
				revealed[i] = '_';

			}
			//clear the list 
			ChoseLetter.charsChosen.Clear ();
			//set some variables to blank
			word="";
			displayed = "";
			//reset score
			score = 0;
			//game not completed yet
			completed = false;
			//reset hangman game so body parts on staffold disappear
			hangman.reset();
			//set current level back to 1
			currentLevel = 1;
			//call next function
			next();
				
		}
		
	//.....................................................//
}
