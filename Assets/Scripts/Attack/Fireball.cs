using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject owner;
    [SerializeField] private int speed = 100;
    [SerializeField] private int fbDmg = 50;
    private PlayerStats playerStats;
    private EnemyStats enemyStats;

    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(0, 0, 1.1f);
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        StartCoroutine(waiter());
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            playerStats = owner.GetComponent<PlayerStats>();
            enemyStats = collision.gameObject.GetComponent<EnemyStats>();
            if(enemyStats.defence > 0)
            {
                enemyStats.defence = enemyStats.defence - (playerStats.damage + fbDmg);
            }
            if (enemyStats.defence <= 0)
            {
                enemyStats.health = enemyStats.health - (playerStats.damage + fbDmg);
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
    }
}
