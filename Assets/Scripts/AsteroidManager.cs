using UnityEngine;
using System.Collections;

public class AsteroidManager : MonoBehaviour {

	public float OrbitRadius = 20f;

	public GameObject AsteroidPrefab;
	private bool Busy;

	private Vector3 asteroidPosition;
	
	void Start () {
	
	}

	void Update () {

		if (!Busy && Input.GetMouseButtonDown(0)) {
			Vector3 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			asteroidPosition = mPos.normalized * OrbitRadius;
		}
		else if (!Busy && Input.GetMouseButton (0)) {
			GameObject obj = Instantiate (AsteroidPrefab, asteroidPosition, Quaternion.identity) as GameObject;
			obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, 0f);
			Busy = true;
		}
		else if (Input.GetMouseButtonUp(0)) {
			Busy = false;
		}
	
	}
}
