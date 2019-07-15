using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public GameObject owner;

    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(0, 0, 1.1f);
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
            EnemyStats enemyStats = collision.gameObject.GetComponent<EnemyStats>();
            enemyStats.health = enemyStats.health - playerStats.damage;
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
