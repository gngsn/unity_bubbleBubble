using UnityEngine;
using System.Collections;

public class TreasureScore : MonoBehaviour {
	public string color;
	public int score;
	public AudioClip ItemFX;

	Sprite sprite;
	GameObject scoreObject;
	

	void Start () {
		scoreObject = GameObject.FindWithTag("ScoreManager");
		sprite = Resources.Load<Sprite>("treasureScore/"+color);
		if( color == "ultra" ){
			gameObject.GetComponent<CircleCollider2D>().enabled = false;
			StartCoroutine("startDelay");
		}
	}
	IEnumerator startDelay() {
		yield return new WaitForSeconds(1.0f);
		gameObject.GetComponent<CircleCollider2D>().enabled = true;
	}
		

	void OnTriggerEnter2D(Collider2D other){
		if( other.gameObject.tag == "Player" ){
			gameObject.GetComponent<Animator>().enabled= false;
			gameObject.GetComponent<CircleCollider2D>().enabled = false;
			audio.PlayOneShot(ItemFX);
			SpriteRenderer render = gameObject.GetComponent<SpriteRenderer>();
			render.sprite = sprite;
			rigidbody2D.velocity = (new Vector2(0.0f, 1.0f) * 3.0f);
			StartCoroutine("destroy");
			scoreObject.SendMessage("SetScore", score);
		}
	}

	IEnumerator destroy() {
		yield return new WaitForSeconds(0.6f);
		if( color == "ultra" ){
			GameObject.Find("Character").SendMessage("ClearGame");
		} else {
			transform.parent.gameObject.GetComponent<ItemCounter>().destroy();
		}
		Destroy(gameObject);
	}

	
}
