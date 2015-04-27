using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string weather = WeatherAndTime.getWeather();//gets weather
		int time = int.Parse(WeatherAndTime.getTime ());//gets time (2 digits 24 hour time)

		if (time <= 18) {//6PM or earlier is daytime pictures
			if (weather.Contains ("Sun") || weather.Contains ("Clear"))
				weather = "Sunny";
			else if (weather.Contains ("Rain") || weather.Contains ("Storm"))
				weather = "Rain";
			else if (weather.Contains ("Snow") || weather.Contains ("Blizzard"))
				weather = "Snow";
			else if (weather.Contains ("Cloud")|| weather.Contains ("Overcast"))
				weather = "Cloudy";
			else
				weather = "Sunny";
		} 
		else //later than 6 PM night time pictures
		{
			if (weather.Contains ("Clear"))
				weather = "NightClear";
			else if (weather.Contains ("Rain") || weather.Contains ("Storm"))
				weather = "NightRain";
			else if (weather.Contains ("Snow") || weather.Contains ("Blizzard"))
				weather = "NightSnow";
			else if (weather.Contains ("Cloud")|| weather.Contains ("Overcast"))
				weather = "NightCloudy";
			else
				weather = "NightClear";
		}
		switch (weather)
		{
		//DAYTIME WEATHER
		case "Sunny":
			Material newMat = Resources.Load("Clear", typeof(Material)) as Material;//Material object using the material in the resources folder
			GetComponent<Renderer>().material=newMat;//Use the material as the new texture in the renderer.
			Debug.Log("Sunny");
			break;
		case "Rain":
			newMat = Resources.Load("Rain", typeof(Material)) as Material;
			GetComponent<Renderer>().material=newMat;
			Debug.Log("Rain");
			break;
		case "Cloudy":
			newMat = Resources.Load("Cloudy", typeof(Material)) as Material;
			GetComponent<Renderer>().material=newMat;
			Debug.Log("Cloudy");
			break;

		case "Snow":
			newMat = Resources.Load("NightSnow", typeof(Material)) as Material;
			GetComponent<Renderer>().material=newMat;
			Debug.Log("NightSnowy");
			break;
		//Night time Weather
		case "NightClear":
			newMat = Resources.Load("NightClear", typeof(Material)) as Material;
			GetComponent<Renderer>().material=newMat;
			Debug.Log("NightClear");
			break;
		case "NightRain":
			newMat = Resources.Load("NightRain", typeof(Material)) as Material;
			GetComponent<Renderer>().material=newMat;
			Debug.Log("NightRain");
			break;
		case "NightCloudy":
			newMat = Resources.Load("NightCloudy", typeof(Material)) as Material;
			GetComponent<Renderer>().material=newMat;
			Debug.Log("NightCloudy");
			break;
			
		case "NightSnow":
			newMat = Resources.Load("NightSnow", typeof(Material)) as Material;
			GetComponent<Renderer>().material=newMat;
			Debug.Log("NightSnowy");
			break;

		default:
			newMat = Resources.Load("crumpled-paper1", typeof(Material)) as Material;
			GetComponent<Renderer>().material=newMat;

			Debug.Log("Is there weather?");
			break;
		}
	
	}
	

}
