using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject[] playerTargets;
    [SerializeField] private float mSpeed= 5f; // enemy speed
    [SerializeField] private Rigidbody rb;
    

    // Start is called before the first frame update
    void Start()
    {   // same as playerTargets = GameObject.Find("Warrior");
        playerTargets = GameObject.FindGameObjectsWithTag("Players"); 
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTargets != null)
        {
            transform.LookAt(playerTargets[0].transform);
            transform.LookAt(playerTargets[1].transform);

            //move towards player
            //transform.position += transform.forward * mSpeed * Time.deltaTime;
            //rb.AddForce(Vector3.forward * Time.deltaTime * mSpeed);
            transform.Translate(transform.forward * mSpeed * Time.deltaTime);
        }
        else
            Debug.Log("No objects found");
        
    }
}
