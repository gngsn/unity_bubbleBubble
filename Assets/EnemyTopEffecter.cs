using UnityEngine;
using System.Collections;

public class EnemyTopEffecter : MonoBehaviour {
	GameObject block;
	Collider2D blockCollider;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter2D(Collider2D other){
		if( other.gameObject.tag == "Enemy"){
			blockColliderManager(false);
		}
	}

	void blockColliderManager(bool tf){
		block = transform.parent.gameObject;
		blockCollider = block.GetComponent<BoxCollider2D>();
		blockCollider.isTrigger = tf;
	}
}