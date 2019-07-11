using UnityEngine;
using System.Collections;

public class BubbleController : MonoBehaviour {

	public LayerMask whatIsCollision;
	public float initialVelocity;

	Vector3 direction;
	GameObject player;
	Animator anim;
	bool facingRight;
	int isFlip = 0;
	bool startDelay = true;

	void Start () {
		anim = GetComponent<Animator>();
		gameObject.GetComponent<CircleCollider2D>().enabled = false;
		
		player = GameObject.FindGameObjectWithTag("Player");
		if( player.transform.localScale.x > 0 ){
			facingHandler(true);			
		}
		else {
			facingHandler(false);
		}
	}
	
	void Update () {
		checkEdge();
		rigidbody2D.velocity = direction * initialVelocity;

		StartCoroutine("shootingDelay");
		StartCoroutine("destroy", 4f);
	}

	void OnTriggerEnter2D(Collider2D other){
		if( other.gameObject.tag == "Player" && !startDelay ){
			anim.SetBool("isDestroy", true);
			StartCoroutine("destroy", 0.3f);
		} 
	}

	void facingHandler(bool facing){
		if(facing){
			facingRight = true;
			direction = new Vector2(1, 0);
		} else {
			facingRight = false;
			direction = new Vector2(-1, 0);
		}
	}
	
	void checkEdge(){
		Vector2 ps = transform.position;
		if( ps.x < -27F && isFlip < 7 && !facingRight ){
			facingHandler(!facingRight);
			isFlip++;
			initialVelocity = 1.0F; 
		} else if( ps.x > 27F && isFlip < 7 && facingRight){
			facingHandler(!facingRight);
			isFlip++;
			initialVelocity = 1.0F; 
		} 
		if( ps.y > 14.0F ){
			initialVelocity = -0.5F; 
		}
	}

	void Destroy(){
		anim.SetBool("isDestroy", true);
		Destroy(gameObject);
	}

	IEnumerator destroy(float time) {
		yield return new WaitForSeconds(time);
		Destroy(gameObject);
	}

	IEnumerator shootingDelay() {
		yield return new WaitForSeconds(0.3f);
		startDelay = false;
		direction = (new Vector3( transform.position.x, transform.position.y + 10.0F , 0.01F) - transform.position).normalized;
		initialVelocity = 4f;
		gameObject.GetComponent<CircleCollider2D>().enabled = true;
	}

}
