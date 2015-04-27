using UnityEngine;
using System.Collections;

public class DestroyFinishedParticle : MonoBehaviour {

	//creates an empty particle system within this script
	private ParticleSystem thisParticleSystem;
	
	// Use this for initialization
	void Start () {
	
		//search for particle system that object is already attached to 
		thisParticleSystem = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (thisParticleSystem.isPlaying) {
		
			//we don't need code to do anything if the particle system is playing
			return;
		}  else {
		
			//Destroy gameObject
			Destroy (gameObject);
		
		}
	}
	
	//fix a bug in the particle system - if ps goes off screen, it completely destroys it
	void OnBecameInvisible(){
	
		//Destroy Particle system object
		Destroy (gameObject);
	
	}
}
