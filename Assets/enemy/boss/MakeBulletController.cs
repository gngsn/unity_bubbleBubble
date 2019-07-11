using UnityEngine;
using System.Collections;

public class MakeBulletController : MonoBehaviour {
	public GameObject attackPrefab1;
	public GameObject attackPrefab2;
	int count = 0;
	
	void Update () {
		if( gameObject.activeSelf && count == 0 ){
			Vector3 pos = transform.parent.transform.position;
			Instantiate(attackPrefab1,new Vector3(pos.x - 9.0f, pos.y + 6.1f,0), Quaternion.identity);
			Instantiate(attackPrefab2,new Vector3(pos.x + 9.5f, pos.y + 6f,0), Quaternion.identity);
			count++;
		}
	}

	void reset() {
		count = 0;
	}
}
