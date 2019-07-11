using UnityEngine;
using System.Collections;

public class treasureOpenController : MonoBehaviour {
	public GameObject ultraPrefab;
	bool once = true;

	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Player" && once ){
			GetComponent<Animator>().SetBool("Open", true);
			Destroy(GameObject.Find("treasure_key"));
			Instantiate(ultraPrefab);
			once = false;
		}
	}
}
