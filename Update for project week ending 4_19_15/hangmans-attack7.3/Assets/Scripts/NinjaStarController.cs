using UnityEngine;
using System.Collections;

public class NinjaStarController : MonoBehaviour {

	//speed of ninjaStar
	public float speed;
	//add player
	public PlayerController player;
	//add death effect
	public GameObject enemyDeathEffect;
	//add particle system
	public GameObject impactEffect;
	//points for killing enemy
	public int pointsForKill;
	//how fast ninja star rotates
	public float rotationSpeed;
	public int damageToGive;
	
	// Use this for initialization
	void Start () {
	
		//will look for objects with PlayerController attached to it and since
		//only 1 object has this (the player), we know it is the player
		player = FindObjectOfType<PlayerController>();
		//so this value will tell us whether he is looking left or right...if it is less than 0 he is facing left
		if(player.transform.localScale.x < 0){
			//set the speed to - to reverse direction..so now should head towards the left
			speed = -speed;
			//set rotation speed to opposite so the ninjaStar reverses which way it spins
			rotationSpeed = -rotationSpeed;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//move the ninjaStar at velocity of speed we set for x, and keep the current velocity for y
		GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
		//angular velocity is how much spin it has
		GetComponent<Rigidbody2D>().angularVelocity = rotationSpeed;
	}
	
	//When NinjaStar hits something
	void OnTriggerEnter2D(Collider2D other) {
		
		
		//if ninjaStar hits an object tagged with "Enemy" then..
		if(other.tag == "Enemy"){
			//instantiate the enemyDeath effect at the position of enemy
			//Instantiate(enemyDeathEffect, other.transform.position, other.transform.rotation);
			//destroy this other object
			//Destroy(other.gameObject);
			//Add points to score
			//ScoreManager.AddPoints(pointsForKill);
			//Look for the EnemyHealthManager script on the enemy and go to giveDamage function and give the amount of damage in variable damageToGive
			other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
		}
		
		//instantiate the particle effect at current position that occurs when it hits something
		Instantiate (impactEffect, transform.position, transform.rotation);
		//Destroy NinjaStar instance
		Destroy (gameObject);
	
	}
}
