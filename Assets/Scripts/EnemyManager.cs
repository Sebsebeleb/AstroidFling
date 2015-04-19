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
	
	}

}
