using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class EndingGameObject : MonoBehaviour {
	public GUISkin skin;
	ScoreKeeper ScoreManager;
	int score;

	void Start () {
		score = PlayerPrefs.GetInt("Score");
	}
	
	void OnGUI(){
		GUI.skin = skin;
		string scoreString = score.ToString();
		int sWidth = Screen.width;
		int sHeight = Screen.height;
		GUI.Label(new Rect( 3f, sHeight* 3.9f/9.0f, sWidth, sHeight), scoreString, "resultScoreShadow");
		GUI.Label(new Rect( 0.0f, sHeight* 3.8f/9.0f, sWidth, sHeight), scoreString, "resultScore");
	}

	// public void LoadData() {
	// 	if( File.Exists(Application.persistentDataPath + "/score_data.dat")){
	// 		BinaryFormatter bf = new BinaryFormatter();
	// 		FileStream file = File.Open(Application.persistentDataPath + "/score_data.dat", FileMode.Open);
	// 		PlayerData data = (PlayerData)bf.Deserialize(file);
	// 		file.Close();
	// 		score = data.score;
	// 	}
	// }
}
