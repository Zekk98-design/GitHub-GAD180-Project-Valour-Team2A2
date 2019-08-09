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
    private Vector3 movement;

    //Wander state var
    private float _stoppingDistance = 1.5f;
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
        movement = Vector3.zero;
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

            //find if it is closer to P1...........................................
            if (distanceToP1 < distanceToP2)
            {
                curDistance = distanceToP1;
                
                //Chasing State to player 1
                if (curDistance > 1.3f && curDistance < 16f)
                {
                    transform.LookAt(Player1.transform);
                    transform.Translate(Vector3.forward * mSpeed* Time.deltaTime);
                    Vector3 temp = transform.position;
                    movement = temp;
                    // Play Walk animation
                    WalkAnimation();
                    
                }  
                //Wandering State
                if (curDistance >= 16.0f)
                {
                    if (NeedsDestination())
                    {
                        GetDestination();
                    }
                    transform.rotation = _desiredRotation;
                    transform.Translate(Vector3.forward * Time.deltaTime * mSpeed);

                    //Play walk animation
                    WalkAnimation();
                }
                //Attacking State
                if (curDistance <= 1.3f)
                {
                    movement = Vector3.zero;
                    rb.velocity = Vector3.zero;
                    transform.LookAt(Player1.transform);
                    WalkAnimation();
                    // ...attack
                }
            }

            //find if it is closer to P2............................................
            if (distanceToP2 < distanceToP1)
            {
                curDistance = distanceToP2;

                //Chasing State to player 1
                if (curDistance > 1.3f && curDistance < 16f)
                {
                    transform.LookAt(Player2.transform);
                    transform.Translate(Vector3.forward * mSpeed * Time.deltaTime);
                    Vector3 temp = transform.position;
                    movement = temp;
                    // Play Walk animation
                    WalkAnimation();

                }
                //Wandering State
                if (curDistance >= 16.0f)
                {
                    if (NeedsDestination())
                    {
                        GetDestination();
                    }
                    transform.rotation = _desiredRotation;
                    transform.Translate(Vector3.forward * Time.deltaTime * mSpeed);

                    //Play walk animation
                    WalkAnimation();
                }
                //Attacking State
                if (curDistance <= 1.3f)
                {
                    movement = Vector3.zero;
                    rb.velocity = Vector3.zero;
                    transform.LookAt(Player2.transform);
                    WalkAnimation();
                    // ...attack
                }
            }

            //Debug.Log("Distance to Player = " + curDistance);
            //Debug.Log("Velocity = " + rb.velocity.sqrMagnitude);
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
        if (movement.sqrMagnitude != 0f)
        {
            playerAnimations.Walk(true);
        }
        else
            playerAnimations.Walk(false);
    }

    private void GetDestination()
    {
        Vector3 testPosition = (transform.position + (transform.forward * 0.8f)) +
                               new Vector3(UnityEngine.Random.Range(-3.5f, 3.5f), 0f,
                                   UnityEngine.Random.Range(-3.5f, 3.5f));

        _destination = new Vector3(testPosition.x, 1f, testPosition.z);

        _direction = Vector3.Normalize(_destination - transform.position);
        _direction = new Vector3(_direction.x, 0f, _direction.z);
        _desiredRotation = Quaternion.LookRotation(_direction);
    }

    private bool NeedsDestination()
    {
        if (_destination == Vector3.zero)
            return true;

        var distance = Vector3.Distance(transform.position, _destination);
        if (distance <= _stoppingDistance)
        {
            return true;
        }

        return false;
    }


}
