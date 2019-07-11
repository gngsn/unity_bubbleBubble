using UnityEngine;
using System.Collections;

public class PuruRespwanController : MonoBehaviour {
	Vector3 direction; 
	public float initialVelocity;
	public GameObject lockedPrefab;
	float angle;
	
	void Start () {
		gameObject.	name = "Puru";
		direction = new Vector3( 1,1,0);
		throwItem();
	}
	void Update() {
		renderer.material.color = Color.red * Mathf.Abs(Mathf.Sin(60.0F * Time.time + 0.2F));
		if( transform.position.y > 14.0F ){ 
			direction = new Vector3( -1, -1, 0);
			rigidbody2D.velocity = direction * initialVelocity;
		}
	}

	void throwItem(){
		rigidbody2D.velocity = direction * initialVelocity;
	}

	void Locked() {
		Instantiate( lockedPrefab, new Vector3(transform.position.x, transform.position.y, 0.01F), Quaternion.identity);
		Destroy(gameObject);
	}
}
