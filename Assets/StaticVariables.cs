using UnityEngine;
using System.Collections;

public class StaticVariables : MonoBehaviour {

	public static float BOMBDURATION_SCENE1 = 2f;
	public static float BOMBDURATION_SCENE3 = 4f;


	public static float getBombDuration(int sceneNumber){
		switch (sceneNumber) {
			case 1:
				return 2f;
				break;
			case 3:
				return 4f;
				break;
			default:
				return 0;
				break;
		}
	}
}
