/// <summary>
/// Word Indicator.
/// Description of Class - Manage the word that is displayed on the top of the screen.
/// </summary>

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WordIndicator : MonoBehaviour {

	//keep track of word at top of screen
	public Text wordIndicator;
	//create a character array each time word is set
	private char[] revealed;
	//has the game been completed yet?
	private bool completed;
	//TileManager tileManager = new TileManager();
	WList wList = new  WList();
	//GameController gameController = new  GameController();
	
	
	// Use this for initialization
	void Start () {
	
		//find all the objects that have WList attached to them
		wList= FindObjectOfType<WList>();
		//put the Hangman word on the top of the screen
		wordIndicator.text  = GameController.displayed;
		
	}
	
}
