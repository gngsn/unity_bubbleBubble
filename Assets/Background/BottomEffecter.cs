using UnityEngine;
using System.Collections;

public class BottomEffecter : MonoBehaviour {
	GameObject block;
	Collider2D blockCollider;
	
	private void OnTriggerEnter2D(Collider2D other){
		if( other.gameObject.tag == "Player"){
			blockColliderManager(true);
			// Physics2D.IgnoreCollision(other.GetComponent<CircleCollider2D>(), transform.parent.GetComponent<BoxCollider2D>());
			// Physics2D.IgnoreCollision (other.gameObject.Collider2D, transform.parent.gameObject.Collider2D
		}
	}

	void blockColliderManager(bool tf){
		block = transform.parent.gameObject;
		blockCollider = block.GetComponent<BoxCollider2D>();
		blockCollider.isTrigger = tf;
	}	
}
