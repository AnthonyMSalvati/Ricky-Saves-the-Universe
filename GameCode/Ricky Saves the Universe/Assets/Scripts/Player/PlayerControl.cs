using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Vector3 oldPosition;
    int speed = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        if (Input.GetKey(KeyCode.Space))
        {
            // fire projectile
            // going to need some math here so the projectile launches from the outstreched hand and goes directly above the character. probably a 345-350 degree angle
        }
    }

    private void movePlayer()
    {
        int moveDirection = 0;
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection = -1;
        }

        oldPosition = transform.position;
        Vector3 moveDir = new Vector3(moveDirection, 0);

        Vector3 targetPosition = transform.position + moveDir * speed * Time.deltaTime;


        transform.position = targetPosition;

        /*RaycastHit2D collisionDetection = Physics2D.Raycast(transform.position, moveDir, speed * Time.deltaTime);

        if (collisionDetection.collider == null)
        {
            transform.position = targetPosition;
        }
        else
        {
        }*/


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Left Boundary")
        {
            transform.position = new Vector3(-12.9f, -6.58f, 0);
        }
        if (collision.tag == "Right Boundary")
        {
            transform.position = new Vector3(12.9f, -6.58f, 0);
        }
    }
    /*private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "Left Boundary")
        {
            Debug.Log("hit");
            
        }
        transform.position = oldPosition;
    }*/
}

