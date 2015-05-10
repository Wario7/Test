using UnityEngine;
using System.Collections;

public class BulletDestroy : MonoBehaviour {

	public float facingRight = 1;

	void OnEnable(){
		Invoke ("Destroy", 2f);
		GetComponent<Rigidbody2D>().velocity = new Vector2 ();
		GetComponent<Rigidbody2D>().AddForce (new Vector2(500*facingRight, 500));
	}

	void Destroy(){
		gameObject.SetActive (false);
	}

	void OnDisable(){
		CancelInvoke ();
	}


}
