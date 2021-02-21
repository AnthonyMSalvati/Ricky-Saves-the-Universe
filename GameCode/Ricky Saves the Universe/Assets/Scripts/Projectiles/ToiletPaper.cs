using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletPaper : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D toiletPaper;
    private static float ttl;


    // Start is called before the first frame update
    void Start()
    {
        toiletPaper.velocity = transform.up * -speed;
    }
    private void Update()
    {
        if (Time.time - ttl > 6)
        {
            Destroy(gameObject);
        }
    }

}
