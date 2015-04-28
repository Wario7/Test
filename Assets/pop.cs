using UnityEngine;
using System.Collections;

public class pop : MonoBehaviour {

	void OnTri
	if (other.gameObject.tag == "Bomb") 
	{
		Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
		other.gameObject.SetActive(false);
	}
	Debug.Log ("hit");
	pop.Play();
}
