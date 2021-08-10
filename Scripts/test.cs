using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 3.5f;

    private float rotationSpeed = 200f;

    private float value = 0.8873759f;

    private Transform playerTarget;

    private Rigidbody2D myBody;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {
        //StartCoroutine(Test());
        //Debug.Log((Vector2)transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //if (Input.GetKeyDown("space"))
        //{
        //    Debug.Log("Space Pressed");
        //    FollowPlayer();
        //}
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (playerTarget == null)
        {
            return;
        }

        //if (Input.GetKeyDown("space"))
        //{
        //    Vector2 point2Player = (Vector2)transform.position - (Vector2)playerTarget.transform.position;
        //    Debug.Log("Enemy Position   :   " + (Vector2)transform.position);
        //    Debug.Log("Player Position   :   " + (Vector2)playerTarget.transform.position);
        //    Debug.Log("AI Position   :   " + point2Player);
        //    point2Player.Normalize();

        //    float value = Vector3.Cross(point2Player, transform.up).z;
        //    Debug.Log("Cross Product  :   " + value);

        //    myBody.velocity = transform.up * speed;
        //    myBody.angularVelocity = rotationSpeed * value;
        //    //Debug.Log("Space Pressed");
        //    //myBody.angularVelocity = rotationSpeed;
        //}
        //if (Input.GetKeyDown("w"))
        //{
        //    Debug.Log("W Pressed");
        //    myBody.angularVelocity = 1000f;
        //}

        Vector2 point2Player = (Vector2)transform.position - (Vector2)playerTarget.transform.position;
        Debug.Log("Enemy Position   :   " + (Vector2)transform.position);
        Debug.Log("Player Position   :   " + (Vector2)playerTarget.transform.position);
        Debug.Log("AI Position   :   " + point2Player);
        point2Player.Normalize();

        float value = Vector3.Cross(point2Player, transform.up).z;
        Debug.Log("Cross Product  :   " + value);

        myBody.velocity = transform.up * speed;
        myBody.angularVelocity = rotationSpeed * value;

        //myBody.angularVelocity = rotationSpeed * value;
        //Debug.Log("Cross Product  :   " + value);
        //value -= 0.0302461f;
    }

    /// <summary>
    /// Moves The Player for 1 grid unit / second
    /// </summary>
    /// <returns></returns>
    IEnumerator Test()
    {
        yield return new WaitForSeconds(1f);
        transform.Translate(new Vector2(1f, 1f));
        //transform.position gives vector3 co-ordinates
        Debug.Log((Vector2)transform.position);
        StartCoroutine(Test());
    }
}
