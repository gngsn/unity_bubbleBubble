using UnityEngine;
using System.Collections;

public class bubblunController : MonoBehaviour {
	public GameObject bubblePrefab;
	public GameObject bub_lockedPrefab;
	public AudioClip shootFX;
	Animator anim;
	[HideInInspector]
	public bool damage = false;
	bool once = true;
	Vector3 direction;
	CharacterMovement character;
	Vector3 pos;
	
	void Start () {
		// transform.position = new Vector3(-23.5f, -17f, -1f);
		anim = GetComponent<Animator>();
		character = gameObject.GetComponent<CharacterMovement>();
	}

	void Update () {
		if( Input.GetKeyDown(KeyCode.Space) && damage == false){
			anim.CrossFade("bubblun_shoot", 0.3F);
			audio.PlayOneShot(shootFX);
			Instantiate(bubblePrefab, new Vector3(transform.position.x, transform.position.y, 0.01F), Quaternion.identity);
		}
	}

	public void resetToNextStage(bool isNextStage) {
		anim.SetBool("isNextStage", isNextStage);
		if ( once && isNextStage ){
			character.damage = true;
			gameObject.GetComponent<CharacterMovement>().damage = true;
			GameObject bub = Instantiate(bub_lockedPrefab, transform.position, Quaternion.identity) as GameObject;
			bub.transform.parent = gameObject.transform;
			rigidbody2D.AddForce(new Vector2(0, 0));
			rigidbody2D.velocity = new Vector2(0,0);
			gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
			once = !once;
		}
		pos = transform.position;
		if ( transform.position.x == -23.5f ){
			pos = transform.position;
			transform.position = Vector2.MoveTowards( pos, new Vector3( -23.5f, -17f, -1f), 10f * Time.deltaTime);
		} else {
			transform.position = Vector2.MoveTowards( pos, new Vector3(-23.5f, pos.y, -1f), 15f * Time.deltaTime);
		}
	}
}
