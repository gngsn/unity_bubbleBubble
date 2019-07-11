using UnityEngine;
using System.Collections;

public class CatchRespwanTrigger : MonoBehaviour {


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other){
		other.transform.position = new Vector3(12.0f, 30.0f, 0f);
	}
}
