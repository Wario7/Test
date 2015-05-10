using UnityEngine;
using System.Collections;
using CompleteProject;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	public int attackDamage = 50;               // The amount of health taken away per attack.
	//private GameController gameController;

	GameObject player;                          // Reference to the player GameObject.
	PlayerHealth playerHealth;                  // Reference to the player's health.
//	AudioSource pop;
	
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
//		pop = GetComponent<AudioSource> ();
	}
	
	void OnCollisionStay2D (Collision2D other)
	{

		if (other.gameObject.tag == "Boundary" || other.gameObject.tag == "Enemy" || other.gameObject.tag != "Player" && other.gameObject.tag != "Bomb")
		{
			return;
		}
		
		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}

		if (other.gameObject.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			//			//		gameController.AddScore(scoreValue);
			if(playerHealth.currentHealth > 0)
			{
				// ... damage the player.
				playerHealth.TakeDamage (attackDamage);
			}
			//		Destroy (other.gameObject);

		}

		gameObject.SetActive (false);

	}
}