using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string startLevel;
	public string levelSelect;
	
	//a method for when user clicks on New Game button
	public void NewGame() {
		//load up the first level
		Application.LoadLevel(startLevel);
	
	}
	
	//a method for when user clicks on Level Select button
	public void LevelSelect() {
		//load up LevelSelect level
		Application.LoadLevel (levelSelect);
	}
	
	//a method for when user clicks on Quit Game button
	public void QuitGame() {
		//quit application
		Application.Quit ();
	}
}
