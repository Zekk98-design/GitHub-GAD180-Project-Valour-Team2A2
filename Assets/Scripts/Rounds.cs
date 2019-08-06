using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Rounds : MonoBehaviour
{
    public MenuPauser menu;
    public float roundTimer = 60.0f;
    public float timer;
    [SerializeField] private int roundCount;
    public EnemySpawn enemySpawn;
    public Text timerText;
    private int enemyCount;
    private int maxRound = 2;


    // Start is called before the first frame update
    void Start()
    {
        timer = roundTimer;
        roundCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (menu.timer == true)
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

            //move to leaderboard
            if (roundCount > maxRound)
            {
                SceneManager.LoadScene(5);
            }
        }
    }
}
