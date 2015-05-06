/// <summary>
/// Level Manager.
/// Description of Class - Manage respawning of the player when getting killed.
/// </summary>

using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	//this will be whatever point we want the player to respawn at
	public GameObject currentCheckpoint;
	
	//definte particle systems
	public GameObject deathParticle;
	public GameObject respawnParticle;
	
	//delay between dying and respawning
	public float respawnDelay;
	
	//if we die, we lose points
	public int pointPenaltyOnDeath;
	
	//we also want to know what the player is by accessing the PlayerController.cs script
	private PlayerController player;
	
	//add cameraController
	private new CameraController camera;
	
	//Add HealthManager
	public HealthManager healthManager;
	
	//AddTimer
	public Timer timer;
	
	// Use this for initialization
	void Start () {
		//find objects of type PlayerController - so find player in the scene
		player = FindObjectOfType<PlayerController>();
		//find CameraController object in game and set it to camera
		camera= FindObjectOfType<CameraController>();
		//find HealthManager object and set it to healthManager
		healthManager = FindObjectOfType<HealthManager>();
		//find Timer object and set it to type timer
		timer = FindObjectOfType<Timer>();
	}
	
	public void reSpawnPlayer() {
	
		//Call the CoRoutine (like a function that has ability to pause execution & return control to Unity but 
		//then to continue where it left off on the following frame. 
		StartCoroutine ("ReSpawnPlayerCo");
		
	}
	
	public IEnumerator ReSpawnPlayerCo() {
	
		//I GUESS THE PLAYER JUST DIED - UH OH!
		//Before player is respawned. Instantiate creates a copy of whatever object we say(in this case deathParticle)
		//we tell it to instantiate at the place where the player is/was when he died. Rotation has to be there when instantiating
		Instantiate(deathParticle, player.transform.position, player.transform.rotation);
		
		//MAKE PLAYER DISAPPEAR UNTIL AFTER DELAY
		//disables the player so you won't be able to move him any more
		player.enabled = false;
		
		//make it so you can NOT see player any more
		player.GetComponent<Renderer>().enabled = false;
		
		//After Comes back alive return player back to full Health
		healthManager.FullHealth();
		//so now player is NOT dead
		healthManager.isDead = false;
		//stop following character for a sec
		camera.setIsFollowing(false);
		
		//Score Penalty for Dying - Lose Points
		ScoreManager.AddPoints (-pointPenaltyOnDeath);
		
		//Subtract 1 from number of lives left
		LivesManager.SubtractLives();
		
		//make the player have a larger drag for a bit
		player.GetComponent<Rigidbody2D> ().drag = 30;
		//make the player have a smaller mass for a bit
		player.GetComponent<Rigidbody2D> ().mass = 0;
				
		//ADD a DELAY between DYING and RESPAWNING
		//this method will determine how long of a delay we have
		yield return new WaitForSeconds(respawnDelay);
		
		//PLAYER RESPAWNS!
				
		//remove bounce back from respawned player
		player.knockBackCount = 0;
		
		//reset timer back to starting point
		timer.resetTimer();
		
		//MAKE PLAYER REAPPEAR NOW
		//enable the player so you WILL be able to move again
		player.enabled = true;
		//make it so you CAN see player any more
		player.GetComponent<Renderer>().enabled = true;
		
		//to respawn, make the players position be the position of the checkpoint we created
		player.transform.position = currentCheckpoint.transform.position;
		//we should start following the player with the camera again
		camera.setIsFollowing(true);
		//instantiate the respawnParticle at the currentCheckpoint position...it will be with the respawned player
		Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
		//make sure the player has some lives left
		//make the player back to normal drag & mass again
		player.GetComponent<Rigidbody2D> ().drag = 0;
		player.GetComponent<Rigidbody2D> ().mass = 1;
		if(LivesManager.lives <= 0){
			//player is dead .. go to lose screen
			Application.LoadLevel("Lose");
		}
	}
}
