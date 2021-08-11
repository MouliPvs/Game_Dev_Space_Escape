using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    private float lower_boundary;
    // Start is called before the first frame update
    void Start()
    {
        lower_boundary = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).y;

    }

    // Update is called once per frame
    void Update()
    {
        DeactivateAsteroids();
    }

    /// <summary>
    /// If the asteroids hits the enemy. enemy gets deactivated.
    /// </summary>
    /// <param name="target"></param>
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {
            target.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Deactivates Asteroids Once They Hit The Lower Boundary
    /// </summary>
    private void DeactivateAsteroids()
    {
        if (transform.position.y < lower_boundary)
        {
            gameObject.SetActive(false);
        }
    }

}
