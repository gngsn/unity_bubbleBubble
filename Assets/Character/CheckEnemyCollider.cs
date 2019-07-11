using UnityEngine;
using System.Collections;

public class CheckEnemyCollider : MonoBehaviour {
	[HideInInspector]
	public bool sendMessageOnce = false;
	ScoreKeeper lifeCheck;

	
	// Use this for initialization
	void Start () {
		GameObject scoreManager = GameObject.FindWithTag("ScoreManager");
		lifeCheck = scoreManager.GetComponent<ScoreKeeper>();
	}
	

	
	void OnTriggerEnter2D(Collider2D other){
		if( other.gameObject.layer == 12 && sendMessageOnce == false){
			sendMessageOnce = true;
			lifeCheck.SendMessage("CountKillCharacter");
			transform.parent.gameObject.SendMessage("collideEnemy");
		}
	}
}
