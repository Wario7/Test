using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

	private static bool created;
	// Use this for initialization
	void Awake () {
		if (!created) {
			DontDestroyOnLoad (gameObject);
			created = true;
		} else {
			Destroy(this.gameObject);
		}
		
	}


//	function Awake() { if (!created) { // this is the first instance - 
//	make it persist DontDestroyOnLoad(this.gameObject); created = true; } else { // this must be a duplicate from a scene reload - DESTROY! Destroy(this.gameObject); } }
}