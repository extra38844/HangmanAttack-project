﻿using UnityEngine;
using System.Collections;

public class PlanePatrol : MonoBehaviour {
	
	//determine the speed he is moving
	public int moveSpeed;
	
	private Animator anim;
	
	float lastShot = 0.0f;
	float delayBetweenShots = 3.0f;
	
	// Instantiate a rigidbody then set the velocity
	
	public GameObject bombProjectile;
	
	// Use this for initialization
	void Start () {
		
		anim = GetComponent<Animator>();
		//when was the last time a bomb was shot?
		lastShot = Time.time;
		
	}
	
	//check to see if plane can again drop a bomb
	void CanAttackTarget()
	{
		//if too early to drop a bomb then return false
		if ((Time.time - delayBetweenShots) > lastShot)
		{
			//shoot again.
			shoot();
			
		}
		
	}
	
	//drop the bomb
	void shoot()
	{
		//now you can reset the time
		lastShot = Time.time;
		//bomb dropping code
		
		Instantiate(bombProjectile, transform.position, transform.rotation);
		
		// Give the cloned object an initial velocity along the current
		// object's Z axis
		//BombClone.velocity = transform.TransformDirection (Vector3.forward * 10);
	}
	
	// Update is called once per frame
	void Update () {
		
		//if move left, then moveSpeed is negative
		GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
		transform.localScale = new Vector3(1f,1f,1f);
		
		
		anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
		CanAttackTarget();
		
		
	}
}