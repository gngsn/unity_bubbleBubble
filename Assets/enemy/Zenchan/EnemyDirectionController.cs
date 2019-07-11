using UnityEngine;
using System.Collections;

// facing == 0 : right, facing == 1 : left, facing == 2 : down, facing ==3 : jump
public class EnemyDirectionController : MonoBehaviour {

	public int facing;
	public string who ="";
	public bool isOnce;

	void Start () {
	
	}
	
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other){
		if ( other.gameObject.tag == "Enemy" && who == "" && other.name != "Puru"){
			other.gameObject.SendMessage("facingControl", facing);
			if(isOnce){
				Destroy(gameObject);
			}	
		} else if( other.gameObject.tag == "Enemy" && other.name == who ){
			other.gameObject.SendMessage("facingControl", facing);
			if(isOnce){
				Destroy(gameObject);
			}	
		}		
	}

}
