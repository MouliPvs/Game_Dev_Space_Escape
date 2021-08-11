using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float enemy_speed , enemy_rotational_speed;

    private Transform player_object;

    private Rigidbody2D enemy_body;

    private Vector2 enemy_position, player_position;
    // Start is called before the first frame update

    private void Awake()
    {
        //Dont harcode like this "Player" create seperate script that have all these strings
        player_object = GameObject.FindWithTag("Player").transform;
        Debug.Log(player_object);
        enemy_body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        enemy_speed = 2.5f;
        enemy_rotational_speed = 200f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Fixed Update Is Used When Physics Is Involved
    private void FixedUpdate()
    {
        if (player_object.tag == null)
        {
            return;
        }
        enemy_position = (Vector2)transform.position;
        player_position = (Vector2)player_object.position;

        Vector2 enemy_to_player_distance = enemy_position - player_position;
        enemy_to_player_distance.Normalize();

        float rotaion_value = Vector3.Cross(enemy_to_player_distance, transform.up).z;
        enemy_body.velocity = transform.up * enemy_speed;
        enemy_body.angularVelocity = enemy_rotational_speed * rotaion_value;

    }



} // class
