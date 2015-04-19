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
			transform.position = pos;
		}
		else {
			transform.position = new Vector3(0f, 0f, -10f);
		}
	
	}

	public void StartShake (float time, float multiplier) {
		shakeMultiplier = multiplier;
		shakeTime = Time.time + time;
	}

}
