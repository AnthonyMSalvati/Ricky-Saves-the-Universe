using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public GameObject player;
    public GameObject thorn;
    public GameObject gameStateManager;
    public Transform throwPoint;
    bool canAttack;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(attack());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator attack()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(Random.Range(1.2f, 1.75f));
            Vector3 playerPosition = player.GetComponent<PlayerControl>().getPosition();
            if (gameStateManager.GetComponent<GameStateManagement>().getToken())
            {
                canAttack = true;
            }
            if (canAttack)
            {
                canAttack = false;

                float hypotenuse = Mathf.Sqrt(Mathf.Pow(playerPosition.x - transform.position.x, 2) + Mathf.Pow(transform.position.y, 2));
                float oppA = playerPosition.x - transform.position.x;
                float firingAngle = findAngle(oppA, hypotenuse);
                Quaternion rotation = Quaternion.Euler(0, 0, firingAngle);
                Instantiate(thorn, throwPoint.position, rotation);
            }
            yield return new WaitForSecondsRealtime(Random.Range(1.2f, 2.5f));
            gameStateManager.GetComponent<GameStateManagement>().giveToken();

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Brick") ^ (collision.tag == "TP") ^ (collision.tag == "Radial"))
        {
            recordDeath();
            Destroy(gameObject);
        }

    }

    private float findAngle(float opposite, float hypotenuse)
    {

        float offset = Random.Range(-1.025f, 1.025f);
        return offset * (Mathf.Rad2Deg * Mathf.Sin(opposite/hypotenuse));
    }

    private void recordDeath()
    {
        gameStateManager.GetComponent<GameStateManagement>().recordDeath();
    }
}



