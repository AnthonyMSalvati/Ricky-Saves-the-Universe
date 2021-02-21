using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{

    public GameObject toiletPaperPwrUp;
    public GameObject maskPwrUp;
    public GameObject sanitizerPwrUp;
    public GameObject vaccinePwrUp;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnPowerups());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnPowerups()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(5);
            int rng = Random.Range(0, 10001);
            if (rng <= 10)
            {
                Instantiate(vaccinePwrUp, new Vector3(Random.Range(-12.75f, 12.75f), 6.1f, 0), Quaternion.Euler(0, 0, 0)); 
            }
            else if (11 < rng & rng < 2500)
            {
                Instantiate(maskPwrUp, new Vector3(Random.Range(-12.75f, 12.75f), 6.1f, 0), Quaternion.Euler(0, 0, 0));
            }
            else if (2501 < rng & rng < 3500)
            {
                Instantiate(sanitizerPwrUp, new Vector3(Random.Range(-12.75f, 12.75f), 6.1f, 0), Quaternion.Euler(0, 0, 0));
            }
            else if (1500 < rng & rng < 9000)
            {
                Instantiate(toiletPaperPwrUp, new Vector3(Random.Range(-12.75f, 12.75f), 6.1f, 0), Quaternion.Euler(0, 0, 0));
            }

        }
    }
}
