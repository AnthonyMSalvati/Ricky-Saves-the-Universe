using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{

    //public Sprite brick;
    //public Sprite boom;
    //public SpriteRenderer spriteRenderer;

    public float speed = 15f;
    public Rigidbody2D radial;


    // Start is called before the first frame update
    void Start()
    {
        radial.velocity = transform.right * 0;
       // spriteRenderer = GetComponent<SpriteRenderer>();
        //this.GetComponent<SpriteRenderer>().sprite = brick;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Covid"))
        {
            Debug.Log("colliding");
            
        }
        //this.GetComponent<SpriteRenderer>().sprite = boom;
        //StartCoroutine(explode());
    }

    IEnumerator explode()
    {
        Debug.Log("in subroutine");
        yield return new WaitForSecondsRealtime(2);
        Destroy(gameObject);
    }
}
