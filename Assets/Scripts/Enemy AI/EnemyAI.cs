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
    public MenuPauser menu;
    [SerializeField] private GameObject Player1;
    [SerializeField] private GameObject Player2;
   
    [SerializeField] private float mSpeed= 2f; // enemy speed
    private CharacterAnimations playerAnimations;
    private Rigidbody rb;

    private float curDistance = 1000.0f;

    //Wander state var
    private float _stoppingDistance = 2.0f;
    private Vector3 _destination;
    private Quaternion _desiredRotation;
    private Vector3 _direction;


    // Start is called before the first frame update
    void Start()
    {   //find characters with matched tag
        Player1 = GameObject.FindGameObjectWithTag("Player1");
        Player2 = GameObject.FindGameObjectWithTag("Player2");

        GameObject Spawn = GameObject.Find("EGO Spawn");
        menu = Spawn.GetComponent<MenuPauser>();

        playerAnimations = GetComponent<CharacterAnimations>();
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToP1= Mathf.Infinity;
        float distanceToP2 = Mathf.Infinity;

        if (menu.eAI == true)
        {
            if (Player1 != null)
            {
                distanceToP1 = Vector3.Distance(transform.position, Player1.transform.position); // get distance between Enemy and Character
            }

            if (Player2 != null)
            {
                distanceToP2 = Vector3.Distance(transform.position, Player2.transform.position);
            }

            //find if it is closer to P1
            if (distanceToP1 < distanceToP2)
            {
                curDistance = distanceToP1;
                
                //move to player 1
                if (curDistance >= 2f && curDistance < 12f)
                {
                    transform.LookAt(Player1.transform);
                    transform.Translate(Vector3.forward * mSpeed* Time.deltaTime);
                    // Play Walk animation
                    WalkAnimation();

                }  
                if (curDistance >= 12.0f)
                {
                    rb.velocity = Vector3.zero;
                    //Play walk animation
                    WalkAnimation();
                }
                // when close...
                if (curDistance < 2f)
                {
                    // ...attack
                }

            }
            //find if it is closer to P2
            if (distanceToP2 < distanceToP1)
            {
                curDistance = distanceToP2;

                //move to player 2
                if (curDistance >= 2f && curDistance < 12f)
                {
                    transform.LookAt(Player2.transform);
                    transform.Translate(Vector3.forward * mSpeed * Time.deltaTime);
                    // Play Walk animation
                    WalkAnimation();

                }
                if (curDistance >= 12.0f)
                {
                    rb.velocity = Vector3.zero;
                    //Play walk animation
                    WalkAnimation();
                }
                
                // when close...
                if (curDistance < 2f)
                {
                    // ...attack
                }
            }
        }
        if (menu.eAI == false)
        {
            //rb.velocity = Vector3.zero;
            transform.Translate( Vector3.zero);
            //rb.angularVelocity = Vector3.zero;
        }
        

    }//end update

    public void WalkAnimation()
    {
        if (rb.velocity.sqrMagnitude != 0f)
        {
            playerAnimations.Walk(true);
        }
        else
            playerAnimations.Walk(false);
    }

   
}
