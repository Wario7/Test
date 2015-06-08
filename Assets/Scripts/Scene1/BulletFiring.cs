using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class BulletFiring : MonoBehaviour {

	public float fireRate = 0.5f;
	public bool opPowered;
	public GameObject [] bombPositions;

	private float nextFire;
	private static BulletFiring instance;

	void Start(){
//		InvokeRepeating("Fire", fireTime, fireTime);
		instance = this;
	}

	public static BulletFiring getInstance(){
		return instance;
	}

	void FixedUpdate(){
		if(Input.GetButton ("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Fire ();
		}
	}

	void Fire() {
		GameObject obj = NewObjectPoolerScript.current.GetPooledObject ();

		if(opPowered){
			GameObject [] objects = new GameObject[6];

			for(int i = 0; i < objects.Length; i++){
				//note: if there are not enough objects in objectPooler, this loops forever, 
				//because it tries to find an object, while all objects are active in scence
				while(objects[i] == null || EqualsOneObject(i, objects)){
					objects[i] = NewObjectPoolerScript.current.GetPooledObject ();
				}
				if(objects[i] != null){
					objects[i].transform.position = bombPositions[i].transform.position;
					objects[i].transform.rotation = transform.rotation;
				}
				if (!GetComponentInParent<playerController> ().facingRight){
					objects[i].GetComponent<BulletDestroy> ().facingRight = -1;
				}
				else {
					objects[i].GetComponent<BulletDestroy> ().facingRight = 1;
				}

				objects[i].GetComponent<BulletDestroy> ().bombPoisition = i + 1;
			}
			for(int i = 0; i < objects.Length; i++){
				objects[i].SetActive(true);
			}
		}
		if (obj == null)
			return;
		obj.transform.position = transform.position;
		obj.transform.rotation = transform.rotation;
		if (!GetComponentInParent<playerController> ().facingRight) {
			obj.GetComponent<BulletDestroy> ().facingRight = -1;
		}
		else {
			obj.GetComponent<BulletDestroy> ().facingRight = 1;
		}
		obj.GetComponent<BulletDestroy> ().bombPoisition = 0;
		obj.SetActive(true);

	}

	//checks if element at index position is equal to at least one element which has index < position
	bool EqualsOneObject(int position, GameObject [] objects){
		for(int i = position - 1; i > 0; i--){
			if(objects[position].GetInstanceID() == objects[i].GetInstanceID()){
				return true;
			}
		}
		return false;
	}

}
