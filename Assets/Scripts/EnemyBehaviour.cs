using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour 
{

    private Transform target;

    public float eSpeed;

	void Start () 
    {

        target = GameObject.FindGameObjectWithTag("earth").transform;
	
	}
	
	void Update () 
    {

        if (Vector3.Distance(transform.position, target.position) > 0.1f)
        {
            float a = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x);
            Vector3 rot = transform.eulerAngles;
            rot.z = 90 + a * 180 / Mathf.PI;
            transform.eulerAngles = rot;
            Vector3 pos = transform.position;
            pos.x += eSpeed * Mathf.Cos(a) * Time.deltaTime;
            pos.y += eSpeed * Mathf.Sin(a) * Time.deltaTime;
            transform.position = pos;
        }
	
	}

}
