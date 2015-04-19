using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public PlayerController player;
	//is it following the player?
	public bool isFollowing;
	//allow use to set position of camera
	public float xOffset;
	public float yOffset;
	
	
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
