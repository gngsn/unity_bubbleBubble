using UnityEngine;
using System.Collections;

public class InvaderHeadController : MonoBehaviour {
	// public GameObject lockedPrefab;
	// GameObject invader_head;
	void Start(){
		
	}
	// void OnCollisionEnter2D(Collision2D coll){
	// 	if( coll.gameObject.tag == "Bubble"){
	// 		// Locked();
	// 	}
	// }

	void Update() {
		// transform.position = invader_head.transform.position;
	}
	
	void Locked() {
		// Destroy(invader_head);
		Destroy(gameObject);
	}
}