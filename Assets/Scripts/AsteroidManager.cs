using UnityEngine;

public class AsteroidManager : MonoBehaviour
{

    public float OrbitRadius = 20f;

    public float AsteroidSpawnDelay;
    private float _asteroidSpawnTime;
    private bool _asteroidPositionSet;

    public GameObject AsteroidPrefab;
    private bool Busy;

    private Vector3 asteroidPosition;

    void Start()
    {

    }

    void Update()
    {

        //Debug.Log(Busy);

        Vector3 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mPos.z = 0;
        //Debug.Log(Vector3.Distance(new Vector3(), mPos));

        // Is the mouse outside orbit?
        if (Vector3.Distance(new Vector3(), mPos) > OrbitRadius)
        {
            // If we arent busy and we clicked, set the position to fling from
            if (!Busy && Input.GetMouseButton(0) && !_asteroidPositionSet)
            {
                asteroidPosition = mPos.normalized * OrbitRadius;
                _asteroidPositionSet = true;
            }
            else if (!Busy && Input.GetMouseButton(0) && _asteroidPositionSet)
            {
                GameObject obj = Instantiate(AsteroidPrefab, asteroidPosition, Quaternion.identity) as GameObject;
                obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, 0f);
                Busy = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _asteroidSpawnTime = Time.time + AsteroidSpawnDelay;
            }

        }

        if (_asteroidSpawnTime < Time.time && _asteroidPositionSet)
        {
            Busy = false;
            _asteroidPositionSet = false;
        }

    }

}
