/// <summary>
/// Player Action Script.
/// MyCharacterActions creates an action to link with inputs this will alow the creation of MyCharacterAction Objects in the PlayerControl Script
/// and is needed for touch screen buttons.
/// </summary>

using UnityEngine;
using System.Collections;
using InControl;

public class MyCharacterActions : PlayerActionSet//Inherits from PlayerActionSet from InControl API
{

	public PlayerAction Jump;
	public PlayerAction Fire;
	public PlayerAction Continue;
	
	public MyCharacterActions()
	{

		Jump = CreatePlayerAction( "Jump" );
		Fire = CreatePlayerAction( "Fire" );
		Continue = CreatePlayerAction ("Action3");
	}
}