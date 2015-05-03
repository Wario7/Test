using UnityEngine;
using System.Collections;

public class Pop : MonoBehaviour {
	
	public AudioClip poppingSound;

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") 
		{
			Debug.Log ("hit");
			AudioSource.PlayClipAtPoint(poppingSound, transform.position);	
			gameObject.SetActive(false);
			other.gameObject.SetActive(false);
		}
	}
}
