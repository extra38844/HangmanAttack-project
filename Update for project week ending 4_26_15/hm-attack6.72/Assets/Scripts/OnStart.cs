using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class OnStart : MonoBehaviour {

	private static string lcStr = RandomWord.getWordHolder();
	public static char[] wordAsChars;
	public static string str = lcStr.ToUpper();
	public static int wordLength;
	public static int wordLengthKeep;
	
	void Start(){
		//tileManager= FindObjectOfType<TileManager>();
		//convert word string into an array of separate characters
		wordAsChars = str.ToCharArray(0, str.Length);
		wordLength = wordAsChars.Length;
		//wordLengthKeep = wordAsChars.Length;
		//Count of how many unique letters are in the word
		wordLengthKeep = str.Distinct().Count();
		Debug.Log (wordLengthKeep);
		makeTextDoc();
	}
	
	public void makeTextDoc(){
		string str2 = "";
		for(int i=0; i<wordAsChars.Length; i++){
			
			str2 = str2 + wordAsChars[i];
		}
		
		RandomWord.setLettersHolder(str2);
		
	}
}
