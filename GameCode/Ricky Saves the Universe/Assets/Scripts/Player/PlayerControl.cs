using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Sprite defaultspr;
    public Sprite masked;
    public SpriteRenderer spriteRenderer;   

    int speed = 10;
    private int HP = 1;
    private float spriteChangeTime;
    private string ammo = "Brick";
    private float pwrUpStart = 0;

    public GameObject scoreUpdate;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        if (this.GetComponent<SpriteRenderer>().sprite == masked)
        {
            if ((Time.time - spriteChangeTime) > 3)
            {
                HP = 1;
                this.GetComponent<SpriteRenderer>().sprite = defaultspr;
            }
        }
        if (ammo != "Brick")
        {
            if ((Time.time - pwrUpStart) > 3)
            {
                ammo = "Brick";
            }
        }
        
    }

    private void movePlayer()
    {
        int moveDirection = 0;
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection = -1;
        }

        Vector3 moveDir = new Vector3(moveDirection, 0);
        Vector3 targetPosition = transform.position + moveDir * speed * Time.deltaTime;


        transform.position = targetPosition;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log(collision.tag);
        if (collision.CompareTag("Left Boundary"))
        {
            transform.position = new Vector3(-12.9f, -6.58f, 0);
        }
        if (collision.CompareTag("Right Boundary"))
        {
            transform.position = new Vector3(12.9f, -6.58f, 0);
        }
        if (collision.CompareTag("Barb"))
        {
            HP--;
            if (HP < 1)
            {
                Destroy(gameObject);
            }
        }
        if (collision.CompareTag("PwrUpTP"))
        {
            ammo = "TP";
            pwrUpStart = Time.time;
        }
        if (collision.CompareTag("PwrUpHandSanitizer"))
        {
            ammo = "Radial";
            pwrUpStart = Time.time;

        }
        if (collision.CompareTag("Mask"))
        {
            HP = 3;
            this.GetComponent<SpriteRenderer>().sprite = masked;
            spriteChangeTime = Time.time;
        }
        if (collision.CompareTag("PwrUpVaccine"))
        {
            scoreUpdate.GetComponent<GameStateManagement>().addToScore(1000000); //super rare drop, million free points
        }
    }

    public Vector3 getPosition()
    {
        return transform.position;
    }

    public string getAmmoType()
    {
        return ammo;
    }

    public int getHP()
    {
        return HP;
    }
}

