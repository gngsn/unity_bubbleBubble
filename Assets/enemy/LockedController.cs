using UnityEngine;
using System.Collections;

public class LockedController : MonoBehaviour {

	public LayerMask whatIsCollision;
	public GameObject respwanPrefab;
	public GameObject ItemPrefab;
	public float respwanTime;
	ScoreKeeper enemyController;
	GameObject respwan;
	Vector3 direction;
	float initialVelocity;
	Animator anim;
	
	// Use this for initialization
	void Start () {
		// direction = (new Vector3( 0, 10.0F , 0.0F) - transform.position).normalized;
		direction = new Vector3(0, 1, 0);
		initialVelocity = 4f;
		anim = GetComponent<Animator>();
		GameObject score = GameObject.Find("ScoreBar");
		enemyController = score.GetComponent<ScoreKeeper>(); 
		gameObject.GetComponent<CircleCollider2D>().enabled = true;
	}
	void Update () {
		checkEdge();
		rigidbody2D.velocity = direction * initialVelocity;
		StartCoroutine("destroy", respwanTime);
	}

	void OnTriggerEnter2D(Collider2D other){
		if( other.gameObject.tag == "Player"){
			anim.SetBool("isDestroy", true);
			enemyController.SendMessage("CountKillEnemy");
			Instantiate(ItemPrefab, transform.position, Quaternion.Euler(0, 180.0f, 0));
			Destroy(gameObject);
		}
	}

	IEnumerator destroy(float time) {
		yield return new WaitForSeconds(time);

		Destroy(gameObject);
		respwan = Instantiate(respwanPrefab, new Vector3(transform.position.x, transform.position.y, 0.01F), Quaternion.identity) as GameObject;
		respwan.rigidbody2D.velocity = new Vector3( 0, -1, 0);
	}

	void checkEdge(){
		Vector2 ps = transform.position;
		if( ps.x < -27F ){
			initialVelocity = 1.0F; 
		} else if( ps.x > 27F ){
			initialVelocity = 1.0F; 
		} 
		if( ps.y > 14.0F ){
			initialVelocity = -0.5F; 
		}
	}

}
