/// <summary>
/// Camera controller.
/// Description of Class - Controls camera behavior in relation to player. Is camera following player and at what distance
/// </summary>


using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {//inherits Monobehavior

	private PlayerController player;
	//is it following the player?
	private bool isFollowing;
	//allow user to set position of camera
	private float xOffset;
	private float yOffset;


	public CameraController()
	{
		isFollowing = true;
		xOffset = 0;
		yOffset = 0;
	}

	public string toString()
	{
		return ("Is Camera Following "+isFollowing+" xOffSet is "+xOffset+ " yOffset is " +yOffset);
	}

	//Set and get if camera is following player
	public bool getIsFollowing()
	{
		return isFollowing;
	}

	public void setIsFollowing(bool isFollowing)
	{
		this.isFollowing = isFollowing;
	}

	//set and get if there is space between camera and player when following
	public float getXOffset()
	{
		return xOffset;
	}

	public void SetXOffSet(float xOffset)
	{
		this.xOffset = xOffset;
	}

	public float getYOffset()
	{
		return yOffset;
	}
	
	public void SetYOffSet(float yOffset)
	{
		this.yOffset = yOffset;
	}
	
	
	// Use this for initialization
	void Start () {
		//will look for objects with PlayerController attached to it and since
		//only 1 object has this (the player), we know it is the player
		player = FindObjectOfType<PlayerController>();
		//set isFollowing to true since it is the start of game
		isFollowing = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(isFollowing){
			//set the position of the camera. Set it to be the players position for x and y and then cameras current position for z
			transform.position = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, transform.position.z);

		}
	}
}
