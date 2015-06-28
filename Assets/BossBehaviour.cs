using UnityEngine;
using System.Collections;

public class BossBehaviour : MonoBehaviour {

	private int randomMove;
	private bool inMove;
	private Animator animator;
	private ColliderChanger colliderChanger;

	void Awake () {
		colliderChanger = GetComponent<ColliderChanger> ();
		animator = GetComponent<Animator> ();
		inMove = false;
	}
	
	// Update is called once per frame
	void Update () {
 		randomMove = Random.Range (0, 2);
		if(!inMove && animator.GetCurrentAnimatorStateInfo(0).IsName("standingStrong"))
			StartCoroutine(BossMove());
	}

	IEnumerator BossMove(){
		if (randomMove == 1) {
			inMove = true;
			colliderChanger.setSpriteCount(6); //starting animation sprite in ColliderChanger array.
			animator.SetTrigger("Move1");
			yield return new WaitForSeconds(3f);
			inMove = false;
			animator.SetTrigger("Move1");
			colliderChanger.setSpriteCount(5);
			print("MyCoroutine is now finished.");
		}
	}
}
