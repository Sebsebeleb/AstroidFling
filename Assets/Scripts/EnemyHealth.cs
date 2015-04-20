using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float Health;
    private float startHealth;

    private Animator anim;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        startHealth = Health;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }

    public void TakeDamage(float damage)
    {

        anim.SetTrigger("TookDamage");
        Health -= damage;

        //spriteRenderer.color = new Color(0.2f + 0.8f * (Health / startHealth), 0, 0, 1);
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