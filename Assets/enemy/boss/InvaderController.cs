using UnityEngine;
using System.Collections;

public class InvaderController : MonoBehaviour {
	public GameObject lockedPrefab;
	void Start(){
		rigidbody2D.WakeUp();
	}
	void OnCollisionEnter2D(Collision2D coll){
		if( coll.gameObject.tag == "Bubble"){
			Locked();
		}
	}
	void Locked() {
		Instantiate( lockedPrefab, new Vector3(transform.position.x, transform.position.y, 0.01F), Quaternion.identity);
		Destroy(gameObject.transform.parent);
	}
}
