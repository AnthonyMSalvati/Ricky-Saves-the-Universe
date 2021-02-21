using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TextEdit : MonoBehaviour
{
    public GameObject mgmr;

    public Text text;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        int score = mgmr.GetComponent<GameStateManagement>().getScore();

        text.text = "Score: " + score;
        System.IO.File.WriteAllText("C:\\Users\\Public\\Score.csv", "score," + score.ToString());
    }
}
