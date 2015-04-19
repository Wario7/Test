using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class NewBehaviourScript : MonoBehaviour {
	
	public float fireRate = 0.5f;
	private float nextFire;
	
	private Rigidbody2D rb;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
	}


	void FixedUpdate(){
		rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
	}
	
	void Fire() {

	
		
	}
	
}
