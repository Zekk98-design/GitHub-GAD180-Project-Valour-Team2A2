using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = GameObject.Find("Player").transform;
        transform.Translate(0, 0, 1f);
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            PlayerStats playerStats = gameObject.GetComponentInParent<PlayerStats>();
            EnemyStats enemyStats = collision.gameObject.GetComponent<EnemyStats>();
            enemyStats.health = enemyStats.health - playerStats.damage;
            Destroy(gameObject);
        }
    }
}
