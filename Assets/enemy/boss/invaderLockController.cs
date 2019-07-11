using UnityEngine;
using System.Collections;

public class invaderLockController : MonoBehaviour {
	public GameObject DiePrefab;
	public GameObject treasurePrefab;
	ScoreKeeper enemyController;
	Vector3 direction;
	float initialVelocity;
	SpriteRenderer render;
	public Sprite sprite;
	GameObject scoreObject;
	bool isScore = false;

	void Start () {
		render = gameObject.GetComponent<SpriteRenderer>();
		// direction = (new Vector3( 0, 10.0F , 0.0F) - transform.position).normalized;
		direction = new Vector3(0, 1, 0);
		initialVelocity = 4f;
		enemyController = GameObject.Find("ScoreBar").GetComponent<ScoreKeeper>(); 
		scoreObject = GameObject.FindWithTag("ScoreManager");
	}
	void Update () {
		checkEdge();
		rigidbody2D.velocity = direction * initialVelocity;
	}

	void OnTriggerEnter2D(Collider2D other){
		if( other.gameObject.tag == "Player"){
			enemyController.SendMessage("CountKillEnemy");

			GameObject die = Instantiate(DiePrefab, transform.position, Quaternion.identity) as GameObject;
			die.GetComponent<Rigidbody2D>().AddForce(new Vector3(1,1,0)* 1500f);

			Instantiate(treasurePrefab);

			GetComponent<CircleCollider2D>().enabled = false;
			GetComponent<Animator>().enabled = false;
			render.sprite = sprite;
			isScore = true;
			initialVelocity = 5.0f;
			StartCoroutine("destroy");
			scoreObject.SendMessage("SetScore", 128000);
		}
	}

	IEnumerator destroy() {
		yield return new WaitForSeconds(1.0f);
		Destroy(gameObject);
	}

	void checkEdge(){
		Vector2 ps = transform.position;
		if( ps.x < -27F ){
			initialVelocity = 1.0F; 
		} else if( ps.x > 27F ){
			initialVelocity = 1.0F; 
		}
		if( ps.y > 8.5f && !isScore){
			initialVelocity = -0.5F; 
		}
	}

}
