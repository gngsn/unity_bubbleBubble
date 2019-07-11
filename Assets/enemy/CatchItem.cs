using UnityEngine;
using System.Collections;

public class CatchItem : MonoBehaviour {
	BubbleToItem bubScript;
	public string resourcePath;
	public string scorePath;
	public int[] scores;
	public AudioClip ItemFX;

	SpriteRenderer render;
	// bool changeItem = false;
	Sprite[] sprites;
	int randomOffset;
	GameObject scoreObject;

	void Start () {
		render = gameObject.GetComponent<SpriteRenderer>();
		Sprite[] ItemSprites = Resources.LoadAll<Sprite>(resourcePath);
		int ItemRandomOffset = Random.Range(0, ItemSprites.Length);

		render.sprite = ItemSprites[ItemRandomOffset];

		scoreObject = GameObject.FindWithTag("ScoreManager");
		sprites = Resources.LoadAll<Sprite>(scorePath);
		randomOffset = Random.Range(0, sprites.Length);
	}

	void OnTriggerEnter2D(Collider2D other){
		if( other.gameObject.tag == "Player"){
			// render = gameObject.GetComponent<SpriteRenderer>();
			render.sprite = sprites[randomOffset];
			audio.PlayOneShot(ItemFX);
			rigidbody2D.velocity = (new Vector2(0.0f, 1.0f) * 3.0f);
			StartCoroutine("destroy");
			scoreObject.SendMessage("SetScore", scores[randomOffset]);
		}
	}

	IEnumerator destroy() {
		yield return new WaitForSeconds(1.0f);
		Destroy(gameObject);
	}
}
