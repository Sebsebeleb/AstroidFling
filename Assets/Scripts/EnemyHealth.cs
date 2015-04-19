using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{

    public float Health;

    void Start()
    {

    }

    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        Debug.Log("hello");
        Health -= damage;
        if (Health <= 0) 
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}