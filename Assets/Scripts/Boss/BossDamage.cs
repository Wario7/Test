using UnityEngine;
using System.Collections;
using CompleteProject;

public class BossDamage : MonoBehaviour {

	public int attackDamage = 70;               // The amount of health taken away per attack.


	private GameObject player;                          // Reference to the player GameObject.
	private PlayerHealth playerHealth;                  // Reference to the player's health.


	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		//		pop = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Boundary" || other.gameObject.tag == "Enemy" || other.gameObject.tag != "Player" && other.gameObject.tag != "Bomb")
		{
			return;
		}
		
		if (other.gameObject.tag == "Player")
		{
			//			//		gameController.AddScore(scoreValue);
			if(playerHealth.currentHealth > 0)
			{
				// ... damage the player.
				playerHealth.TakeDamage (attackDamage);
			}
			//		Destroy (other.gameObject);
			
		}
		
//		gameObject.SetActive (false);
		
	}
}
