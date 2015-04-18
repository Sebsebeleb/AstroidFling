using UnityEngine;
using System.Collections;

public class EarthManager : MonoBehaviour 
{

    public int lives;
    public bool noLives { get { return lives <= 0; } set { } }

	void Start () 
    {

        lives = 10;
	
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

        if (col.gameObject.tag == "enemy1")
        {
            lives--;
            Destroy(col.gameObject);
        }

    }

}
