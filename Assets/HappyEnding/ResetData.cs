using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ResetData : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt("life", 0);
		PlayerPrefs.SetInt("Score", 0);
	}
}
