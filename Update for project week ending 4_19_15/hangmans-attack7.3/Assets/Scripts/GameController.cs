using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Util;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	//keep track of score
	public Text scoreIndicator;
	//keep track of word
	public Text wordIndicator;
	//keep track of number of letters
	//public Text lettersIndicator;
	//what is the word they are guessing?
	private string word;
	//create a character array each time word is set
	private char[] revealed;
	WList wList = new  WList();
	//score keeper
	public static int score;
	//has the game been completed yet?
	private bool completed;
	//connected hangman to players tag in Unity
	private HangmanController hangman;
	private char letter;
	//check if letter is right or wrong
	private bool isLetterRight;
	//set up an array of levels
	public string[] levels = new string[] {"Title_Menu", "Level01", "Level02", "Level03", "Level04", "Level05", "Level06", "Level07", "Level08", "Level09", "Level10", "Level11", "Level12"};
	private List<char> charsChosen = new List<char>();
	// load scene 4 example
	//Application.LoadLevel(scenes[3]);
	//current level game is on...set default to Level01 (01)
	public static int currentLevel = 0;


	//.....................................................//
	
	// Use this for initialization
	void Start () {
		//find the game object tagged Player, then get component from that named HangmanController
		hangman = GameObject.FindGameObjectWithTag("Hangman").GetComponent<HangmanController>();
		wList= FindObjectOfType<WList>();
		//call reset function
		letter = ChoseLetter.charLetter;
		
		for(int i=0; i<ChoseLetter.charsChosen.Count; i++){
		
			
		}
		reset();
	}
	
	//.....................................................//
	
	// Update is called once per frame
	void Update () {
	
		//move to the next word if game is done
		if(completed){
			//make a temp input string
			string tmp = "" +  letter;
			//if any key is pressed...
			if(Input.anyKeyDown){
				//call next() function
				next();
				//I added reset in here to reset the score after guess whole word correctly
				reset ();
			}
			//just return
			return;
		}
		
		if(Input.anyKeyDown){
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
				hangman.punish();
				//if Hangman died then...
				if (hangman.isDead){
					//write the entire word on the screen so player knows the word that he got wrong
					wordIndicator.text = word;
					//game is done
					completed = true;
					
				}
			}
		}
		
		
		//check to see if letter was correct or wrong
		//isLetterRight = check(letter);
		//check to see if letter was correct or wrong- if wrong then punish
		//if(isLetterRight == false){
		
	
	}
	
	
	
	
	
		//.....................................................//
		//.....................................................//
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
					Debug.Log ("ChoseLetter.charsChosen[i] == word[j] " + ChoseLetter.charsChosen[i] + " word [j] " + word[j]);
					revealed[j] = ChoseLetter.charsChosen[i];
					Debug.Log ("revealed[j] = ChoseLetter.charsChosen[i] " + revealed[j] + " " + ChoseLetter.charsChosen[i]);
				} 
				if ((revealed[j] == 0) || (revealed[j] == '_')){ //if the spot is empty 
					//then fill with underscore
					revealed[j] = '_';
				} 
				//else { //else just return
					//return;
				//}
			}
		}
		displayWord();
	}
	
	public void  displayWord() {
		string showIt = "";
		for(int j=0; j<revealed.Length; j++){
			
			showIt = showIt + revealed[j];
			//display word
			updateWordIndicator();
			Debug.Log (showIt);
		}
	
	}
	
	
	//.....................................................//
	//.....................................................//
	//.....................................................//
	

	
	
	//.....................................................//
	
	private void updateWordIndicator(){
		//set blank string
		string displayed = "";
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
			Debug.Log ("displayed is :  " + displayed);

		}
		
		//Dispaly the word and _ on the screen
		wordIndicator.text = displayed;
		
	}
				
		//.....................................................//
		
		private void updateScoreIndicator(){
			
			//update score
			//scoreIndicator.text = "Score: " + score;
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
			//the text to show on screen in lettersIndictor is length of the word.
			//lettersIndicator.text = "Letters: " + word.Length;
			//go to updateWordIndicator function
			updateWordIndicator();
		}
		
	//.....................................................//
	
	public void nextRound() {
		// load next level
		Application.LoadLevel(levels[currentLevel]);
		
	}
	
	//.....................................................//
			
			
		public void next() {
			//reset the hangman game
			hangman.reset();
			//Start a new round
			currentLevel = 1;
			completed = false;
			//set the word that they will be guessing by calling setWord function and the word you choose
			//pass a 0 in because there is no maximum length
			//setWord(Dictionary.instance.next(0));
			setWord (wList.str);
		
		}
			
	//.....................................................//
			
		public void reset() {
			//reset score
			score = 0;
			//game not completed yet
			completed = false;
			//reset hangman game so body parts on staffold disappear
			hangman.reset();
			currentLevel = 1;
			//call next function
			next();
				
		}
		
	//.....................................................//
}
