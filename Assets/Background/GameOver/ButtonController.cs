using UnityEngine;
using System.Collections;
using System.IO;

public class ButtonController : MonoBehaviour {
	public GUISkin skin;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown(KeyCode.Space) ){
			DeleteFile();
			Application.LoadLevel("FirstRound");
		}
	}


	 void DeleteFile() {		
		PlayerPrefs.SetInt("life", 0);
		PlayerPrefs.SetInt("Score", 0);
     }

}
