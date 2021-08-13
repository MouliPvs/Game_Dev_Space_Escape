using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy_big, enemy_small;

    [SerializeField]
    private bool spawn_big_enemy, spawn_small_enemy;

    private float enemies_spawn_time;
    // Start is called before the first frame update
    void Start()
    {
        enemies_spawn_time = 3f;
        Invoke("SpawnEnimies", enemies_spawn_time);

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void SpawnEnimies()
    {
        GameObject temp = null;
        if (spawn_big_enemy)
        {
            temp = Instantiate(enemy_big, transform.position, Quaternion.identity);
        }
        if (spawn_small_enemy)
        {
            temp = Instantiate(enemy_small, transform.position, Quaternion.identity);
        }
        temp.GetComponent<EnemyScript>().enemySpawner = this;
    }

    public void ActivateEnemySpawning()
    {
        Invoke("SpawnEnimies", enemies_spawn_time);
    }
}   // class
