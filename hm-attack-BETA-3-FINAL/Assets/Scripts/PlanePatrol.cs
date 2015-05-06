/// <summary>
/// Plane Patrol.
/// Description of Class - Controls flying objects such as the plane and the projectiles that they emit.
/// </summary>

using UnityEngine;
using System.Collections;

public class PlanePatrol : MonoBehaviour {
	
	//determine the speed he is moving
	public int moveSpeed;
	//Create an animator object
	private Animator anim;
	//when was the last bomb drop
	float lastShot = 0.0f;
	//how much delay between bomb drops
	float delayBetweenShots = 3.0f;
	//create a bomb projectile object
	public GameObject bombProjectile;
	
	// Use this for initialization
	void Start () {
		
		//find the objects that have animator attached t oit
		anim = GetComponent<Animator>();
		//when was the last time a bomb was shot?
		lastShot = Time.time;
		
	}
	
	//check to see if plane can again drop a bomb
	void CanAttackTarget()
	{
		//if it is time to shoot again then...
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

	}
	
	// Update is called once per frame
	void Update () {
		
		//if move left, then moveSpeed is negative
		GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
		//keep transform at 1 scale
		transform.localScale = new Vector3(1f,1f,1f);
		//animate the plane
		anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
		//is it time to drop another bomb?
		CanAttackTarget();
		
		
	}
}
