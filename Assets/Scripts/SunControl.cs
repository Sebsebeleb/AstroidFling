using UnityEngine;
using System.Collections;

public class SunControl : MonoBehaviour {

	private float angle = 0f;
	public float TurnRate = 0.1f;

	public float OrbitRadius = 7f;

	void Start () {
	
	}

	void Update () {

		angle += TurnRate;
		if (angle > 360) angle -= 360;
		Vector3 pos = new Vector3();
		float rad = angle * Mathf.Deg2Rad;
		pos.x = Mathf.Sin(rad);
		pos.y = Mathf.Cos(rad);
		pos = pos.normalized * OrbitRadius;

		transform.position = pos;
		
	}
}
