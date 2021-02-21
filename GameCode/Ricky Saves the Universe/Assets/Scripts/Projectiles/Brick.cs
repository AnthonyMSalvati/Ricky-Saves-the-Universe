using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public float speed = 12f;
    public Rigidbody2D brick;
    private bool isExplosive = false;
    public GameObject explosion;
    float ttl = 0;

    // Start is called before the first frame update
    void Start()
    {
        brick.velocity = transform.right * -speed;
        ttl = Time.time;
    }

    private void Update()
    {
        if (Time.time - ttl > 4)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isExplosive & collision.CompareTag("Covid"))
        {
            GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(expl, 2);
        }
        else if (collision.CompareTag("Covid"))
        {
            Destroy(gameObject); //cleans up bricks so resources are freed back up
        }
    }


    public void setExplosive()
    {
        isExplosive = true;
    }
}
