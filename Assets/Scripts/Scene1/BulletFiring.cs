using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class BulletFiring : MonoBehaviour {

	public float fireRate = 0.5f;
	private float nextFire;

//	void Start(){
//		InvokeRepeating("Fire", fireTime, fireTime);
//	}

	void FixedUpdate(){
		if(Input.GetButton ("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Fire ();
		}
	}

	void Fire() {
		GameObject obj = NewObjectPoolerScript.current.GetPooledObject ();

		if (obj == null)
			return;
		obj.transform.position = transform.position;
		obj.transform.rotation = transform.rotation;
		if (!GetComponentInParent<playerController> ().facingRight)
			obj.GetComponent<BulletDestroy> ().facingRight = -1;
		else {
			obj.GetComponent<BulletDestroy> ().facingRight = 1;
		}
		obj.SetActive(true);

	}

}
