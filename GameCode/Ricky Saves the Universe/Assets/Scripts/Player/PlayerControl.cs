using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    int speed = 10;
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

        Vector3 moveDir = new Vector3(moveDirection, 0);
        Vector3 targetPosition = transform.position + moveDir * speed * Time.deltaTime;


        transform.position = targetPosition;

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
        if (collision.tag == "Barb")
        {
            Debug.Log("got hit by barb");
            Destroy(gameObject);
        }
    }

    public Vector3 getPosition()
    {
        return transform.position;
    }
}

