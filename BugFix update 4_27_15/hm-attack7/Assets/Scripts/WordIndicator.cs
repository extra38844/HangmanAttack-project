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
		wList= FindObjectOfType<WList>();
		//gameController= FindObjectOfType<GameController>();
		//put the Hangman word on the top of the screen
		//wordIndicator.text = WList.str;
		wordIndicator.text  = GameController.displayed;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
