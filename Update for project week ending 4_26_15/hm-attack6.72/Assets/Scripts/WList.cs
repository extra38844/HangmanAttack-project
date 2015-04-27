using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class WList : MonoBehaviour {


	//public static string str = "SLEDDING";
	private static string lcStr = RandomWord.getWordHolder();
	public static string listStr = RandomWord.getLettersHolder();
	public static List<char> lettersLeft = new List<char>();
	public static string str = lcStr.ToUpper();
	public char[] wordAsChars;
	public static char[] wordAsLetters;
	//TileManager tileManager = new  TileManager();
	//create a tilesLeft list for GameObjects
	//public static List<GameObject> objTiles = new List<GameObject>();
	
	
	void Start(){
		lcStr.Trim();
		listStr.Trim();
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
		string listStr2 = RandomWord.getLettersHolder();
		listStr2.Trim();
		wordAsLetters = listStr2.ToCharArray(0, listStr2.Length);
		//lettersLeft = null;
		for(int i=0; i<wordAsLetters.Length; i++){
			//Debug.Log (wordAsLetters[i]);
			lettersLeft.Add (wordAsLetters[i]);
			lettersLeft.Remove (letter);
			
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
			
		}
		
		//Debug.Log ("Letter being replace is " + letter);
		//str = str.Replace (letter, "");
		//Replace all of these letters
		for(int j=0; j<ChoseLetter.charsChosen.Count; j++){
			string strCharsRemove = "" + ChoseLetter.charsChosen[j];
			//Replace all of these letters
			str = str.Replace (strCharsRemove, "");
			TileManager.objTilesLeft.Remove (GameObject.Find(strCharsRemove));
			//tileManager.objTilesLeft = tileManager.objTilesLeft.Where(x => x != null).ToList();
		}
		
		
		string reg = null;
		reg = Regex.Replace(str, @"\s+", "");
		string out_string = reg.Replace(str, "");
		RandomWord.setLettersHolder(out_string);
		//CharsLeft(charLetter);
	}
	
	
}
