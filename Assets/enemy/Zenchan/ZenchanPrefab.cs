using UnityEngine;
using System.Collections;

public class ZenchanPrefab : MonoBehaviour {

	public LayerMask whatIsGround;
	public Transform groundCheck;
	public GameObject lockedPrefab;

	public float groundRadius;
	Animator anim;
	bool grounded = true;
	int movementFlag = 1;
	Vector3 moveVelocity;
	public float maxSpeed;

	bool facingRight = true;

	void Start () {
		maxSpeed = 6; 
		moveVelocity = new Vector3( 0, -10.0F , 0.01F);
		anim = GetComponent<Animator>();
		if(groundRadius == 0){
			groundRadius = 0.3f;
		}
	}
	
	void Update () {

		checkEdge();

		renderer.material.color = Color.red * Mathf.Abs(Mathf.Sin(60.0F * Time.time + 0.2F));
		if( gameObject.transform.position.y > -16.0 ){
			gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
		} else {
			gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
			moveVelocity = Vector3.right;
			maxSpeed = 200;
		}

		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool("Ground", grounded);

		if ( movementFlag == 1 && grounded){
			moveVelocity = Vector3.left;
			facingRight = false;
			Flip();
		} 
		else if ( movementFlag == 0 && grounded ) {
			moveVelocity = Vector3.right;
			facingRight = true;
			Flip();
		}
		rigidbody2D.velocity = moveVelocity * maxSpeed;
	
	}

	void checkEdge(){
		Vector2 ps = transform.position;
		if( ps.x < -27F ){
			movementFlag = 0;
		} else if( ps.x > 27F ){
			movementFlag = 1;
		}
	}

	void Locked() {
		Instantiate( lockedPrefab, new Vector3(transform.position.x, transform.position.y, 0.01F), Quaternion.identity);
		Destroy(gameObject);
	}

// facing == 0 : right, facing == 1 : left, facing == 2 : down 
	void facingControl(int facing) {
		movementFlag = facing;
	}


	void Flip()
	{
		Vector3 theScale = transform.localScale;
		if( (facingRight == true && theScale.x < 0) || (facingRight == false && theScale.x > 0) ) {
			theScale.x *= -1;
		}
		transform.localScale = theScale;
	}
}
