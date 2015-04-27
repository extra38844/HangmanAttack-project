//J added 4/22

using UnityEngine;
using System.Collections;
using System.IO;

public class WeatherAndTime : MonoBehaviour {
	private static string weather="";
	private static string time="";

	private string ip="0";
	void Start () {

		ip = IPGenerate.getIP ();//Gets IP from IP generate script

		//API to get Geolocated Weather and the date returns JSON
		string url = "api.worldweatheronline.com/free/v2/weather.ashx?q="+ip+"&format=json&date=today&fx=no&show_comments=no&showlocaltime=yes&key=acb6f02cc412e35c06025833fd042";
		WWW www = new WWW(url);


		StartCoroutine(WaitForRequest(www));
	}
	
	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		
		// check for errors
		if (www.error == null)
		{
			weather=www.text;//full JSON return
			time=www.text;//full JSON return

			//parse to single word for weather and two digits for time
			int indexParse=weather.LastIndexOf("weatherIconUrl");
			weather=weather.Substring(0,indexParse);
			indexParse=weather.LastIndexOf("value");
			weather=weather.Substring(indexParse);
			indexParse=weather.LastIndexOf(":");
			weather=weather.Substring(indexParse);
			weather=weather.Substring(3);
			indexParse=weather.LastIndexOf("}");
			indexParse-=2;
			weather=weather.Substring(0,indexParse);

			indexParse=time.LastIndexOf("localtime");
			indexParse+=24;
			time=time.Substring(indexParse);
			time=time.Substring(0,2);


			Debug.Log(weather);
			Debug.Log(time);
		} else {//default if unable to get return
			Debug.Log("WWW Error: "+ www.error);
			weather="clear";
			time="12";
		}    
	}
	//sets and gets
	public static void setWeather(string weather1)
	{
		weather = weather1;
	}

	public static string getWeather()
	{
		return weather;
	}

	public static void setTime(string time1)
	{
		time = time1;
	}
	
	public static string getTime()
	{
		return time;
	}
	
} 