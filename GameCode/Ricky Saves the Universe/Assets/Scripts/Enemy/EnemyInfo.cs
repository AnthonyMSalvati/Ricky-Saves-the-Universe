using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public GameObject player;
    public GameObject thorn;
    public Transform throwPoint;
    bool canAttack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.GetComponent<PlayerControl>().getPosition();
        
        if (canAttack)
        {
            float firingAngle = findAngle(playerPosition.x - transform.position.x, transform.position.y);
            Quaternion rotation = Quaternion.Euler(0, firingAngle, 0);
            Instantiate(thorn, throwPoint.position, rotation);
        }
                          
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Brick")
        {
            Destroy(gameObject);
        }

    }

    private float findAngle(float opposite, float adjacent)
    {
        return Mathf.Rad2Deg * Mathf.Atan(opposite/adjacent);
    }
}


