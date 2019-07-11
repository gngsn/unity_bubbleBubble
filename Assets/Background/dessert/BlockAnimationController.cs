using UnityEngine;
using System.Collections;

public class BlockAnimationController : MonoBehaviour {
	public string nextSceneName;
	public string direction;
	Animator anim;
	bool isClearStage = false;
	bubblunController bubblunLocked;

	void Start () {
		anim = GetComponent<Animator>();
		bubblunLocked = GameObject.FindWithTag("Player").GetComponent<bubblunController>();
		bubblunLocked.resetToNextStage(false);
	}
	
	void Update () {
		if( isClearStage ) {
			StartCoroutine("endDelay");
		}
	}

	IEnumerator endDelay() {
		yield return new WaitForSeconds(3.0f);
		StartCoroutine("nextScene");
		GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
		foreach (GameObject item in items)
		{
			Destroy(item);
		}
		bubblunLocked.resetToNextStage(true);
		anim.SetBool(direction, isClearStage);
	}
	

	IEnumerator nextScene() {
		yield return new WaitForSeconds(5.0f);
		isClearStage = false;
		anim.SetBool(direction, isClearStage);
		Application.LoadLevel(nextSceneName);
	}

	void clearStage(){
		isClearStage = true;
	}
}
