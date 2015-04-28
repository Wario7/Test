using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public float facingRight;
	
	void OnEnable(){
		float x = Random.Range (300, 800);
		float y = Random.Range (300, 800);
	    float rotation = Random.Range (50, 300);

		Invoke ("Destroy", 4f);
		GetComponent<Rigidbody2D>().velocity = new Vector2 ();
		GetComponent<Rigidbody2D>().AddForce (new Vector2(x*facingRight, y));
		GetComponent<Rigidbody2D> ().AddTorque (rotation*-facingRight);
	}
	
	void Destroy(){
		gameObject.SetActive (false);
	}
	
	void OnDisable(){
		CancelInvoke ();
	}

}
