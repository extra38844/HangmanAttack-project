/// <summary>
/// Enemy Health Manager
/// Description of Class - Manages the enemy's health and damage that they have taken.
/// </summary>

using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {
	
	//every enemy has a health value - that goes down as they get hurt
	public int enemyHealth;
	//create a death effect particle system for when they die
	public GameObject deathEffect;
	//number of points player gets on the enemy's death
	public int pointsOnDeath;
	//add timer in here
	private Timer timer;
	
	// Use this for initialization
	void Start () {
		//find timer in the scene
		timer = FindObjectOfType<Timer>();
	}
	
	// Update is called once per frame
	void Update () {
		
		//if enemy's health is less than or = to 0 then ...
		if(enemyHealth <= 0){
			//instantiate the death particle effect in the position of enemy's death
			Instantiate (deathEffect, transform.position, transform.rotation);
			//Add points to scoremanager
			ScoreManager.AddPoints (pointsOnDeath);
			//remove enemy from scene
			Destroy (gameObject);
			//add 5 second bonus to the timer for killing enemy
			timer.timeLeft += 5;
		}
	}
	
	
	
	public void giveDamage(int damageToGive){
		
		//take away damageToGive from the enemy's health
		enemyHealth -= damageToGive;
		//play audiosource attached to the game object that this script is on
		GetComponent<AudioSource>().Play ();
		
	}
}