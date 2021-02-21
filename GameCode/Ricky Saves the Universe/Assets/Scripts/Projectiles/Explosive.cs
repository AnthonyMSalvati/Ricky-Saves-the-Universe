using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{


    public float speed = 15f;
    public Rigidbody2D radial;
    public AudioSource explode;


    // Start is called before the first frame update
    void Start()
    {
        radial.velocity = transform.right * 0;
        explode = gameObject.GetComponent<AudioSource>();
        explode.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
