using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float player_speed, player_rotational_speed, user_input_horizantal_axis;
    // Start is called before the first frame update
    void Start()
    {

        player_speed = 3f;
        player_rotational_speed = 200f;
    }

    // Update is called once per frame
    void Update()
    {

        //transform.Translate(new Vector2(0, 1));
        user_input_horizantal_axis = Input.GetAxisRaw("Horizontal");

        //Vector2.up = new Vector2D(0, 1)
        //When called in update() it moves the player in y direction for every frame coz update will be called for every frame
        //Self means it use cooridinates relative to the "Plane/Player" not relative to the unity world
        transform.Translate(Vector2.up * player_speed * Time.deltaTime, Space.Self);



        //Negative axis because in default if you press left it will go right
        transform.Rotate(Vector3.forward * -user_input_horizantal_axis * player_rotational_speed * Time.deltaTime);


    }
}  // class
