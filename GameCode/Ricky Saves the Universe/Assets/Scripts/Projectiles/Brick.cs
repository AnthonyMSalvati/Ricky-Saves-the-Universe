using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D brick;

    // Start is called before the first frame update
    void Start()
    {
        brick.velocity = transform.right * -speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject); //cleans up bricks so resources are freed back up
    }

}
