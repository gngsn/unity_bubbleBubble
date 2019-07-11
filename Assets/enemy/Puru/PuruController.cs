using UnityEngine;
using System.Collections;

public class PuruController : MonoBehaviour {
	Vector3 direction; 
	public float initialVelocity;
	public GameObject lockedPrefab;
	
	void Start () {
		direction = new Vector3( 1,1,0);
		rigidbody2D.velocity = direction * initialVelocity;
	}

	void Locked() {
		Instantiate( lockedPrefab, new Vector3(transform.position.x, transform.position.y, 0.01F), Quaternion.identity);
		Destroy(gameObject);
	}
}
