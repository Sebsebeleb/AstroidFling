using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

	private Vector2 directionPlanet;
	private Vector2 directionSpeed;

	private Rigidbody2D rig;

	private bool InOrbit;
	
	void Start () {

		rig = GetComponent<Rigidbody2D>();

	}

	void Update () {

		if (InOrbit) ApplyGravity();
		else {

			Vector3 mPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 directionMouse = new Vector2(transform.position.x - mPos.x, transform.position.y - mPos.y).normalized;
			float speedFactor = Vector2.Distance (transform.position, mPos) * 2f;

			if (Input.GetMouseButtonUp (0)) {
				directionSpeed = directionMouse * speedFactor;
				StartOrbit();
			}
		}

	}

	void StartOrbit () {
		rig.AddForce (directionSpeed, ForceMode2D.Impulse);
		InOrbit = true;
	}

	void ApplyGravity () {
		directionPlanet = -transform.position;
		directionPlanet.Normalize ();
		directionPlanet *= (20-Vector2.Distance (new Vector2(), transform.position));

		rig.AddForce (directionPlanet);
	}
}
