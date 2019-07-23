using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public GameObject owner;
    public Leaderboard lBoard;
    public float maxHealth = 10;
    public float damage = 1;
    public float health = 10;
    public float defence = 3;

    // Start is called before the first frame update
    void Start()
    {
        GameObject EGO = GameObject.Find("EGO Spawn");
        lBoard = EGO.GetComponent<Leaderboard>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            if (owner.CompareTag("Player1"))
            {
                ++lBoard.p1Kill;
            }
            if (owner.CompareTag("Player2"))
            {
                ++lBoard.p2Kill;
            }
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            owner = collision.gameObject;
        }
        if (collision.gameObject.CompareTag("Player2"))
        {
            owner = collision.gameObject;
        }
        else
        {
            GameObject arrow = collision.gameObject;
            owner = collision.gameObject.GetComponent<ArrowScript>().owner;
        }
    }
}
