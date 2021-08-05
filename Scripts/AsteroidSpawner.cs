using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroid_prefab;

    private float minX, maxX;

    private float spawn_interval;

    private int min_asteroids, max_asteroids;

    // Start is called before the first frame update
    void Start()
    {
        CameraBounds();
        spawn_interval = 3.5f;
        min_asteroids = 3;
        max_asteroids = 8;
        Invoke("ActivateAsteroidSpawner", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CameraBounds()
    {
        minX = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        maxX = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;
    }

    private void ActivateAsteroidSpawner()
    {
        StartCoroutine(SpawnAsteroids());
        Invoke("ActivateAsteroidSpawner", spawn_interval);

    }

    IEnumerator SpawnAsteroids()
    {
        //yield return new WaitForSeconds(spawn_interval);
        int asteroid_count = Random.Range(min_asteroids, max_asteroids);
        Vector3 asteroid_current_position = transform.position;
        for(int i = 0; i<=asteroid_count; i++)
        {
            asteroid_current_position.x = Random.Range(minX, maxX);
            Instantiate(asteroid_prefab, asteroid_current_position, Quaternion.identity);
            //Null is gonna skip every next frame
            yield return null;
        }
        
    }
} // class
