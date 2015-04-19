using UnityEngine;
using System.Collections;

public class lowerBoudary : MonoBehaviour {

	private playerController playerController;
	
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			other.attachedRigidbody.velocity = new Vector2(other.attachedRigidbody.velocity.x, 1 * Mathf.Abs(other.attachedRigidbody.velocity.y));
		}
		Debug.Log ("1");
	}
	
	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "Player") {
			playerController = other.attachedRigidbody.GetComponent<playerController>();
			//disable jump until Player is outside the collider, so that the player does not eit the collider
			playerController.onGround = false;
			other.attachedRigidbody.velocity = new Vector2 (other.attachedRigidbody.velocity.x, 1 * Mathf.Abs (other.attachedRigidbody.velocity.y));
			Debug.Log ("2");
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			playerController = other.attachedRigidbody.GetComponent<playerController>();
			//disable jump until Player is outside the collider, so that the player does not eit the collider
			playerController.onGround = true;
		}
		Debug.Log ("3");
	}
}
