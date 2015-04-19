using UnityEngine;
using System.Collections;

public class SunControl : MonoBehaviour {

	public float TurnTime = 42f;

	public float OrbitRadius = 7f;

	void Start () {
	
	}

	void Update () {

		float f = (Time.time / TurnTime) % 2;
		Vector3 pos = new Vector3();
		pos.x = Mathf.Sin (f);
		pos.y = Mathf.Cos (f);
		pos = pos.normalized * OrbitRadius;

		transform.position = pos;
		
	}
}
