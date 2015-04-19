using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WList : MonoBehaviour {


	//public static string str = "SLEDDING";
	private static string lcStr = System.IO.File.ReadAllText("word.txt");
	public static string listStr = System.IO.File.ReadAllText("letters.txt");
	public static List<char> lettersLeft = new List<char>();
	public string str = lcStr.ToUpper();
	public char[] wordAsChars;
	public static char[] wordAsLetters;
	//TileManager tileManager = new  TileManager();
	//create a tilesLeft list for GameObjects
	//public static List<GameObject> objTiles = new List<GameObject>();
	
	
	void Start(){
		//create space for the array
		//for(int i=0; i<wordAsChars.Length; i++){
			//string stringChars = "" + wordAsChars[i];
			//objTiles.Add (GameObject.Find(stringChars));
		//}
		//makeTextDoc();
		
		wordAsChars = str.ToCharArray(0, str.Length);
		//Debug.Log ("wordAsChars length is " + wordAsChars.Length);
	}
	
	public static void CharsLeft(char letter){
		string listStr2 = System.IO.File.ReadAllText("letters.txt");
		wordAsLetters = listStr2.ToCharArray(0, listStr2.Length);
		//lettersLeft = null;
		for(int i=0; i<wordAsLetters.Length; i++){
			//Debug.Log (wordAsLetters[i]);
			lettersLeft.Add (wordAsLetters[i]);
			lettersLeft.Remove (letter);
			Debug.Log ("Letters Left are: " + lettersLeft[i]);
			
		}
	
	}
	
	void Update(){
	
		
	}
	//public void makeTextDoc(){
		//for(int i=0; i<wordAsChars.Length; i++){
			//System.IO.File.AppendAllText("letters.txt", wordAsChars[i] + "\n");
		//}
	//}
	
	public void removeTiles(string letter){
		//string stringChars = "" + letter;
		//objTiles.Remove(GameObject.Find(stringChars));
		//char charLetter = letter[0];
		string str = "";
		//Debug.Log ("wordAsChars length is " + wordAsChars.Length);
		for(int i=0; i<wordAsChars.Length; i++){
			str = str + wordAsChars[i] + "\n";
			Debug.Log ("str is " + str);
		}
		
		//Debug.Log ("Letter being replace is " + letter);
		//str = str.Replace (letter, "");
		//Replace all of these letters
		for(int j=0; j<ChoseLetter.charsChosen.Count; j++){
			string strCharsRemove = "" + ChoseLetter.charsChosen[j];
			//Replace all of these letters
			str = str.Replace (strCharsRemove, "");
		}
		System.IO.File.WriteAllText("letters.txt", str);
		//CharsLeft(charLetter);
	}
	
	
}
