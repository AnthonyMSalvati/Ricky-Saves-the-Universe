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
        int brickType = Random.Range(0,4);
        GameObject currentBrick;
        switch (brickType)
        {
            case 1:
                currentBrick = redBrickPrefab;
                break;
            case 2:
                currentBrick = orangeBrickPrefab;
                break;
            default:
                currentBrick = lightBrickPrefab;
                break;
        }
        Instantiate(currentBrick, throwPoint.position, throwPoint.rotation);
    }
}
