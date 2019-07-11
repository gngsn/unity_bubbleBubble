using UnityEngine;
using System.Collections;

public class BubbleCollisionController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		float parentVelocity = gameObject.transform.parent.gameObject.rigidbody2D.velocity.x;
		
		if( other.gameObject.tag == "Enemy" && (parentVelocity > 30f || parentVelocity < -30f)){
			other.gameObject.SendMessage("Locked");
			Destroy(gameObject.transform.parent.gameObject);
		}
		
	}
}
