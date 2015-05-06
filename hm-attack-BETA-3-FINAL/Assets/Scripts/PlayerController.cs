/// <summary>
/// Player Controller.
/// Player controller defines all movement controls in the game. Some of these are defined directly and others are connecting to the Unity input manager.
/// Allows for Controlling via keyboard, Stick and button controls for a gamepad, or virtual stick and touch (these are also mouse compatible)
/// </summary>


using UnityEngine;
using System.Collections;
using InControl;

public class PlayerController : MonoBehaviour {
	
	//variables
	public float moveSpeed;
	private float moveSpeedVar;
	public float jumpHeight;
	//A Transform is basically a point in space
	public Transform groundCheck;
	//how big the circle you make needs to be in order to determine if you are on the ground
	public float groundCheckRadius;
	//True that player IS on the ground or False the player is NOT on the ground
	public LayerMask WhatIsGround;
	private bool grounded;
	public float moveVelocity;
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

	MyCharacterActions characterActions;//preparing for new object in Start
	// Use this for initialization
	void Start () {
		
		//will get the Animator component that is already on the player and make avail to script and assign it to anim. Now we can control that animator
		anim = GetComponent<Animator>();

		characterActions = new MyCharacterActions();//creates new characterAction Object from PlayerActionScript binding the touch uttons to Jump and Fire

		characterActions.Jump.AddDefaultBinding( InputControlType.Action1 );
		characterActions.Fire.AddDefaultBinding( InputControlType.Action2 );

	}
	
	
	//A fixedupdate occurs a set amount of times every second...usually use this when need to use Physics
	//The circle is defined by its center coordinate in world space & by its radius. LayerMask allows the test to check only for objects on specific layers.
	void FixedUpdate() {
		
		//find out whether it is grounded or not with OverlapCircle which is used to check if a collider falls within a circular area
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		// Use last device which provided input.
		var inputDevice = InputManager.ActiveDevice;
		
		moveSpeedVar = moveSpeed;
		
		
		
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
		
		//if the player is on the ground, pressing the jump button will jump
		if(Input.GetButtonDown("Jump") && grounded){
			
			//call jump()
			Jump();
			
		}


		//Jump with touch button
		if (characterActions.Jump.WasPressed && grounded)
		{
			Jump();
		}

		//if in the air already from one jump double jump
		if (characterActions.Jump.WasPressed && !doubleJumped && !grounded)
		{
			Jump();
			//set doubleJumped to true
			doubleJumped = true;
		}





		
		//if spacebar is pressed down add && not doubleJumped && not grounded (so if he is in the air AND he has NOT double jumped already)
		if(Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded){
			
			//call jump()
			Jump();
			//set doubleJumped to true
			doubleJumped = true;
			
			
		}
		//if player is in the air and has jumped once then the jump button will do a second in air jump
		if(Input.GetButtonDown("Jump") && !doubleJumped && !grounded){
			
			//call jump()
			Jump();
			//set doubleJumped to true
			doubleJumped = true;
			
			
		}
		

		
		
		
		//if Ctrl Key pressed then increase speed
		if((Input.GetKey(KeyCode.RightControl)) || (Input.GetKey(KeyCode.LeftControl))){
			
			//Go to left a moveSpeed set above
			//gameObject.GetComponent<Rigidbody2D> ().velocity  = new Vector2(-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			moveSpeedVar = moveSpeed + 5.0f;
		}
		
		//set moveVelocit to 0f
		moveVelocity = 0f;
		//If there is Joystick movement to the right, move right
		if(Input.GetAxis("Horizontal")>0)
			//var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
			//transform.position += move * moveSpeedVar * Time.deltaTime;
			moveVelocity = moveSpeedVar;
		
		//If there is Joystick movement to the left, move left
		if(Input.GetAxis("Horizontal")<0)
			//var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
			//transform.position += move * moveSpeedVar * Time.deltaTime;
			moveVelocity = -moveSpeedVar;
		
		//if Right Arrow is pressed down
		if(Input.GetKey(KeyCode.RightArrow)){
			
			//Go to right a moveSpeed set above
			//GetComponent<Rigidbody2D> ().velocity  = new Vector2(moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			moveVelocity = moveSpeedVar;
		}
		
		if (inputDevice.Direction.X > 0) {
			moveVelocity = moveSpeedVar;
		}
		
		if (inputDevice.Direction.X < 0) {
			moveVelocity = -moveSpeedVar;
		}
		
		
		
		//if Left Arrow is pressed down
		if(Input.GetKey(KeyCode.LeftArrow)){
			
			//Go to left a moveSpeed set above
			//gameObject.GetComponent<Rigidbody2D> ().velocity  = new Vector2(-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			moveVelocity = -moveSpeedVar;
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
		//If fire1 button is pressed and released
		if(Input.GetButtonDown("Fire1")){
			//ninjaStar should be created at the firePoint variable position
			Instantiate (ninjaStar, firePoint.position, firePoint.rotation);
			
			shotDelayCounter = shotDelay;
		}
		//Fire from touch action2 button
		if (characterActions.Fire.WasPressed)
		{
			//ninjaStar should be created at the firePoint variable position
			Instantiate (ninjaStar, firePoint.position, firePoint.rotation);
			
			shotDelayCounter = shotDelay;
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
		
		//if press fire button and keep it down
		if(Input.GetButton("Fire1")){
			//count down the time between now and the last frame that happened, so 1 second...so it will gradually count down
			shotDelayCounter -= Time.deltaTime;
			if(shotDelayCounter <= 0){
				//once it hits zero, we want it to go back to 1
				shotDelayCounter = shotDelay;
				//And also fire another Ninja Star...should be created at the firePoint variable position
				Instantiate (ninjaStar, firePoint.position, firePoint.rotation);
			}
		}
		//****SWORD DISABLED
		//Since sword anim should only last one frame, if sword is true, set to false
		//if(anim.GetBool("Sword")== true){
			//set "Sword" to false
		//	anim.SetBool("Sword", false);
		//}
		
		//if press L key...
		//if(Input.GetKey(KeyCode.L)){
			//set animation boolean value for sword to true...only for one frame
		//	anim.SetBool("Sword", true);
		//}
		//if press Fire2 button...
		//if(Input.GetButtonDown("Fire2")){
			//set animation boolean value for sword to true...only for one frame
		//	anim.SetBool("Sword", true);
		//}
		
	}
	
	//Jump
	void Jump() {
		
		//speed from left to right of player is set to upwards velocity of jumpheight
		GetComponent<Rigidbody2D> ().velocity  = new Vector2(GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
		
	}




}
