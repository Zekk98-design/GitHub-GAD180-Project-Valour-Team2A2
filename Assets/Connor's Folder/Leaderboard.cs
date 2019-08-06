using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public float p1Dmg;
    public int p1Kill;
    public int p1Death;
    public float p2Dmg;
    public int p2Kill;
    public int p2Death;
    private GameObject p1;
    private GameObject p2;
    private PlayerStats p1Stats;
    private PlayerStats p2Stats;
    public Text p1DmgT;
    public Text p1KillT;
    public Text p1DeathT;
    public Text p2DmgT;
    public Text p2KillT;
    public Text p2DeathT;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
        
    // Start is called before the first frame update
    void Start()
    {
        PlayerSet();
    }

    // Update is called once per frame
    void Update()
    {
        Scores();
    }

    private void Scores()
    {
        //getting active scene to load numbers into text
        if (SceneManager.GetActiveScene().name == "Leaderboard")
        {
            //loading data into UI text
            //Player 1 damage
            GameObject p1DmgGO = GameObject.Find("P1 Dmg");
            p1DmgT = p1DmgGO.GetComponent<Text>();
            p1DmgT.text = p1Dmg.ToString();
            //Player 1 kills
            GameObject p1KillGO = GameObject.Find("P1 Kill");
            p1KillT = p1KillGO.GetComponent<Text>();
            p1KillT.text = p1Kill.ToString();
            //Player 1 deaths
            GameObject p1DeathGO = GameObject.Find("P1 Death");
            p1DeathT = p1DeathGO.GetComponent<Text>();
            p1DeathT.text = p1Death.ToString();
            //Player 2 damage
            GameObject p2DmgGO = GameObject.Find("P2 Dmg");
            p2DmgT = p2DmgGO.GetComponent<Text>();
            p2DmgT.text = p2Dmg.ToString();
            //Player 2 kills
            GameObject p2KillGO = GameObject.Find("P2 Kill");
            p2KillT = p2KillGO.GetComponent<Text>();
            p2KillT.text = p2Kill.ToString();
            //Player 2 deaths
            GameObject p2DeathGO = GameObject.Find("P2 Death");
            p2DeathT = p2DeathGO.GetComponent<Text>();
            p2DeathT.text = p2Death.ToString();
        }
    }

    private void PlayerSet()
    {
        p1 = GameObject.FindGameObjectWithTag("Player1");
        p2 = GameObject.FindGameObjectWithTag("Player2");
        p1Stats = p1.gameObject.GetComponent<PlayerStats>();
        p2Stats = p2.gameObject.GetComponent<PlayerStats>();
    }
}
