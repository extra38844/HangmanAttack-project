/// <summary>
/// Enemy Patrol.
/// Description of Class - The enemy walks back and forth. This script controls where the enemy can go.
/// </summary>

using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

	//determine the speed he is moving
	public float moveSpeed;
	//determine whether moving left or right
	public bool moveRight;//A Transform is basically a point in space
	public Transform wallCheck;
	//how big the circle you make needs to be in order to determine if you are touching wall
	public float wallCheckRadius;
	//True that player IS touching the wall or False the player is NOT touching the wall
	public LayerMask WhatIsWall;
	//are we hitting the wall
	private bool hittingWall;
	//make sure enemy is not at edge of ground and ready to fall off
	private bool notAtEdge;
	//check for edge of ground
	public Transform edgeCheck;
	//animate the enemy
	private Animator anim;
	
	// Use this for initialization
	void Start () {
	
		//animate the enemy
		anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
	
		//find out whether it is hitting wall or not with OverlapCircle which is used to check if a collider falls within a circular area
		hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, WhatIsWall);
		
		//If not at edge - returns True 
		notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, WhatIsWall);
		
		
		//If you do hit the wall or get to edge then...
		if(hittingWall || !notAtEdge){
			//switch directions you are moving
			moveRight = !moveRight;
		}
		
		if(moveRight){
			//if he is moving right then he needs to be flipped because his wallCheck is only on his left
			//so if we flip him when he moves right then his wallCheck will be on the right where we need it ... we do this with -1f for the x
			transform.localScale = new Vector3(-1f,1f,1f);
			//if move right, then moveSpeed is positive
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
		}else {
			//keep the transform the same..no flipping needed
			transform.localScale = new Vector3(1f,1f,1f);
			//if move left, then moveSpeed is negative
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
		}
		//animate the walk
		anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
	}
}
