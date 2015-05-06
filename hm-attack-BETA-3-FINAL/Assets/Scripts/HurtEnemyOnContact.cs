/// <summary>
/// Hurt Enemy On Contact.
/// Description of Class - Hurt the Enemy when come in contact with the object that has the script attached.
/// </summary>

using UnityEngine;
using System.Collections;

public class HurtEnemyOnContact : MonoBehaviour {
	
	//How much damage to give the enemy
	public int damageToGive;
	//How much bounce back to put on enemy when comes in contact with this object
	public float bounceOnEnemy;
	//the headstomper doesn't have a rigidbody, the player does
	private Rigidbody2D myRigidBody2D;
	
	// Use this for initialization
	void Start () {
	
		//so find parent object of headStomper and then go get component rigidbody2D
		myRigidBody2D = transform.parent.GetComponent<Rigidbody2D>();
	}
	
	//when colliding with other
	void OnTriggerEnter2D(Collider2D other) {
		//make sure that the other is tagged as "Enemy"
		if(other.tag == "Enemy"){
			//find EnemyHealthManager and give damage because we just bonked his head
			other.GetComponent<EnemyHealthManager>().giveDamage (damageToGive);
			//Add velocity to player in order to make him bounce when he jumps on enemy's head. x stays the same, y is bounce value
			myRigidBody2D.velocity = new Vector2(myRigidBody2D.velocity.x, bounceOnEnemy);
		}
		
	}
}
