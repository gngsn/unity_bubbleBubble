using UnityEngine;
using System.Collections;


public class BubbleToItem : MonoBehaviour {
	public Vector2 direction;
	public int count = 4;
	[HideInInspector]
	public bool isGround = false;
	public GameObject ItemPrefab;
	bool changeItem = false;
	
	Rigidbody2D rb;
	Vector3 prevPosition;
	Vector3 firstPosition;
	float angle;
	bool timeOut = false;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		firstPosition = transform.position;
		throwItem();
		StartCoroutine("timer");
	}

	IEnumerator timer() {
		yield return new WaitForSeconds(2.0f);
		rb.velocity = new Vector2( 0f, -1.0f ) * 40.0f;
		timeOut = true;
	}

	
	void Update () {
		checkEdge();
		if ( !changeItem ) {
			Vector3 deltaPos = transform.position - prevPosition;
			angle = Mathf.Atan2( deltaPos.x, deltaPos.y) * Mathf.Rad2Deg;
			if( 0!= angle ){
				prevPosition = transform.position;
			}
		}		
	}

	void checkEdge(){
		Vector2 ps = transform.position;
		if( ps.x < -28F || ps.x > 28F){
			direction = (firstPosition - transform.position).normalized * 3.0f;
			if( timeOut ){
				rb.velocity = new Vector2( 0f, -1.0f ) * 40.0f;
			} else {
				throwItem();
			}
		} else if ( ps.y < -17 && timeOut ){
			change();
		} else if( ps.y > 14.0F || ps.y < -17 ){
			direction = (firstPosition - transform.position).normalized * 3.0f;
			if( timeOut ){
				rb.velocity = new Vector2( 0f, -1.0f ) * 40.0f;
			} else {
				throwItem();
			}
		}
	}

	void throwItem(){
		rb.velocity = direction * 60.0f;
	}

	void OnTriggerEnter2D(Collider2D other){
		if( other.gameObject.tag == "EnemyBlock"){
			if ( count > -1 ){
				count--;
				return;
			}
			Vector3 pos = other.gameObject.transform.position;
			transform.position = new Vector3(transform.position.x, pos.y + 1.0f, pos.z - 0.1f);
			change();			
		}
	}

	void change() {
		isGround = true;		
		rb.velocity =  new Vector2(0.0f, 0.0f);
		changeItem = true;
		rb.gravityScale = 0;
			
		Instantiate(ItemPrefab, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}


}
