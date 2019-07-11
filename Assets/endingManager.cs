using UnityEngine;
using System.Collections;

public class endingManager : MonoBehaviour {
	public GameObject congPrefab;
	public GameObject endingPrefab;
	
	void end(){
		StartCoroutine("delay");
	}

	IEnumerator delay() {
		yield return new WaitForSeconds(2.0f);
		Instantiate(endingPrefab);
		Instantiate(congPrefab);
		StartCoroutine("EndDelay");
	}


	IEnumerator EndDelay() {
		yield return new WaitForSeconds(5.0f);
		Application.LoadLevel("HappyEnding");
	}
}
