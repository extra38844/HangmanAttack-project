using UnityEngine;
using System.Collections;

public class CameraControllerUI : MonoBehaviour {
	//camera controller for the UI

	//allow use to set position of camera
	public float xOffset;
	public float yOffset;
	
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

			//set the position of the camera. Set it to be the players position for x and y and then cameras current position for z
			transform.position = new Vector3(transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z);
	}
}
