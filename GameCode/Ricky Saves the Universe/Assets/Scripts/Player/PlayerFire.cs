using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{

    public Transform throwPoint;
    public GameObject redBrickPrefab;
    public GameObject orangeBrickPrefab;
    public GameObject lightBrickPrefab;

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {
            Throw();
        }
    }

    void Throw()
    {
        UnityEngine.Random rnd = new UnityEngine.Random();
        Instantiate(lightBrickPrefab, throwPoint.position, throwPoint.rotation);
    }
}
