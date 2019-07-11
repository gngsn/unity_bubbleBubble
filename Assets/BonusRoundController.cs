using UnityEngine;
using System.Collections;

public class BonusRoundController : MonoBehaviour {
	Animator anim;
	string nextScene; 

	void Start () {
		anim = GetComponent<Animator>();
		GameObject.Find("ScoreBar").SendMessage("SaveData");
	}

	
	void OnTriggerEnter2D(Collider2D other){
		if( other.gameObject.tag == "Player"){
			anim.SetBool("enter", true);
			GameObject.Find("ScoreBar").SendMessage("SaveData");
			StartCoroutine("endDelay");
		}
	}

	void SetNextScene(string next){
		nextScene = next;
	}

	IEnumerator endDelay() {
		yield return new WaitForSeconds(2.0f);
		Application.LoadLevel(nextScene);
	}
}
