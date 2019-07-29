using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private string currentScene;
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
    [SerializeField] private Text p1DmgT;
    [SerializeField] private Text p1KillT;
    [SerializeField] private Text p1DeathT;
    [SerializeField] private Text p2DmgT;
    [SerializeField] private Text p2KillT;
    [SerializeField] private Text p2DeathT;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerSet();
        currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Leaderboard")
        {
            print("Leaderboard");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Leaderboard")
        {
            Scores();
        }
    }

    private void Scores()
    {
        p1DmgT = GameObject.Find("P1 Dmg").GetComponent<Text>();
        p1DmgT.text = p1Dmg.ToString();
        p1KillT = GameObject.Find("P1 Kill").GetComponent<Text>();
        p1KillT.text = p1Kill.ToString();
        p1DeathT = GameObject.Find("P1 Death").GetComponent<Text>();
        p1DeathT.text = p1Death.ToString();
        p2DmgT = GameObject.Find("P2 Dmg").GetComponent<Text>();
        p2DmgT.text = p2Dmg.ToString();
        p2KillT = GameObject.Find("P2 Kill").GetComponent<Text>();
        p2KillT.text = p2Kill.ToString();
        p2DeathT = GameObject.Find("P2 Death").GetComponent<Text>();
        p2DeathT.text = p2Death.ToString();
    }

    private void PlayerSet()
    {
        p1 = GameObject.FindGameObjectWithTag("Player1");
        p2 = GameObject.FindGameObjectWithTag("Player2");
        p1Stats = p1.gameObject.GetComponent<PlayerStats>();
        p2Stats = p2.gameObject.GetComponent<PlayerStats>();
    }
}
