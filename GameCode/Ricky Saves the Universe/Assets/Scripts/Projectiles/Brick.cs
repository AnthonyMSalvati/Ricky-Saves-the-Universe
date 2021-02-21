using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D brick;
    private bool isExplosive = false;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        brick.velocity = transform.right * -speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (isExplosive & collision.CompareTag("Covid"))
        {
            GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(expl, 2);
        }
        else
        {
            Destroy(gameObject); //cleans up bricks so resources are freed back up
        }
    }


    public void setExplosive()
    {
        isExplosive = true;
    }
}
