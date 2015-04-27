using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//variables
	public float moveSpeed;
	public float jumpHeight;
	//A Transform is basically a point in space
	public Transform groundCheck;
	//how big the circle you make needs to be in order to determine if you are on the ground
	public float groundCheckRadius;
	//True that player IS on the ground or False the player is NOT on the ground
	public LayerMask WhatIsGround;
	private bool grounded;
	private float moveVelocity;
	private bool doubleJumped;
	//add animator to player for animations of player  & enable us to add the component that is already on the character
	private Animator anim;
	//need a point to start shooting from
	public Transform firePoint;
	//need the item he is going to fire
	public GameObject ninjaStar;
	//time between each shot
	public float shotDelay;
	private float shotDelayCounter;
	//will hold amount of force we apply to player when he gets hit
	public float knockBack;
	//how long the player will be knocked back for
	public float knockBackLength;
	//count down type of thing
	public float knockBackCount;
	//knocked back to the Right??? If enemy knocks into us FROM THE RIGHT, we want to be knocked TOWARDS the LEFT
	public bool knockFromRight; 
	
	// Use this for initialization
	void Start () {
		
		//will get the Animator component that is already on the player and make avail to script and assign it to anim. Now we can control that animator
		anim = GetComponent<Animator>();
	}
	
	//A fixedupdate occurs a set amount of times every second...usually use this when need to use Physics
	//The circle is defined by its center coordinate in world space & by its radius. LayerMask allows the test to check only for objects on specific layers.
	void FixedUpdate() {
	
		//find out whether it is grounded or not with OverlapCircle which is used to check if a collider falls within a circular area
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//if grounded then doubleJumped is false because he hasn't double jumped yet since he is on the ground
		if(grounded){
		
			doubleJumped = false;
		
		}
		
		//set grounded true or false
		//Grounded is a parameter in the animator in unity. grounded variable was used in FixedUpdate so we already figure out what value is.
		anim.SetBool ("Grounded", grounded);
		
		//if spacebar is pressed down add && grounded to make sure you are the ground before jumping
		if(Input.GetKeyDown(KeyCode.Space) && grounded){
		
			//call jump()
			Jump();
			
		}
		
		//if spacebar is pressed down add && not doubleJumped && not grounded (so if he is in the air AND he has NOT double jumped already)
		if(Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded){
			
			//call jump()
			Jump();
			//set doubleJumped to true
			doubleJumped = true;
			
			
		}
		
		//set moveVelocit to 0f
		moveVelocity = 0f;
		
		//if Right Arrow is pressed down
		if(Input.GetKey(KeyCode.RightArrow)){
			
			//Go to right a moveSpeed set above
			//GetComponent<Rigidbody2D> ().velocity  = new Vector2(moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			moveVelocity = moveSpeed;
		}
		
		//if Left Arrow is pressed down
		if(Input.GetKey(KeyCode.LeftArrow)){
			
			//Go to left a moveSpeed set above
			//gameObject.GetComponent<Rigidbody2D> ().velocity  = new Vector2(-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			moveVelocity = -moveSpeed;
		}
		
		//we don't want the enemy to push player around any more  so say the knockBack Count is .5 seconds...after that countdown then the
		//player will be able to move again. By default it will be 0 anyways. You'll always be able to move the player until he gets knocked in to
		if(knockBackCount <= 0){
		
		//move with the direction and velocity set
		GetComponent<Rigidbody2D> ().velocity  = new Vector2(moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);
		
		} else{
		
			if(knockFromRight){ //means our enemy is on our right & we want to knock our player to the left
				//set the player to move left and to move up a bit
				GetComponent<Rigidbody2D> ().velocity  = new Vector2(-knockBack, knockBack);
			}
			if(!knockFromRight){ //means our enemy is on our left & we want to knock our player to the right
				//set the player to move right and to move up a bit
				GetComponent<Rigidbody2D> ().velocity  = new Vector2(knockBack, knockBack);
			}
			//make our countdown work
			knockBackCount -= Time.deltaTime;
		}
		
		//How do we know when to use animator - well when velocity is NOT 0, that means we are moving
		//this will tell us what speed he is going..Math.Abs will take the - sign off of it if there is one.
		anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
		
		//make player flip depending on which direction he is going
		//if player's velocity is greater than 0, then we know the player is moving right
		if(GetComponent<Rigidbody2D>().velocity.x > 0){
			//localScale is the size of the player...if player is moving right than keep it the same exact way it was
			transform.localScale = new Vector3(1f,1f,1f);
		} else if  (GetComponent<Rigidbody2D >().velocity.x < 0){ // if player's velocity is less than 0
			//when x is -1, you are flipping the player - yay!
			transform.localScale = new Vector3(-1f,1f,1f);
		}
		
		//if hit return key then...
		if(Input.GetKeyDown (KeyCode.Return)){
		
			//ninjaStar should be created at the firePoint variable position
			Instantiate (ninjaStar, firePoint.position, firePoint.rotation);
			
			shotDelayCounter = shotDelay;
		}
		
		//if press return key and keep it down
		if(Input.GetKey(KeyCode.Return)){
			//count down the time between now and the last frame that happened, so 1 second...so it will gradually count down
			shotDelayCounter -= Time.deltaTime;
			if(shotDelayCounter <= 0){
				//once it hits zero, we want it to go back to 1
				shotDelayCounter = shotDelay;
				//And also fire another Ninja Star...should be created at the firePoint variable position
				Instantiate (ninjaStar, firePoint.position, firePoint.rotation);
			}
		}
		//Since sword anim should only last one frame, if sword is true, set to false
		if(anim.GetBool("Sword")== true){
			//set "Sword" to false
			anim.SetBool("Sword", false);
		}
		
		//if press L key...
		if(Input.GetKey(KeyCode.L)){
			//set animation boolean value for sword to true...only for one frame
			anim.SetBool("Sword", true);
		}
	}
	
	//Jump
	void Jump() {
	
		//speed from left to right of player is set to upwards velocity of jumpheight
		GetComponent<Rigidbody2D> ().velocity  = new Vector2(GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
	
	}
}
