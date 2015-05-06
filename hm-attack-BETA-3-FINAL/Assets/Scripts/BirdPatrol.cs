/// <summary>
/// Bird patrol.
/// Description of Class - Controls behavior of bird enemy
/// </summary>

using UnityEngine;
using System.Collections;

public class BirdPatrol : MonoBehaviour {
	
	//determine the speed he is moving
	private float moveSpeed;
	//call the bird animation
	private Animator anim;
	//when was the last time he laid an egg
	private float lastShot;
	//what should the delay be between the bird laying eggs
	private float delayBetweenShots;
	//make a game object for the egg projectile
	public GameObject eggProjectile;

	//the variables for the bird's patrol
	public BirdPatrol()
	{
		moveSpeed = 1.0F;
		lastShot = 0.0F;
		delayBetweenShots = 3.0F;
	}

	public string toString()
	{
		return ("Birds movepeed is "+moveSpeed+" delay between shots is "+delayBetweenShots);
	}

	public float getMoveSpeed()
	{
		return moveSpeed;
	}

	public void setMoveSpeed(float moveSpeed)
	{
		this.moveSpeed = moveSpeed;
	}

	public float getLastShot()
	{
		return lastShot;
	}
	
	public void setLastShot(float lastShot)
	{
		this.lastShot = lastShot;
	}

	public float getDelayBetweenShots()
	{
		return delayBetweenShots;
	}
	
	public void setDelayBetweenShots(float delayBetweenShots)
	{
		this.delayBetweenShots = delayBetweenShots;
	}


	
	// Use this for initialization
	void Start () {
		//animate the bird
		anim = GetComponent<Animator>();
		//when was the last time an egg was shot?
		lastShot = Time.time;
		
	}
	
	//check to see if the bird can again drop an egg
	void CanAttackTarget()
	{
		//if it is time to drop an egg then shoot
		if ((Time.time - delayBetweenShots) > lastShot)
		{
			//shoot that egg
			shoot();
			
		}
		
	}
	
	//drop the egg
	void shoot()
	{
		//now you can reset the time
		lastShot = Time.time;
		//change the y transform position so egg starts dropping a bit below the bird
		eggProjectile.transform.position = new Vector3(transform.position.x, transform.position.y-0.75f, transform.position.z);
		//egg dropping code
		Instantiate(eggProjectile, eggProjectile.transform.position, transform.rotation);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//move the bird with all the variables that we have set
		GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
		//keep at scale 1
		transform.localScale = new Vector3(1f,1f,1f);
		//set the animated bird's rigidbody to float at this velocity
		anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
		//find out if bird is ready to shoot another egg
		CanAttackTarget();
		
		
	}
}
