using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour {

	public AudioSource bonusTaken;
	
	private Animator anim;
	private CircleCollider2D collider;
	private Rigidbody2D body;
	private DisplayManager displayManager;
	private PlayerBonuses playerBonuses;

	private bool done;

	void Start(){
		done = false;
		playerBonuses = PlayerBonuses.getInstance ();
		bonusTaken = GetComponent<AudioSource> ();
		displayManager = DisplayManager.Instance();
		body = GetComponentInParent<Rigidbody2D> ();
		anim = GetComponentInParent<Animator> ();
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player" && !done) {
			done = true;
			anim.SetTrigger ("taken");
			bonusTaken.Play();
			playerBonuses.grantBonus();
			transform.parent.GetComponent<Collider2D>().enabled = false;
			body.isKinematic = true;
			Invoke ("DeActivate", 0.5f);
		}
	}

	void DeActivate(){
		done = false;
		transform.parent.gameObject.SetActive (false);
	}
}
