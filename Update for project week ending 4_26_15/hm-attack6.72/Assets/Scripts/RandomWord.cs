//J added 4/22

using UnityEngine;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

public class RandomWord : MonoBehaviour {

	private static string wordHolder="unassigned";
	private static string lettersHolder="unassigned";
	
	void Start () {
		//string randomWord = "";
		string url = "http://randomword.setgetgo.com/get.php";
		WWW www = new WWW(url);
		
		StartCoroutine(WaitForRequest(www));
	}
	
	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		
		// check for errors
		if (www.error == null)
		{
			string randomWord=www.text;
			randomWord.Trim();
			string reg = null;
			reg = Regex.Replace(randomWord, @"\s+", "");
			string out_string = reg.Replace(randomWord, "");
			//System.IO.File.WriteAllText("word.txt",out_string);
			//System.IO.File.WriteAllText("letters.txt",out_string);
			setBothHolders(out_string);
			Debug.Log(randomWord);
		} else {
			Debug.Log("WWW Error: "+ www.error);
			setBothHolders("test");
		}    
	}

	public static string getWordHolder()
	{
		return wordHolder;
	}
	public static string getLettersHolder()
	{
		return lettersHolder;
	}

	public static void setBothHolders(string Word)
	{
		wordHolder = Word;
		lettersHolder = Word;
	}

	public static void setWordHolder(string Word)
	{
		wordHolder = Word;

	}

	public static void setLettersHolder(string Word)
	{

		lettersHolder = Word;
	}
} 