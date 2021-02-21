using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManagement : MonoBehaviour
{    
    int covidRemaining = 0;
    int score = 0;
    float round = 1f;
    bool covidEliminated = false;
    public GameObject player;
    private List<GameObject> remaining;
    public GameObject covid;


    // Start is called before the first frame update
    void Start()
    {
        new WaitForSecondsRealtime(3);
        for (int i = 0; i < 200; i++ )
        {
            Instantiate(covid, new Vector3(Random.Range(-12.75f, 12.75f), Random.Range(2.25f, 7.35f), 0), Quaternion.Euler(0,0,0));
        }
    }

    // Update is called once per frame
    void Update()
    {


        //GameObject[] covid = GameObject.FindGameObjectsWithTag("Covid");
        //covidRemaining = covid.Length;

        if (covidRemaining == 0)
        {
            round *= 1.15f;
        }

    }

    //public void Enemy

    void spawnCovid(int number)
    {
        for (int i = 0; i < number; i++)
        {

        }
    }

}
