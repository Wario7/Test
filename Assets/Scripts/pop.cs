using UnityEngine;
using System.Collections;

public class Pop : MonoBehaviour {
	
	public AudioClip poppingSound;

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") 
		{
			ScoreManager.score += 15;
			Debug.Log ("hit");
			AudioSource.PlayClipAtPoint(poppingSound, transform.position); //because GetComponent<AudioSource>().Play needs gameObject to be active for ~1.75 sec to playt the sound
			gameObject.SetActive(false);
			other.gameObject.SetActive(false);
		}
	}
}
