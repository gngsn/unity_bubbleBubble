using UnityEngine;
using System.Collections;

public class ItemCounter : MonoBehaviour {
	public GameObject bonusDoorPrefab;
	int treasureCount;
	// Use this for initialization
	void Start () {
		treasureCount = GameObject.FindGameObjectsWithTag("Item").Length;	
	}
	
	// Update is called once per frame
	void Update () {
		if( treasureCount == 0 ){
			GameObject door = Instantiate(bonusDoorPrefab, new Vector3(0.4f, -15.3f, 0.0f), Quaternion.identity) as GameObject;
			door.SendMessage("SetNextScene", "ThirdRound");
			treasureCount--;
		}
	}
	public void destroy(){
		treasureCount--;
	}
}
