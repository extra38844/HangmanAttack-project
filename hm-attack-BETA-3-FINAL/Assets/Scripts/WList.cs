/// <summary>
/// WList.
/// Description of Class - Manages Word related variables and arrays that have to do with starting values of game.
/// </summary>

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class WList : MonoBehaviour {
	
	//get the random word and assign to different variables
	public static string lcStr = RandomWord.getWordHolder();
	public static string listStr = RandomWord.getLettersHolder();
	//create a list of letters left
	public static List<char> lettersLeft = new List<char>();
	//change to uppercase
	public static string str = lcStr.ToUpper();
	//create a value of word as individual letters
	public char[] wordAsChars;
	public static char[] wordAsLetters;
	
	
	void Start(){
		//assign variables/arrays
		lcStr = RandomWord.getWordHolder();
		listStr = RandomWord.getLettersHolder();
		lettersLeft = new List<char>();
		//change to uppercase
		str = lcStr.ToUpper();
		//convert word to array of letters
		wordAsChars = str.ToCharArray(0, str.Length);
		Debugger.Array<char>(wordAsChars);
		
	}
	
	public static void CharsLeft(char letter){
		//assign random word to listStr2
		string listStr2 = RandomWord.getLettersHolder();
		//trim white space
		listStr2.Trim();
		//convert word to array of letters
		wordAsLetters = listStr2.ToCharArray(0, listStr2.Length);
		Debugger.Array<char>(wordAsLetters);
		//lettersLeft = null;
		for(int i=0; i<wordAsLetters.Length; i++){
			//add to letters left
			lettersLeft.Add (wordAsLetters[i]);
			//remove letter
			lettersLeft.Remove (letter);
			
		}
		
	}
	
	public void removeTiles(string letter){
		
		string str = "";
		for(int i=0; i<wordAsChars.Length; i++){
			str = str + wordAsChars[i] + "\n";
			
		}

		//find characters to remove from objTilesLeft
		for(int j=0; j<ChoseLetter.charsChosen.Count; j++){
			string strCharsRemove = "" + ChoseLetter.charsChosen[j];
			//Replace all of these letters
			str = str.Replace (strCharsRemove, "");
			TileManager.objTilesLeft.Remove (GameObject.Find(strCharsRemove));
		}
		
		
		string reg = null;
		reg = Regex.Replace(str, @"\s+", "");
		string out_string = reg.Replace(str, "");
		RandomWord.setLettersHolder(out_string);
		Debugger.QuickLog<string>(out_string);
	}
	
	
}