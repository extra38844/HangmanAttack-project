/// <summary>
/// Tile Manager.
/// Description of Class - Manages tile related tasks.
/// </summary>

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class TileManager : MonoBehaviour {
	
	//this will be whatever spawn point we want the tiles to respawn at
	public GameObject currentSpawnPoint;
	public GameObject currentSpawnPoint2;
	//keep track of word at top of screen
	public Text wordIndicator;
	//we also want to know what the tile is by accessing the TileManager
	public GameObject A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z;
	//Object[] with all the tiles
	private GameObject[] tilesAll;
	//Object[] with only word tiles
	private GameObject[] tilesWord;
	WList wList = new  WList();
	//the word
	string strList =RandomWord.getLettersHolder();
	char[] wordAsChars;
	char chLetter;
	//Create an ArrayList of GameObjects
	public List<char> tilesLeft = new List<char>();
	//Create a list of characters that are in the word
	public List<char> wordAsCharsList = new List<char>();
	//create a tilesLeft list for GameObjects
	public static List<GameObject> objTilesLeft = new List<GameObject>();
	//create tiles left from the word as GameObjects
	public List<GameObject> objWordLeft = new List<GameObject>();
	//tiles from the list that are left
	public List<GameObject> objTilesFromList = new List<GameObject>();
	//wrong tile as a string
	public string strWrongTile;
	//wrong tile as an object
	public GameObject objWrongTile;
	//right tile as a string
	public string strRightTile;
	//right tile as an object
	public GameObject objRightTile;
	//Players chosen tile (the one player picks up)
	public char chosenLetter;
	
	// Use this for initialization
	void Start () {
	
		//find all objects that have WList script attached to it
		wList = FindObjectOfType<WList>();
		//populating letter tiles into the tiles array		
		tilesLeft.Add('A');
		tilesLeft.Add('B');
		tilesLeft.Add('C');
		tilesLeft.Add('D');
		tilesLeft.Add('E');
		tilesLeft.Add('F');
		tilesLeft.Add('G');
		tilesLeft.Add('H');
		tilesLeft.Add('I');
		tilesLeft.Add('J');
		tilesLeft.Add('K');
		tilesLeft.Add('L');
		tilesLeft.Add('M');
		tilesLeft.Add('N');
		tilesLeft.Add('O');
		tilesLeft.Add('P');
		tilesLeft.Add('Q');
		tilesLeft.Add('R');
		tilesLeft.Add('S');
		tilesLeft.Add('T');
		tilesLeft.Add('U');
		tilesLeft.Add('V');
		tilesLeft.Add('W');
		tilesLeft.Add('X');
		tilesLeft.Add('Y');
		tilesLeft.Add('Z');
		
		//convert word string into an array of separate characters
		wordAsChars = strList.ToCharArray(0, strList.Length);
		//convert it to a list
		for(int i=0; i<wordAsChars.Length; i++){
			wordAsCharsList.Add (wordAsChars[i]);
		}
		//create space for the array
		tilesWord = new GameObject[strList.Length];
		
		
		//populating only word's letter tiles into this array
		for(int i=0; i<wordAsCharsList.Count; i++){
			//Debug.Log ("wordAsChars " + wordAsChars[i]);
			//each letter is converted to a string so it can be used in GameObject.Find
			string letter = "" + wordAsCharsList[i];
			chLetter =  wordAsCharsList[i];
			//find the tile that has that letter as a name
			GameObject objLetter = GameObject.Find(letter);
			//find the gameobject that is of the same letter
			tilesWord[i] = GameObject.Find(letter);
			//Debug.Log (tilesWord[i]);
			for(int j=0; j<tilesLeft.Count; j++){
				//Debug.Log ("tilesLeft " + tilesLeft[i]);
				//remove that character from the letter tiles that are left
				tilesLeft.Remove( chLetter );
				//Debug.Log (tilesLeft[j]);
			}
		}
		
		//populate the tiles into a list
		for(int i=0; i<tilesLeft.Count; i++){
			
			//get a char version of the letter
			char charLetter = tilesLeft[i];
			//get a string version of the letter
			string strLetter = "" + charLetter;
			//get an object version of the letter
			GameObject objLetter =  GameObject.Find(strLetter);
			//add the object version of the letter to the gameobject letter list
			objTilesLeft.Add (objLetter);
			//print it to console
			Debug.Log (objTilesLeft[i]);
		}
		
	}
	
	public void spawnTiles() {
		
		//get the word
		string getStr = RandomWord.getLettersHolder();
		//take extra white characters off
		getStr.Trim();
		//change to uppercase
		getStr = getStr.ToUpper();
		//change word to array of individual letters
		char[] letterAsCharacs = getStr.ToCharArray(0, getStr.Length);
		//each letter is converted to a string so it can be used in GameObject.Find
		for(int m=0; m<letterAsCharacs.Length; m++){
			//as string
			string letter = "" + letterAsCharacs[m];
			//as chars
			char chLetter =  wordAsCharsList[m];
			//take white space off and put it into a list
			objWordLeft = objWordLeft.Where(x => x != null).ToList();
			//find the tile that has that letter as a name
			objWordLeft.Add(GameObject.Find(letter));
			objWordLeft = objWordLeft.Where(x => x != null).ToList();
		}
		//get the word
		string getStrWord = RandomWord.getWordHolder();
		//take extra white characters off
		getStrWord.Trim();
		//change to uppercase
		getStrWord = getStrWord.ToUpper();
		//change word to array of individual letters
		char[] wordAsCharacs = getStrWord.ToCharArray(0, getStrWord.Length);
		//each letter is converted to a string so it can be used in GameObject.Find
		for(int c=0; c<wordAsCharacs.Length; c++){
			//as string
			string letter = "" + wordAsCharacs[c];
			//as char
			char chLetter =  wordAsCharacs[c];
			//remove ties from list of tiles left
			objTilesLeft.Remove(GameObject.Find(letter));
			//take white space off and put it into a list
			objTilesLeft = objTilesLeft.Where(x => x != null).ToList();
		}
		
		//Get a random tile from Wrong Tiles List
		int i = Random.Range(0, objTilesLeft.Count);
		//Get a random tile from Right Tiles List
		int j = Random.Range(0, objWordLeft.Count);

		
		//Shake up Wrong Tile and Right Tile so nobody knows if right tile or wrong tile is up top or at bottom of screen
		int k = Random.Range(0, 1000);
		
		//if k is odd then place inst1 goes at top of screen
		if(k % 2 != 0){
			
			//instantiate the wrong tile at top and the right tile at the bottom of screen
			Instantiate (objTilesLeft[i], currentSpawnPoint.transform.position, currentSpawnPoint.transform.rotation);
			Instantiate (objWordLeft[j], currentSpawnPoint2.transform.position, currentSpawnPoint2.transform.rotation);
			//put these into vars
			//removeTiles(tilesWord[j]);
			
			
		} else if (k % 2 == 0){
			
			//instantiate the correct tile at top and the wrong tile at the bottom  of screen
			Instantiate (objWordLeft[j], currentSpawnPoint.transform.position, currentSpawnPoint.transform.rotation);
			Instantiate (objTilesLeft[i], currentSpawnPoint2.transform.position, currentSpawnPoint2.transform.rotation);
			//put these into vars
			//removeTiles(tilesWord[j]);
			
			
		}
		
	}
	
	
	
	public void removeTiles(GameObject tile){
		//string stringChars = "" + letter;
		string name = tile.name;
		//NEW 4-16...take (Clone) out of name
		name = name.Replace("(Clone)", ""); 
		//NEW 4-16...instance ID just in case we need it
		wList.removeTiles(name);
		
		
	}
	
	public void reset(){
		strList = "";
		strList =RandomWord.getLettersHolder();
		//clear out the character array
		for(int i=0; i<wordAsChars.Length; i++){
			wordAsChars[i] = '\0';
		}
		//convert word string into an array of separate characters
		wordAsChars = strList.ToCharArray(0, strList.Length);
		//clear character list
		wordAsCharsList.Clear ();

		
	}
	
	
}