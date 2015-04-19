using UnityEngine;

public class EnemySunDamager : MonoBehaviour
{
    private Transform sun;
    private EnemyHealth health;

    public float dmgMultiplier;

    private bool isRayBlocked = false;
    private float sunLightRadius = 10;

    public LayerMask RayCastMask;

    private void Start()
    {
        sun = GameObject.FindWithTag("Sun").transform;
        health = GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        CheckInShadow();
        CheckInRadius();
    }

    /// <summary>
    /// Are we close enough to the sun? if not take damage
    /// </summary>
    private void CheckInRadius()
    {
        if (Vector2.Distance(transform.position, sun.position) > sunLightRadius)
        {
            health.TakeDamage(Time.deltaTime);
        }
    }

    /// <summary>
    /// Are we in a shadow from the sun?
    /// </summary>
    private void CheckInShadow()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, (sun.position - transform.position), Mathf.Infinity, RayCastMask.value);
        isRayBlocked = false;

        // We hit something
        //if (rayHit.distance < Vector2.Distance(transform.position, sun.position) - 0.05f)
        if (rayHit.collider != null)
        {
            health.TakeDamage(Time.deltaTime * dmgMultiplier);
            isRayBlocked = true;
        }
    }

    public void OnDrawGizmos()
    {
        if (sun == null)
        {
            return;
        }

        if (isRayBlocked)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }
        Gizmos.DrawLine(transform.position, sun.position);
    }
}