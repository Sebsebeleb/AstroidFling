using UnityEngine;
using System.Collections;

public class EarthManager : MonoBehaviour 
{

    public int lives;
    public bool noLives { get { return lives <= 0; } set { } }
    private CameraControl shake;
    public AudioClip explosion;

	void Start () 
    {

        lives = 10;
        shake = Camera.main.gameObject.GetComponent<CameraControl>();
	
	}
	
	void Update ()
    {

        if (noLives)
        {
            /*Death*/
            Application.LoadLevel(Application.loadedLevel);
        }
	
	}

    public void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "enemy1" || col.gameObject.tag == "asteroid")
        {
            /*Sound*/
            shake.StartShake(0.7f, 2f);
            lives--;
            Destroy(col.gameObject);
        }

    }

    public void OnGUI()
    {

        GUI.Label(new Rect(50, 8, 100, 25), "Lives " + lives);

    }

}
