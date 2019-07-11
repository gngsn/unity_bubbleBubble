using UnityEngine;  
using System.Collections;  
  
[RequireComponent (typeof (GUITexture))]  
[RequireComponent (typeof (AudioSource))]  
  
public class VideoController : MonoBehaviour  
{  
    private GUITexture videoGUItex;  
    public MovieTexture mTex;  
    private AudioSource movieAS;
    bool flag = false;
    
    void Start()  
    {  
        movieAS = GetComponent<AudioSource>();
        videoGUItex = GetComponent<GUITexture>();
        movieAS.clip = mTex.audioClip;
        videoGUItex.pixelInset = new Rect(Screen.width/2, -Screen.height/2,0,0);  
        videoGUItex.texture = mTex; 
   		PlayerPrefs.SetInt("life", 0);
		PlayerPrefs.SetInt("Score", 0);
        StartCoroutine("playDelay");
    }  

	IEnumerator playDelay() {
		yield return new WaitForSeconds(3.5f);
        mTex.Play();  
        movieAS.Play();
        flag = true;
	}

    void Update() {
        // if(Input.GetKeyDown(KeyCode.Space)){
        //     Application.LoadLevel("FirstRound");
        // }
        if( !mTex.isPlaying && flag ) {
            StartCoroutine("loadDelay");
        }
    }

    IEnumerator loadDelay() {
        yield return new WaitForSeconds(2.0f);
        Application.LoadLevel("FirstRound");
    }
}  