using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public GameObject EnemyPrefab;

	public float SpawnDelay = 2f;
	public float SpawnDelayOffset = 0f;

	public float SpawnRadius = 4f;

	private float spawnTime;

	private Vector3 spawnPosition;

	void Start () {
		spawnTime = Time.time + SpawnDelay;
	}
	
	void Update () {

		if (spawnTime < Time.time) {
			spawnPosition = new Vector2(Random.Range (-1f, 1f), Random.Range (-1f, 1f));
			spawnPosition = spawnPosition.normalized * SpawnRadius;
			SpawnEnemy(spawnPosition);

			spawnTime = Time.time + SpawnDelay + Random.Range (-SpawnDelayOffset, SpawnDelayOffset);
		}
	
	}

	void SpawnEnemy (Vector3 position) {
		Instantiate(EnemyPrefab, position, Quaternion.identity);
	}

}
