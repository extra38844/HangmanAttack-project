using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnStart : MonoBehaviour {

	private static string lcStr = System.IO.File.ReadAllText("word.txt");
	public char[] wordAsChars;
	public string str = lcStr.ToUpper();
	public static int wordLength;
	
	void Start(){
		//tileManager= FindObjectOfType<TileManager>();
		//convert word string into an array of separate characters
		wordAsChars = str.ToCharArray(0, str.Length);
		wordLength = wordAsChars.Length;
		makeTextDoc();
	}
	
	public void makeTextDoc(){
		string str2 = "";
		for(int i=0; i<wordAsChars.Length; i++){
			
			str2 = str2 + wordAsChars[i];
		}
		System.IO.File.WriteAllText("letters.txt", str2);
	}
}
