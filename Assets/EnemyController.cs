using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	ZenchanController zenchanController;
	void Start () {
		StartCoroutine("startDelay");
	}
	
	IEnumerator startDelay() {
		foreach (Transform child in transform){
			child.GetComponent<Collider2D>().isTrigger = true;
			child.rigidbody2D.velocity = new Vector2(0, 0);
			child.rigidbody2D.gravityScale = 0;
		}
		yield return new WaitForSeconds(2.8f);
		foreach (Transform child in transform){
			child.GetComponent<ZenchanController>().maxSpeed = 12; 
			child.GetComponent<ZenchanController>().movementFlag = 2;
			child.rigidbody2D.gravityScale = 1;
			child.GetComponent<Collider2D>().isTrigger = false;
		}
		transform.DetachChildren();
      	Destroy(gameObject);


	}
}
