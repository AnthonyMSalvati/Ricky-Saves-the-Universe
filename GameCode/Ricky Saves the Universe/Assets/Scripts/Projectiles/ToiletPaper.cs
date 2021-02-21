using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletPaper : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D toiletPaper;
    private static float ttl;
    public AudioSource whoosh;
    public AudioClip throwNoise;

    // Start is called before the first frame update
    void Start()
    {
        whoosh = gameObject.GetComponent<AudioSource>();
        whoosh.PlayOneShot(throwNoise, .05f);
        ttl = Time.time;
        toiletPaper.velocity = transform.right * -speed;
    }
    private void Update()
    {
        if (Time.time - ttl > 6)
        {
            Destroy(gameObject);
        }
    }
}
