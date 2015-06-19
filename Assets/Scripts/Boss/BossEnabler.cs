using UnityEngine;
using System.Collections;

public class BossEnabler : MonoBehaviour {

	public string animationName;

	GameObject boss;
	Animator animator;

	void Start () {
		boss = GameObject.FindGameObjectWithTag("Boss");
		boss.SetActive (false);
		animator = GetComponent<Animator> ();
	}
	

	void Update () {
		if (!animator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
		{
			// Avoid any reload.
			Invoke ("startEntrance", 1.2f);
		}
	}


	void startEntrance(){
		boss.SetActive(true);
		this.gameObject.SetActive (false);
	}
}
