using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rounds : MonoBehaviour
{
    public float roundTimer = 60.0f;
    public float timer;
    private int roundCount;
    public EnemySpawn enemySpawn;
    public Text timerText;
    private int enemyCount;


    // Start is called before the first frame update
    void Start()
    {
        timer = roundTimer;
        roundCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - Time.deltaTime;
        int min = Mathf.FloorToInt(timer / 60);
        int sec = Mathf.FloorToInt(timer % 60);
        timerText.text = min.ToString("00") + ":" + sec.ToString("00");
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        // reset and increment round counter
        if (timer <= 0 & enemyCount == 0)
        {
            timer = roundTimer;
            enemySpawn.maxSpawn = enemySpawn.maxSpawn / 3;
            enemySpawn.iniSpawn = 1;
            ++roundCount;
        }

        // spawn BBEG
        if (roundCount == 2 & enemySpawn.bbegSpawn < 1)
        {
            Instantiate(enemySpawn.bbegModel, transform.position + enemySpawn.spawn, transform.rotation);
            ++enemySpawn.bbegSpawn;
        }
    }
}
