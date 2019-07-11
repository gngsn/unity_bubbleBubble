using UnityEngine;
using System.Collections;

public class ThirdRoundZenchanAngry : MonoBehaviour {

	public LayerMask whatIsGround;
	public Transform groundCheck;
	public GameObject lockedPrefab;
	public float jumpForce;
	public float maxSpeed;
	public int movementFlag;
	float groundRadius = 0.5f;
	Animator anim;
	bool grounded = false;
	Vector3 moveVelocity;

	bool facingRight = true;

	void Start () {
		anim = GetComponent<Animator>();
	}	
	
	void Update () {
		renderer.material.color = Color.red * Mathf.Abs(Mathf.Sin(60.0F * Time.time + 0.2F));
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool("Ground", grounded);
		// Debug.Log(movementFlag);

		checkEdge();


		if ( movementFlag == 1 && grounded){
			moveVelocity = Vector3.left;
			facingRight = false;
			Flip();
			rigidbody2D.velocity = moveVelocity * maxSpeed;
		} else if ( movementFlag == 2 && !grounded) {
			moveVelocity = new Vector3(0, -1 ,0);
			rigidbody2D.velocity = moveVelocity * maxSpeed;
		}
		else if ( movementFlag == 0 && grounded ) {
			moveVelocity = Vector3.right;
			facingRight = true;
			Flip();
			rigidbody2D.velocity = moveVelocity * maxSpeed;
		} else if ( movementFlag == 3 && grounded ) {
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
			// moveVelocity = Vector3.up;
			anim.SetBool("Ground", false);
		}	
	}	
	
	void checkEdge(){
		Vector2 ps = transform.position;
		if( ps.x < -27F || (ps.y < -17.4 && ps.x < 7.3f) ){
			movementFlag = 0;
		} else if( ps.x > 27F || ( ps.y < -17.4f && ps.x > 16.3f ) ){
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
