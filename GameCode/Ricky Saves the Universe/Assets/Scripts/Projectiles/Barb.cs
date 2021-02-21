using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barb : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D barb;
    private static float ttl;

    // Start is called before the first frame update
    void Start()
    {
        ttl = Time.time;
        barb.velocity = transform.up * -speed;
    }

    private void Update()
    {
        if (Time.time - ttl > 3)
        {
            Destroy(gameObject);
        }
    }
}
