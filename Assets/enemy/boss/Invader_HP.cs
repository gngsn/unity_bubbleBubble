using UnityEngine;
using System.Collections;

public class Invader_HP : MonoBehaviour {
	// public Sprite hp;
	public GameObject HPPrefab;
	GameObject[] hp = new GameObject[25];
	float startPoint = -26.0f;
	bool isDelay;
	int count = 0;
	int index = 0;

	void Start () {
		isDelay = true;
		StartCoroutine("delay", 2f);
	}
	
	IEnumerator delay(float time) {
		yield return new WaitForSeconds(time);
		while( index < 25 ){
			hp[index] = Instantiate(HPPrefab, new Vector3(startPoint, 14.0f ,0.0f ), Quaternion.identity) as GameObject;
			hp[index].transform.parent = gameObject.transform;
			startPoint += 2.2f;
			index++;
		}
		isDelay = false;
	}

	void Hit(){
		if( index == 0 && !isDelay){
			GameObject.Find("invader_body_check_collide").SendMessage("KillInvador");
			Destroy(gameObject);
		}
		if( count == 4 ){
			count = 0;
			Destroy(hp[--index]);
		}
		count++;
	}

}
