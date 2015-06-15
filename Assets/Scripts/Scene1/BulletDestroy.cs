using UnityEngine;
using System.Collections;

public class BulletDestroy : MonoBehaviour {

	public int bombPoisition;
	public float facingRight = 1;

	private float bombDuration;

	void Awake(){
		bombDuration = StaticVariables.getBombDuration(Application.loadedLevel);
	}

	void OnEnable(){
		Invoke ("Destroy", bombDuration);
		GetComponent<Rigidbody2D> ().velocity = new Vector2 ();

		if (bombPoisition == 0) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (500 * facingRight, 500));
		} else if (bombPoisition == 1) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (300 * facingRight, 700));
		} else if (bombPoisition == 2) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (400 * facingRight, -600));
		} else if (bombPoisition == 3) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0 * facingRight, -700));
		} else if (bombPoisition == 4) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (300 * -1 * facingRight, -700));
		} else if (bombPoisition == 5) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (500 * -1 * facingRight, 500));
		} else if (bombPoisition == 6) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0 * facingRight, 700));
		} else {
			print ("here$$$$$");
		}
	}

	void Destroy(){
		gameObject.SetActive (false);
	}

	void OnDisable(){
		CancelInvoke ();
	}


}
