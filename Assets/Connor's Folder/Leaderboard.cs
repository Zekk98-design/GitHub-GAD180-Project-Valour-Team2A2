using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        PlayerSet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Scores()
    {

    }

    private void PlayerSet()
    {
        p1 = GameObject.FindGameObjectWithTag("Player1");
        p2 = GameObject.FindGameObjectWithTag("Player2");
        p1Stats = p1.gameObject.GetComponent<PlayerStats>();
        p2Stats = p2.gameObject.GetComponent<PlayerStats>();
    }
}
