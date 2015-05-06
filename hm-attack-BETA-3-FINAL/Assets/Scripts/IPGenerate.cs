/// <summary>
/// IP Generate.
/// Description of Class - Gets the IP address from 3rd API.
/// </summary>

using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class IPGenerate : MonoBehaviour {
	//12.133.41.130
	//	17.173.254.223
	private static string IP="0";
	private static string currentDate="";
	void Start () {
		//string randomWord = "";

			setCurrentDate();
			string url = "http://www.telize.com/ip";
			WWW www = new WWW (url);
			
			StartCoroutine (WaitForRequest (www));
		}
	
	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		
		// check for errors
		if (www.error == null)
		{
			IP=www.text;
			IP=IP.Trim();
				//System.IO.File.WriteAllText("IP.txt",IP);
				Debug.Log(IP);
			 	//Application.LoadLevel ("BeforeStart");
		}
		else 
		{
			Debug.Log("WWW Error: "+ www.error);
			IP="12.133.41.130";
		}    
	}

	public static void setIP(string IP1)
	{
		IP = IP1;
	}

	public static string getIP()
	{
		return IP;
	}

	public static void setCurrentDate()
	{
		currentDate = System.DateTime.Now.ToString("MM/dd/yyyy HH:mm");
		currentDate = currentDate.Substring (0, 10);
	}

	public static string getCurrentDate()
	{
		return currentDate;
	}
	
} 