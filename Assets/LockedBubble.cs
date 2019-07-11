using UnityEngine;
using System.Collections;

public class LockedBubble : MonoBehaviour {
	Animator anim;
	GameObject player;
	CharacterMovement MoveScript;

	void Start () {
		// transform.position = Vector2.MoveTowards( pos, new Vector3( -23.5f, -17f, -1f), 10f * Time.deltaTime);
		player = GameObject.FindWithTag("Player") as GameObject;
		MoveScript = player.GetComponent<CharacterMovement>();
		MoveScript.damage = true;
		player.GetComponent<bubblunController>().damage = true;
		player.rigidbody2D.gravityScale = 0;
		player.GetComponent<CircleCollider2D>().isTrigger = true;
		anim = player.GetComponent<Animator>();
		StartCoroutine("destroyDelay");
	}

	IEnumerator destroyDelay() {
		yield return new WaitForSeconds(2.3f);
		player.transform.parent = null;
		anim.SetBool("isNextStage", false);
		MoveScript.damage = false;
		player.GetComponent<bubblunController>().damage = false;
		player.GetComponent<CircleCollider2D>().isTrigger = false;
		player.rigidbody2D.gravityScale = 1.0f;
		MoveScript.groundRadius = 0.2f;
		Destroy(gameObject);
	}

	void Update() {
		if( MoveScript.damage ){
			MoveScript.groundRadius = 100f;
			anim.SetBool("isNextStage", true);
		}
		
	}
}
