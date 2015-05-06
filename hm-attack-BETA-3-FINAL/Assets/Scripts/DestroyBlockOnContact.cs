/// <summary>
/// Destroy Block On Contact.
/// Description of Class - If you hit the block with this object then you destroy the block.
/// </summary>

using UnityEngine;
using System.Collections;

public class DestroyBlockOnContact : MonoBehaviour {

	//if you hit anything that has the 'Ground' tag with this object, it will break	
	void OnTriggerEnter2D(Collider2D other) {
		//all objects with the tag "Ground"
		if(other.tag == "Ground"){
			//destroy it when collide with ground
			Destroy (other.gameObject);
		}
		
	}
}
