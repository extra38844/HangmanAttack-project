/// <summary>
/// Destroy Object Over Time.
/// Description of Class - Destroy objects after a certain period of time so objects aren't just lingering.
/// </summary>

using UnityEngine;
using System.Collections;

public class DestroyObjectOverTime : MonoBehaviour {

	//decide on what the lifetime of the object should be
	public float lifeTime;
	
	// Update is called once per frame
	void Update () {
	
		//Make a lifetime countdown
		lifeTime -= Time.deltaTime;
		//if lifeTime is less than 0 then ...
		if(lifeTime < 0) {
			//destroy the object
			Destroy (gameObject);
		}
	}
}
