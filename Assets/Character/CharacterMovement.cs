using UnityEngine;
using System.Collections;


public class CharacterMovement : MonoBehaviour {
	public float maxSpeed;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;
	public Transform groundCheck;
	public AudioClip jumpFX;
	public AudioClip damageFX;
	public AudioClip changeFX;
	[HideInInspector]
	public bool damage = false;
	public GameObject changePrefab;

	Animator anim;
	bool grounded = false;
	[HideInInspector]
	public float groundRadius = 0.2f;
	
	float move;
	bubblunController bubble;

	bool facingRight = true;
	Color originalColor;

	void Start () {
		// StartCoroutine("startDelay");
		originalColor = renderer.material.color;
		anim = GetComponent<Animator>();
		bubble = gameObject.GetComponent<bubblunController>();
	}
	
	void Update () {
		if( grounded && Input.GetKeyDown(KeyCode.UpArrow) && damage == false){
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
			audio.PlayOneShot(jumpFX);
			anim.SetBool("Ground", false);
			anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
		}
	}

	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool("Ground", grounded);
		if ( damage == false){
			move = Input.GetAxis("Horizontal");
			anim.SetFloat("Speed", Mathf.Abs(move));
			rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
		}

		if( move > 0 && !facingRight)
			Flip();
		else if ( move < 0 && facingRight)
			Flip();
	}


	void collideEnemy(){
		audio.PlayOneShot(damageFX);
		damage = true;
		maxSpeed = 5f;
		anim.SetFloat("Speed", 0.0f);
		anim.SetBool("Damage", true);
		StartCoroutine("destroy", 2.5f);
		bubble.damage = true;
	}

	IEnumerator startDelay() {
		damage = true;
		yield return new WaitForSeconds(2.5f);
		damage = false;

	}
	
	IEnumerator destroy(float time) {
		yield return new WaitForSeconds(time);
		anim.SetBool("Damage", false);
		StartCoroutine("respwan", 0.7f);
		transform.position = new Vector3(-24.0F, -17F, -2F);
		renderer.enabled = false;
	}

	IEnumerator respwan(float time) {
		yield return new WaitForSeconds(time);
		renderer.enabled = true;
		renderer.material.color = Color.white * Mathf.Abs(Mathf.Sin(30.0F * Time.time));
		StartCoroutine("show", 0.5f);
	}

	IEnumerator show(float time) {
		yield return new WaitForSeconds(time);
		damage = false;
		bubble.damage = false;
		renderer.material.color = originalColor;
		maxSpeed = 20f;
		GameObject.Find("EnemyCheck").GetComponent<CheckEnemyCollider>().sendMessageOnce = false;
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void ClearGame(){
		damage = true;
		anim.SetFloat("Speed", 0.0f);
		anim.SetBool("ClearGame", true);
		audio.PlayOneShot(changeFX);
		GameObject.Find("endingManager").SendMessage("end");
	}
}