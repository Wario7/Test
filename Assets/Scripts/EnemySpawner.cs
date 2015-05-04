using UnityEngine;

namespace CompleteProject
{
	public class EnemySpawner : MonoBehaviour
	{
		public static EnemySpawner current;

		//public PlayerHealth playerHealth;       // Reference to the player's heatlh.
		public GameObject enemy;                // The enemy prefab to be spawned.
		public float spawnTime = 1f;            // How long between each spawn.
		public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

		private float halfSpawnPoints;



		void Awake(){
			current = this;
		}

		void Start ()
		{
			// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
			halfSpawnPoints = spawnPoints.Length / 2;
			InvokeRepeating ("Spawn", spawnTime, spawnTime);
		}
		
		
		void Spawn ()
		{
//			 If the player has no health left...
//			if(playerHealth.currentHealth <= 0f)
//			{
//				// ... exit the function.
//				return;
//			}
			Debug.Log ("here");
			// Find a random index between zero and one less than the number of spawn points.
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			
			// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
			GameObject obj = EnemyPooler.current.GetPooledObject ();

			if (obj == null)
				return;
			if (spawnPointIndex < halfSpawnPoints)
				obj.GetComponent<EnemyBehaviour>().facingRight = -1;
			else
				obj.GetComponent<EnemyBehaviour>().facingRight = 1;
			obj.transform.position = spawnPoints[spawnPointIndex].position;
			obj.transform.rotation = spawnPoints[spawnPointIndex].rotation;

			obj.SetActive(true);
		}
	}
}