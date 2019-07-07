using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFunction : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject enemy;
    private int playerNo;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindWithTag("Player1");
        player2 = GameObject.FindWithTag("Player2");
        enemy = GameObject.FindWithTag("Enemy");
        if (gameObject.CompareTag("Player1"))
        {
            playerNo = 1;
        }
        
        if(gameObject.CompareTag("Player2"))
        {
            playerNo = 2;
        }
        print(playerNo);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, enemy.transform.position);

        if (playerNo == 1 & distance > 1 & Input.GetKeyDown(KeyCode.E))
        {
            print("player1 has attacked");
        }

        if (playerNo == 2 & distance > 1 & Input.GetKeyDown(KeyCode.O))
        {
            print("player2 has attacked");
        }
    }
}
