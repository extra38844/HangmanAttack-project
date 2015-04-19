using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
	
	public float speed = 0.0f;
	public Renderer rend;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		//move the background horizontally
		Vector2 offset = new Vector2(Time.time * speed, 0);
		//will make it so the background keeps moving
		rend.material.mainTextureOffset = offset;
		
	}
}