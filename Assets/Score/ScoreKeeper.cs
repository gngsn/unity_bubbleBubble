using UnityEngine;
// using UnityEditor;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class ScoreKeeper : MonoBehaviour {
	public static ScoreKeeper instance;
	public GUISkin skin;
	private int score = 0;
	private int enemyCount;
	BlockAnimationController blockController;
	public GameObject bonusDoorPrefab;
	
	[HideInInspector]
	public int lifeCheck = 3;
	[HideInInspector]
	public int Score{
		get {
			return this.score;
		}
	}

	void Start () {
		LoadData();
		// score = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataController>().loadData();
		enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
		// enemyCount = 1;
		if ( enemyCount == 0 || GameObject.Find("endingManager") ){
			enemyCount++;
		}
	}
	// Update is called once per frame
	void Update () {
		CheckLife();
		if( enemyCount == 0 ){
			 if( GameObject.Find("bg_block") != null ){
				SaveData();
				GameObject.Find("bg_block").GetComponent<BlockAnimationController>().SendMessage("clearStage");
			} else {
				GameObject door = Instantiate(bonusDoorPrefab, new Vector3(19.0f, -15.3f, 0.0f), Quaternion.identity) as GameObject;
				door.SendMessage("SetNextScene", "BonusRound");
				enemyCount--;
			} 
		} 
	}

	void CheckLife() {
		switch( lifeCheck ){
			case 0 : 
				GameObject.Find("heart_1").transform.position = new Vector3(26.0f, 18.5f, 0.5f);
				GameObject.Find("heart_2").transform.position = new Vector3(23.0f, 18.5f, 0.5f);
				GameObject.Find("heart_3").transform.position = new Vector3(20.0f, 18.5f, 0.5f);
				StartCoroutine("endDelay");
				break;
			case 1 : 
				GameObject.Find("heart_2").transform.position = new Vector3(23.0f, 18.5f, 0.5f);
				GameObject.Find("heart_3").transform.position = new Vector3(20.0f, 18.5f, 0.5f);
				break;

			case 2 :
				GameObject.Find("heart_3").transform.position = new Vector3(20.0f, 18.5f, 0.5f); 
				break;
		}
	}

	IEnumerator endDelay() {
		yield return new WaitForSeconds(1.0f);
		Application.LoadLevel("BadEnding");
	}

	void SetScore(int gainScore){
		score += gainScore;
	}

	void CountKillCharacter(){
		lifeCheck--;
		if( lifeCheck == 0 ){
			Debug.Log("Save!");
			SaveData();
		}
	}

	void CountKillEnemy(){
		enemyCount--;
	}

	
	// public void SaveData(){
	// 	BinaryFormatter bf = new BinaryFormatter();
	// 	FileStream file = File.Create(Application.persistentDataPath + "/score_data.dat");

	// 	PlayerData data = new PlayerData();
	// 	data.life = lifeCheck;
	// 	data.score = score;

	// 	bf.Serialize(file, data);
	// 	file.Close();
	// }

	// public void LoadData() {
	// 	if( File.Exists(Application.persistentDataPath + "/score_data.dat")){
	// 		BinaryFormatter bf = new BinaryFormatter();
	// 		FileStream file = File.Open(Application.persistentDataPath + "/score_data.dat", FileMode.Open);
	// 		Debug.Log(Application.persistentDataPath + "/score_data.dat");
	// 		PlayerData data = (PlayerData)bf.Deserialize(file);
	// 		file.Close();

	// 		lifeCheck = data.life;
	// 		score = data.score;

	// 		Debug.Log("Second round! life : " +lifeCheck + ", score : " + score);
	// 	} else {
	// 		Debug.Log("First round!");
	// 		lifeCheck = 3;
	// 		score = 0;
	// 	}
	// }
	
	public void SaveData(){
		PlayerPrefs.SetInt("life", lifeCheck);
		PlayerPrefs.SetInt("Score", score);
	}

	public void LoadData() {
		lifeCheck = PlayerPrefs.GetInt("life");
		score = PlayerPrefs.GetInt("Score");
		if( lifeCheck == 0 && score == 0 ){
			lifeCheck = 3;
			score = 0;
		}
	}


	void OnGUI(){
		GUI.skin = skin;
		int sWidth = Screen.width;
		int sHeight = Screen.height;
		string resultScore = score.ToString();
		GUI.Label(new Rect( sWidth/8.2f, 18f, sWidth/12f, sHeight /7), resultScore, "ScoreShadow");
		GUI.Label(new Rect( sWidth/8.5f, 17, sWidth/12f, sHeight /7), resultScore, "Score");

		GUI.Label(new Rect( sWidth/2.33f, 18f, sWidth, sHeight /7), "20171101", "HighShadow");
		GUI.Label(new Rect( sWidth/2.35f, 17f, sWidth, sHeight /7), "20171101", "High");

		// GUI.Label(new Rect( 6.3f * sWidth/8.45f, 21f, sWidth, sHeight /7), insertCoin, "WarnShadow");
		// GUI.Label(new Rect( 6.3f * sWidth/8.5f, 20f, sWidth, sHeight /7), insertCoin, "Warn");
	}
}

[Serializable]
class PlayerData {
	public int life;
	public int score;
}
