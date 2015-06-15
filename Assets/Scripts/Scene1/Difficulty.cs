using UnityEngine;
using System.Collections;
using CompleteProject;

public class Difficulty : MonoBehaviour {

	public GameObject bonus;
	public GameObject camera;
	public float smoothing = 1f;
	public float height = 25f;
	
	float randomPoint;
	Transform [] previousTransforms;
	bool isAdded;
	bool isFaster;
	bool isFaster2;
	bool didSpawn;
	bool removedSpawner;

	void Start(){
		randomPoint = Random.Range(-13f, 13f);

		isAdded = false;
		isFaster = false;
		isFaster2 = false;
		removedSpawner = false;
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

		if (camera.transform.position.y >= height - 0.5 && !removedSpawner) {
			removedSpawner = true;
			GameObject enemySpawner = GameObject.FindWithTag("EnemySpawner");
			if(enemySpawner.active == true)
				enemySpawner.SetActive(false);
			Application.LoadLevel(3);
		}

	}

	void FixedUpdate(){
		if (ScoreManager.score > 1000 && camera.transform.position.y < height - 0.5) {
			//			didCameraMove = true;
			
			Vector3 targetCamPos = new Vector3(camera.transform.position.x, height, camera.transform.position.z);
			
			// Smoothly interpolate between the camera's current position and it's target position.
			camera.transform.position = Vector3.Lerp (camera.transform.position, targetCamPos, smoothing * Time.deltaTime);
		}

	}
}
