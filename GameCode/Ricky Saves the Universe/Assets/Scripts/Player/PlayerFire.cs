using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{

    public Transform throwPoint;
    public GameObject redBrickPrefab;
    public GameObject orangeBrickPrefab;
    public GameObject lightBrickPrefab;
    public GameObject toiletPaperPrefab;
    public GameObject explosionPrefab;
    public GameObject player;
    private static bool isExplosive = false;
    private static string ammoType = "brick";

    // Update is called once per frame
    void Update()
    {
        setAmmoType();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Throw();
        }       
    }

    void Throw()
    {
        switch (ammoType)
        {
            case "toiletpaper":
                Instantiate(toiletPaperPrefab, throwPoint.position, Quaternion.Euler(0, 0, 0));
                break;
            case "brick":
                int brickType = Random.Range(0, 4);
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
                if (isExplosive)
                {
                    GameObject explosive = Instantiate(currentBrick, throwPoint.position, throwPoint.rotation);
                    explosive.GetComponent<Brick>().setExplosive();
                }
                else
                {
                    Instantiate(currentBrick, throwPoint.position, throwPoint.rotation);
                }
                break;
        }
       
    }

    void setAmmoType()
    {
        
        string type = player.GetComponent<PlayerControl>().getAmmoType();
        switch (type)
        {
            case ("TP"):
                ammoType = "toiletpaper";
                isExplosive = false;
                break;
            case ("Radial"):
                ammoType = "brick";
                isExplosive = true;
                break;
            case ("Brick"):
                ammoType = "brick";
                isExplosive = false;
                break;
        }       
    }
}
