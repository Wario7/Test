using UnityEngine;
using System.Collections;
using CompleteProject;

public class Difficulty : MonoBehaviour {

	Transform [] previousTransforms;
	// Update is called once per frame
	bool isAdded;
	bool isFaster;

	void Start(){
		Debug.Log ("size:" + EnemySpawner.current.spawnPoints.Length);
		isAdded = false;
		isFaster = false;
	}

	void Update () {
		if (ScoreManager.score > 100 && !isAdded) {
			isAdded = true;
			previousTransforms = new Transform[EnemySpawner.current.spawnPoints.Length];
			for(int i = 0; i < EnemySpawner.current.spawnPoints.Length; i++){
				previousTransforms[i] = EnemySpawner.current.spawnPoints[i];
			}

			EnemySpawner.current.spawnPoints = new Transform[previousTransforms.Length + 1];
			for(int i = 0; i < previousTransforms.Length; i++){
				EnemySpawner.current.spawnPoints[i] = previousTransforms[i];
			}
			GameObject newSpawnPoint = new GameObject();
			newSpawnPoint.transform.position = new Vector2(Random.Range(-18, 18), 14);

			EnemySpawner.current.spawnPoints[EnemySpawner.current.spawnPoints.Length - 1] = newSpawnPoint.transform;

		}

		if (ScoreManager.score > 200 && !isFaster) {
			isFaster = true;
			EnemySpawner.current.spawnTime = 0.3f;
		}

	}
}
