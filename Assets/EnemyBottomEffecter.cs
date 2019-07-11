using UnityEngine;
using System.Collections;

public class EnemyBottomEffecter : MonoBehaviour {
	GameObject block;
	Collider2D blockCollider;
	void start(){
	}
	
	private void OnTriggerEnter2D(Collider2D other){

		if( other.gameObject.tag == "Enemy"){
			blockColliderManager(true);
		}
	}

	void blockColliderManager(bool tf){
		block = transform.parent.gameObject;
		blockCollider = block.GetComponent<BoxCollider2D>();
		blockCollider.isTrigger = tf;
	}
}