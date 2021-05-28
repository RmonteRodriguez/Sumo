using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummitManager : MonoBehaviour
{
    //Timer
    public Text timeText;
    public float time;
    private float timePerSecond;

    //Snowball Spawner
    public GameObject snowBalls;
    public Transform snowBallSpawner;
    public float respawnTime = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnSnowBall());
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        respawnTime = respawnTime - 0.01f * Time.deltaTime;   

    }

    IEnumerator SpawnSnowBall()
    {
        while (true)
        {
            Instantiate(snowBalls, snowBallSpawner, snowBallSpawner);
        }
    }

    public void Timer()
    {
        timeText.text = (int)time + "Seconds";
        time += timePerSecond * Time.deltaTime;
    }
}
