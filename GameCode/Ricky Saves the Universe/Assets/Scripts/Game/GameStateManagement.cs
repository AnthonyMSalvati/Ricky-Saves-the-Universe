using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class GameStateManagement : MonoBehaviour
{
    static CovidRemaining remaining = new CovidRemaining();
    static int score = 0;
    float round;
    public GameObject player;
    public GameObject covid;
    private static List<Object> tokens = new List<Object>();


    // Start is called before the first frame update
    void Start()
    {
        round = 10;
        startNewRound(round);
    }

    // Update is called once per frame
    void Update()
    {
        if (remaining.getCovidRemaining() == 0)
        {
            round *= 1.25f;
            startNewRound(round);
        }
        if (player.GetComponent<PlayerControl>().getHP() == 0)
        {
            writeScore();
        }

    }

    public void giveToken()
    {
        tokens.Add(new Object());
    }

    public bool getToken()
    {       
        if (tokens.Count >= 1)
        {
            tokens.Remove(tokens[tokens.Count - 1]);
            return true;
        }
        else return false;
    }

    void startNewRound(float round)
    {
        new WaitForSecondsRealtime(3); //give some breathing time
        tokens.Clear(); //resets number of attackers 
        for (int i = 0; i < round; i++)
        {
            Instantiate(covid, new Vector3(Random.Range(-12.75f, 12.75f), Random.Range(2.25f, 7.35f), 0), Quaternion.Euler(0, 0, 0)); //spawns in enemies           
        }
        for (int i = 0; i < round/4; i++)
        {
            tokens.Add(new Object()); //sets limit on number of attackers
        }
        tokens.Add(new Object());
        remaining.setCovidRemaining((int)round);

    }

    public void recordDeath()
    {
        remaining.decrement();
        score += 5;
    }

    public void addToScore(int num) //exists only because i'm tired and needed to hack this together, much like a lot of this other code
    {
        score += num;
    }

    public int getScore()
    {
        return score;
    }
    static void writeScore()
    {
        string path = "C:\\Users\\Public\\Score.csv";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "score: " + score.ToString());
        }
    }

}

public class CovidRemaining
{
    private static int covid = 0;

    public void setCovidRemaining(int number)
    {
        covid = number;
    }

    public int getCovidRemaining()
    {
        return covid;
    }

    public void increment()
    {
        covid++;
    }

    public void decrement()
    {
        covid--;
    }
}
