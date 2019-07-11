using UnityEngine;
using System.Collections;

public class InvaderShootController : MonoBehaviour {
	public GameObject explosionPrefab;
	public GameObject bulletPrefab;
	// public Vector3 pos;

	GameObject explosion;
	GameObject bullet;
	float radius = 8.0f;
	float angle = 45.0f;
	
	void Start() {
		explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
		explosion.gameObject.transform.parent = transform.parent;
		StartCoroutine("destroyDelay");
		for ( int i = 1; i < 9; i++ ){
			float x = Mathf.Cos(Mathf.Deg2Rad * angle * i) * radius;
			float y = Mathf.Sin(Mathf.Deg2Rad * angle * i) * radius;
			bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
			bullet.gameObject.transform.parent = transform.parent;
			bullet.rigidbody2D.velocity = new Vector3(x, y, 0);
			StartCoroutine("destroy", bullet);
		}
	}

	IEnumerator destroyDelay() {
		yield return new WaitForSeconds(0.7f);
		Destroy(explosion);
	}

	IEnumerator destroy(GameObject bullet) {
		yield return new WaitForSeconds(7.5f);
		GameObject.Find("MakeBullet").SendMessage("reset");
		Destroy(bullet);
		Destroy(gameObject);
	}
}
