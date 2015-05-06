/// <summary>
/// On End.
/// Description of Class - on end of game, including both losing and winning, reset variables and arrays to defaults.
/// </summary>

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class OnEnd: MonoBehaviour {
	//Add RandomWord object
	public RandomWord randomWord;
	private static string lcStr = RandomWord.getWordHolder();
	public static char[] wordAsChars;
	public static string str = lcStr.ToUpper();
	public static int wordLength;
	public static int wordLengthKeep;
	//Add GameController
	public GameController gameController;
	//Add HangmanController
	public HangmanController hangmanController;
	//Add WordIndicator
	public WordIndicator wordIndicator;
	//Add ChoseLetter
	public ChoseLetter choseLetter;
	//Add TileManager
	public TileManager tileManager;
	public WList wList;
	public static int restartCount= 0;
	public static bool didEnd;
	
	void Start(){
		didEnd = true;
		//convert word string into an array of separate characters
		restartCount= 0;
		wordAsChars = str.ToCharArray(0, str.Length);
		wordLength = wordAsChars.Length;
		//wordLengthKeep = wordAsChars.Length;
		//Count of how many unique letters are in the word
		wordLengthKeep = str.Distinct().Count();
		Debug.Log (wordLengthKeep);
		makeTextDoc();
		//reset lives back to original value
		LivesManager.lives = 4;
		//find TileManager object and set it to type tileManager
		tileManager = FindObjectOfType<TileManager>();
		//find GameController object and set it to type gameController
		gameController = FindObjectOfType<GameController>();
		//find WList object and set it to type wList
		wList = FindObjectOfType<WList>();
		//reset values to default
		gameController.reset();
		//find HangmanController object and set it to type hangmanController
		gameController = FindObjectOfType<GameController>();
		
		//find WordIndicator object and set it to type wordIndicator
		wordIndicator = FindObjectOfType<WordIndicator>();
		//wordIndicator.wordIndicator.text="";
		//find RandomWord object and set it to type randomWord
		randomWord = FindObjectOfType<RandomWord>();
		//find ChoseLetter object and set it to type choseLetter
		choseLetter = FindObjectOfType<ChoseLetter>();
		//hangmanController.reset();
		
		HangmanController.wrong=0;
		//reset charschosen
		ChoseLetter.charsChosen.Clear();
		ChoseLetter.charLetter = '\0';
		ChoseLetter.strCharLetter = "";
		ChoseLetter.numRight = 0;
		//choseLetter.letterIndicator.text = TilePickup.strChosenTile;
		//ChoseLetter.charLetter = TilePickup.strChosenTile[0];
		ChoseLetter.strCharLetter = "" + ChoseLetter.charLetter;
		//reset tileManager
		TilePickup.strChosenTile = "";
		tileManager.reset();
		
		WList.lettersLeft.Clear ();
		WList.listStr = "";
		
		WList.lcStr = "";
		//WList.str="";
		Debug.Log ("RestartCount " + restartCount);
		
		for(int i=0; i<GameController.revealed.Length; i++){
			
			GameController.revealed[i] = '_';
		}
		for(int i=0; i<WList.wordAsLetters.Length; i++){
			
			WList.wordAsLetters[i] = '\0';
		}
		//Application.LoadLevel ("Preload");
		gameController.reset ();
		
		
	}
	
	public void makeTextDoc(){
		string str2 = "";
		for(int i=0; i<wordAsChars.Length; i++){
			
			str2 = str2 + wordAsChars[i];
		}
		
		RandomWord.setLettersHolder(str2);
		
	}
}
