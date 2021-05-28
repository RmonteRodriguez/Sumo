using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public EndlessSpawners endlessSpawners;

    public int foughtCount;
    public int winCount;
    public Text scoreText;
    public Text knockOfText;

    // Start is called before the first frame update
    void Start()
    {
        foughtCount = endlessSpawners.enemyCount;
        winCount = endlessSpawners.enemyCount - 1;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Enemies Fought: " + foughtCount;
        knockOfText.text = "Knock Offs: " + winCount;
    }
}
