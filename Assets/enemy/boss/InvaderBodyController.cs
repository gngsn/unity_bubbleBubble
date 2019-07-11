using UnityEngine;
using System.Collections;

public class InvaderBodyController : MonoBehaviour {
	public GameObject lockedPrefab;
	GameObject invader_body;
	GameObject invader_head;
	Color originalColor;
	int hp = 150;

	void Start(){
		invader_body = GameObject.Find("boss_invader_body");
		invader_head = GameObject.Find("boss_invader_head");
		originalColor = invader_body.renderer.material.color;
	}
	
	void Locked() {
		StartCoroutine("show", 0.5f);
		if ( hp > 0 ){
			GameObject.Find("InvaderHP").SendMessage("Hit");
			hp--;
			return;
		}
	}

	IEnumerator show() {
		invader_head.renderer.material.color = Color.white * Mathf.Abs(Mathf.Sin(30.0F * Time.time));
		invader_body.renderer.material.color = Color.white * Mathf.Abs(Mathf.Sin(30.0F * Time.time));
		yield return new WaitForSeconds(1.0f);
		invader_head.renderer.material.color = originalColor;
		invader_body.renderer.material.color = originalColor;
	}

	void KillInvador(){
		Instantiate( lockedPrefab, transform.position, Quaternion.identity);
		Destroy(invader_body);
		Destroy(invader_head);
		Destroy(gameObject);
	}
}