/// <summary>
/// Main Menu.
/// Description of Class - Script attached to load different scenes in the game.
/// </summary>

using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string startLevel;
	public string levelSelect;
	
	//a method for when user clicks on New Game button
	public void NewGame() {
		//load up the first level
		Application.LoadLevel("Level01");
	
	}
	
	//a method for going to PreLoad screen
	public void PreLoad() {
		//load up the first level
		Application.LoadLevel("Empty");
		
	}
	
	//a method for when user clicks on Level Select button
	public void LevelSelect() {
		//load up LevelSelect level
		Application.LoadLevel (levelSelect);
	}
	
	//a method for when user clicks on Level Select button
	public void Instructions() {
		//load up LevelSelect level
		Application.LoadLevel ("Instructions");
	}
	
	//a method for when user clicks on Level Select button
	public void BackToMenu() {
		//load up LevelSelect level
		Application.LoadLevel ("Title_Menu");
	}
	
	//a method for when user clicks on Quit Game button
	public void QuitGame() {
		//quit application
		Application.Quit ();
	}
}
