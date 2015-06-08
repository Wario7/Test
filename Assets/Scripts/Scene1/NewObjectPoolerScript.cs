using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class NewObjectPoolerScript : MonoBehaviour {

	public static NewObjectPoolerScript current;
	public GameObject pooledObject;
	public int pooledAmount = 20;
	public bool willGrow = true;

	List<GameObject> pooledObjects;

	void Awake(){
		//need this for static NewObjectPoolingScript
		current = this;
	}

	// Use this for initialization
	void Start () {
		pooledObjects = new List<GameObject> ();
		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject) Instantiate(pooledObject);
			obj.SetActive(false);
			pooledObjects.Add(obj);
		}
	}

	public GameObject GetPooledObject(){
		int objPosition = Random.Range (0, pooledObjects.Count);
//		for (int i = 0; i < pooledObjects.Count; i++) {
//			if(!pooledObjects[i].activeInHierarchy){
//				return pooledObjects[i];
//			}
//		}
		if(!pooledObjects[objPosition].activeInHierarchy){
			return pooledObjects[objPosition];
		}

		if (willGrow) {
			GameObject obj = (GameObject) Instantiate(pooledObject);
			obj.SetActive(false);
			pooledObjects.Add(obj);
			return obj;
		}

		return null;
	}

}
