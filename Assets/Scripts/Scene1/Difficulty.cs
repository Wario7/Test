using UnityEngine;
using System.Collections;
using CompleteProject;

public class Difficulty : MonoBehaviour {

	public GameObject bonus;
	float randomPoint;
	Transform [] previousTransforms;
	bool isAdded;
	bool isFaster;
	bool isFaster2;
	bool didSpawn;

	void Start(){
		randomPoint = Random.Range(-13f, 13f);
		Debug.Log ("size:" + EnemySpawner.current.spawnPoints.Length);
		isAdded = false;
		isFaster = false;
		isFaster = false;
	}

	void Update () {
		if (ScoreManager.score > 100 && !isAdded) {
			Instantiate(bonus, new Vector2(randomPoint, 12), Quaternion.identity);
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
			EnemySpawner.current.Init();
		}

		if(ScoreManager.score > 400 && !didSpawn){
			didSpawn = true;
			Instantiate(bonus, new Vector2(randomPoint, 12), Quaternion.identity);
		}

		if (ScoreManager.score > 500 && !isFaster2) {
			isFaster2 = true;
			EnemySpawner.current.spawnTime = 0.01f;
			EnemySpawner.current.Init();
		}

	}
}
