using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    private Leaderboard lBoard;
    public GameObject owner;
    public EnemyStats enemyStats;

    // Start is called before the first frame update
    void Start()
    {
        GameObject EGO = GameObject.Find("EGO Spawn");
        lBoard = EGO.GetComponent<Leaderboard>();
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        StartCoroutine(waiter());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            PlayerStats playerStats = owner.GetComponent<PlayerStats>();
            enemyStats = collision.gameObject.GetComponent<EnemyStats>();
            enemyStats.health = enemyStats.health - playerStats.damage;
            if(owner.transform.root.CompareTag("Player1"))
            {
                lBoard.p1Dmg = lBoard.p1Dmg + playerStats.damage;
            }
            if(owner.transform.root.CompareTag("Player2"))
            {
                lBoard.p2Dmg = lBoard.p2Dmg + playerStats.damage;
            }
            Destroy(gameObject);
        }

        if (collision.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
