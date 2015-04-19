using UnityEngine;
using System.Collections;

public class AsteroidManager : MonoBehaviour {

	public float OrbitRadius = 20f;

    public float asd;
    private float ast;
    private bool aps;

	public GameObject AsteroidPrefab;
	private bool Busy;

	private Vector3 asteroidPosition;
	
	void Start () {
	
	}

	void Update () 
    {

        Debug.Log(Busy);

        Vector3 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mPos.z = 0;
        Debug.Log(Vector3.Distance(new Vector3(), mPos));

        if (Vector3.Distance (new Vector3(), mPos) > OrbitRadius)
        {
            if (!Busy && Input.GetMouseButton(0)) 
            {
			    asteroidPosition = mPos.normalized * OrbitRadius;
                aps = true;
		    }
		    else if (!Busy && Input.GetMouseButton (0) && aps) 
            {
			    GameObject obj = Instantiate (AsteroidPrefab, asteroidPosition, Quaternion.identity) as GameObject;
			    obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, 0f);
			    Busy = true;
		    }
		    else if (Input.GetMouseButtonUp(0))
            {
                ast = Time.time + asd;
		    }

        }

        if (ast < Time.time && aps)
        {
            Busy = false;
            aps = false;
        }
	
	}

}
