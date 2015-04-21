using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public float OrbitRadius = 20f;
    public float SpeedMultiplier = 2f;
    public float GravityMultiplier = 2f;

    public Sprite ArrowSprite;
    public Sprite AsteroidSprite;

    private SpriteRenderer ren;

    private Vector2 directionPlanet;
    private Vector2 directionSpeed;

    private Rigidbody2D rig;
    private CircleCollider2D col;

    private bool InOrbit;

    void Start()
    {

        rig = GetComponent<Rigidbody2D>();
        ren = GetComponent<SpriteRenderer>();
        col = GetComponent<CircleCollider2D>();

        ren.sprite = ArrowSprite;
        col.enabled = false;

    }

    void Update()
    {

        if (InOrbit) ApplyGravity();
        else
        {

            Vector3 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 directionMouse = new Vector2(transform.position.x - mPos.x, transform.position.y - mPos.y).normalized;
            float speedFactor = Vector2.Distance(transform.position, mPos) * SpeedMultiplier;

            float angle = Mathf.Atan2(directionMouse.y, directionMouse.x) * Mathf.Rad2Deg - 90;
            transform.eulerAngles = new Vector3(0f, 0f, angle);

            transform.localScale = new Vector3(1f, speedFactor / SpeedMultiplier, 1f);

            if (Input.GetMouseButtonUp(0))
            {
                directionSpeed = directionMouse * speedFactor;
                StartOrbit();
            }
        }

        if (Vector2.Distance(new Vector3(), transform.position) > OrbitRadius)
        {
            GameObject.Destroy(gameObject);
        }

    }

    void StartOrbit()
    {
        rig.AddForce(directionSpeed, ForceMode2D.Impulse);
        InOrbit = true;
        ren.sprite = AsteroidSprite;
        transform.localScale = new Vector3(1f, 1f, 1f);
        col.enabled = true;
        transform.position = new Vector3(transform.position.x, transform.position.y, -1.3f);
    }

    void ApplyGravity()
    {
        directionPlanet = -transform.position;
        directionPlanet.Normalize();
        directionPlanet *= (OrbitRadius - Vector2.Distance(new Vector2(), transform.position)) * GravityMultiplier;

        rig.AddForce(directionPlanet);
    }

    /*void OnCollisionEnter2D(Collision2D col)
    {
        GameObject.Destroy(gameObject);
    }*/

}
