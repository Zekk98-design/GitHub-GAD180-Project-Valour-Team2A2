using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy AI for Normal monsters and Boss.
/// Attach this to enemy prefabs
/// </summary>
[RequireComponent(typeof(Rigidbody))]

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject Player1;
    [SerializeField] private GameObject Player2;
   
    [SerializeField] private float mSpeed= 3f; // enemy speed

    private Rigidbody rb;
    private float curDistance = 1000f;


    // Start is called before the first frame update
    void Start()
    {   //find characters with matched tag
        Player1 = GameObject.FindGameObjectWithTag("Player1");
        Player2 = GameObject.FindGameObjectWithTag("Player2");

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance1= Mathf.Infinity;
        float distance2 = Mathf.Infinity;


        if (Player1 != null)
        {
            distance1 = Vector3.Distance(transform.position, Player1.transform.position); // get distance between Enemy and Character
        }

        if (Player2 != null)
        {
            distance2 = Vector3.Distance(transform.position, Player2.transform.position);
        }


        //find if it is closest to P1
        if (distance1 < distance2) 
        {
            curDistance = distance1;
            transform.LookAt(Player1.transform);
            //move to player 
            if (distance1 > 2f )
            {

                rb.AddForce(transform.forward * mSpeed * Time.deltaTime * 100);
            }
            // when close...
            else
            {
                // ...attack
            }

        }
        //find if it is closest to P2
        if (distance2 < distance1)
        {
            curDistance = distance2;

            transform.LookAt(Player2.transform);
            
            if (curDistance > 2f)
            {
                //rb.velocity = transform.forward * mSpeed * Time.deltaTime * 100;
                rb.AddForce(transform.forward * mSpeed * Time.deltaTime * 100);

            }
            // when close...
            else
            {
                // ...attack
            }

        }
    }

}
