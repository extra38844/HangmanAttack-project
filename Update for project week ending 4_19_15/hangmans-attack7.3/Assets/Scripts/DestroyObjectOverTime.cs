using UnityEngine;
using System.Collections;

public class DestroyObjectOverTime : MonoBehaviour {

	public float lifeTime;
	
	// Use this for initialization
	void Start () {
	
	}
	
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
