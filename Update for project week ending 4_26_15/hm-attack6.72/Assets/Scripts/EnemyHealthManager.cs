using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

	public int enemyHealth;
	public GameObject deathEffect;
	public int pointsOnDeath;
	
	// Use this for initialization
	void Start () {
	
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
		}
	}
	
	
	
	public void giveDamage(int damageToGive){
	
		//take away damageToGive from the enemy's health
		enemyHealth -= damageToGive;
		//play audiosource attached to the game object that this script is on
		GetComponent<AudioSource>().Play ();
	
	}
}
