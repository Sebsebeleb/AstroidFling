using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	private float shakeTime;
	private float shakeMultiplier;
	
	void Start () {
	
	}

	void Update () {

		if (shakeTime > Time.time) {
			Vector3 pos = new Vector3();
			float r = (shakeTime - Time.time) * shakeMultiplier;
			pos.x = Random.Range (-r, r);
			pos.y = Random.Range (-r, r);
			pos.z = -10f;
			transform.position = Vector3.Lerp (transform.position, pos, 0.7f);
		}
		else {
			transform.position = new Vector3(0f, 0f, -10f);
		}

		if (Input.GetKey(KeyCode.Space)) {
			StartShake(0.7f, 2f);
		}
	
	}

	public void StartShake (float time, float multiplier) {
		shakeMultiplier = multiplier;
		shakeTime = Time.time + time;
	}

}
