using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy AI for Normal monsters and Boss.
/// Attach this to enemy prefabs
/// </summary>
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(EnemyStats))]

public class EnemyAI : MonoBehaviour
{   
    [SerializeField] private GameObject     Player1;
    [SerializeField] private GameObject     Player2;    
    public MenuPauser                       menu;
    public PlayerStats                      player1_Stats, player2_Stats;

    private CharacterAnimations             characterAnimation;
    private EnemyStats                      enemyStats;
    private Rigidbody                       rb;
    PlayerRespawn playerRespawn;
    
    private float                           curDistance = 1000.0f;
    private Vector3                         movement;
    [SerializeField] private float          mSpeed = 2f;            //enemy move speed
    //Wander state var
    private float                           _stoppingDistance = 1.5f;
    private Vector3                         _destination;
    private Quaternion                      _desiredRotation;
    private Vector3                         _direction;
    private float                           dmg;
    bool                                  isAttackAnimaPlayed;    // for enemy normal attack
    bool                                  isAbilityAnimaPlayed;   // for enemy Ability attack
    bool                                    isPlayer1 = false;
    bool                                    isPlayer2 = false;
    [SerializeField] float                  AttackSpeed = 1.5f;     //control Enemy attack-speed per attack
    private float                           timerAttackReset;
    [SerializeField] float                  BossAbilitySpeed = 10f;
    private float                           BossAbilityReset;
    float                                   distanceToP1;
    float                                   distanceToP2;


    // Start is called before the first frame update
    void Start()
    {  //find characters with matched tag
        Player1 = GameObject.FindGameObjectWithTag("Player1");
        Player2 = GameObject.FindGameObjectWithTag("Player2");
        player1_Stats = Player1.GetComponent<PlayerStats>();
        player2_Stats = Player2.GetComponent<PlayerStats>();
        

        GameObject Spawn = GameObject.Find("EGO Spawn");
        menu = Spawn.GetComponent<MenuPauser>();
        
        characterAnimation = GetComponent<CharacterAnimations>();
        enemyStats= GetComponent<EnemyStats>();
        rb = GetComponent<Rigidbody>();
        movement = Vector3.zero;

        dmg= 5f;
        isAttackAnimaPlayed = false;
        timerAttackReset = AttackSpeed;
        BossAbilityReset = BossAbilitySpeed;

        distanceToP1 = Mathf.Infinity;
        distanceToP2 = Mathf.Infinity;
    }

// Update is called once per frame
void Update()
    {
        if (menu.eAI == true)
        {
            //Player 1 is gone
            if (player1_Stats.isPlayer1FinalD == true)
            {
                distanceToP1 = Mathf.Infinity;
                Player2 = GameObject.FindGameObjectWithTag("Player2");
                player2_Stats = Player2.GetComponent<PlayerStats>();
                distanceToP2 = Vector3.Distance(transform.position, Player2.transform.position);
                //Debug.Log("Player1 is null, set distanceToP1 = " + distanceToP1);
            }
            //Player 2 is gone
            else if (player2_Stats.isPlayer2FinalD == true)
            {
                distanceToP2 = Mathf.Infinity;
                Player1 = GameObject.FindGameObjectWithTag("Player1");
                player1_Stats = Player1.GetComponent<PlayerStats>();
                distanceToP1 = Vector3.Distance(transform.position, Player1.transform.position);
                //Debug.Log("Player1 is null, set distanceToP1 = " + distanceToP1);
            }
            else
            {   // 2 Players are present
                Player1 = GameObject.FindGameObjectWithTag("Player1");
                player1_Stats = Player1.GetComponent<PlayerStats>();
                Player2 = GameObject.FindGameObjectWithTag("Player2");
                player2_Stats = Player2.GetComponent<PlayerStats>();
                distanceToP1 = Vector3.Distance(transform.position, Player1.transform.position);
                distanceToP2 = Vector3.Distance(transform.position, Player2.transform.position);
                //Debug.Log("Running Nomally ...");
            }

            //find if it is closer to P1...........................................
            if (distanceToP1 < distanceToP2)
            {
                curDistance = distanceToP1;

                //Chasing State to player 1
                if (curDistance > 1.1f && curDistance < 14.0f)
                {
                    transform.LookAt(Player1.transform);
                    
                    transform.Translate(Vector3.forward * mSpeed * Time.deltaTime);              
                    Vector3 temp = transform.position;
                    movement = temp;
                    // Play Walk animation
                    WalkAnimation();
                }
                if (curDistance <= 3.5f && curDistance >= 1.2f&& gameObject.tag=="Boss")
                {
                    //starts Boss ability attack
                    isPlayer1 = true;
                    BossAbility();
                }
                
                //Wandering State
                if (curDistance >= 14.0f)
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

                //Attack State
                
                if (curDistance <= 1.1f)
                {
                    movement = Vector3.zero;
                    rb.velocity = Vector3.zero;
                    transform.LookAt(Player1.transform);
                    transform.Translate(Vector3.zero);
                    isPlayer1 = true;
                    WalkAnimation();
                    //Attack
                    EnemyAttack();

                }
            }

            //find if it is closer to P2............................................
            if (distanceToP2 < distanceToP1)
            {
                curDistance = distanceToP2;

                //Chasing State to player 2
                if (curDistance > 1.1f && curDistance < 14f)
                {
                    transform.LookAt(Player2.transform);
                    transform.Translate(Vector3.forward * mSpeed * Time.deltaTime);               
                    Vector3 temp = transform.position;
                    movement = temp;
                    // Play Walk animation
                    WalkAnimation();

                    if (curDistance <= 3.5f && curDistance >= 1.2f && gameObject.tag == "Boss")
                    {
                        //starts Boss ability attack
                        isPlayer2 = true;
                        BossAbility();  
                    }
                }
                //Wandering State
                if (curDistance >= 14.0f)
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
                if (curDistance <= 1.1f)
                {
                    movement = Vector3.zero;
                    rb.velocity = Vector3.zero;
                    transform.LookAt(Player2.transform);
                    isPlayer2 = true;
                    WalkAnimation();
                    //Attack
                    EnemyAttack();
                }
            }

            //Debug.Log("Distance toP1 = " + distanceToP1 + "\t toP2 = " + distanceToP2 );
            //Debug.Log("enemyStats.damage is " + enemyStats.damage+"\t dmg is "+ dmg );
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
            characterAnimation.Walk(true);
        }
        else
            characterAnimation.Walk(false);
    }

    public void EnemyNormalAttackAnima()
    {
        if (gameObject.name == "Patron")
        {characterAnimation.Atk_Patron();}
        if (gameObject.name == "Patron(Clone)")
        { characterAnimation.Atk_Patron(); }

        if (gameObject.name == "Bartender")
        { characterAnimation.Atk_Bartender(); }
        if (gameObject.name == "Bartender(Clone)")
        { characterAnimation.Atk_Bartender(); }

        if (gameObject.name == "Chicken")
        {
            characterAnimation.Atk_Chicken();
            //transform.Translate(transform.up + transform.forward);
        }
        if (gameObject.name == "Chicken(Clone)")
        {
            characterAnimation.Atk_Chicken();
            //transform.Translate(transform.up + transform.forward);
        }
        if (gameObject.name == "Bull")
        { characterAnimation.Atk_Bull(); }
        if (gameObject.name == "Bull(Clone)")
        { characterAnimation.Atk_Bull(); }
    }

    public void EnemyAbilityAttackAnima()
    {
        if (gameObject.name == "Bartender")
        {
            characterAnimation.Ability_Bartender(); 
        }
        if (gameObject.name == "Bartender(Clone)")
        {
            characterAnimation.Ability_Bartender();
        }

        if (gameObject.name == "Bull")
        { characterAnimation.Ability_Bull(); }
        transform.Translate((transform.forward* 2.5f) + transform.up * 2f * Time.deltaTime);
        if (gameObject.name == "Bull(Clone)")
        { characterAnimation.Ability_Bull(); }
        transform.Translate((transform.forward * 2.5f) + transform.up * 2f * Time.deltaTime);

    }

    public void EnemyAttack()
    {
        AttackSpeed = AttackSpeed - Time.deltaTime;
        if (AttackSpeed <= 0)
        {
            EnemyNormalAttackAnima();          
            AttackSpeed = timerAttackReset;
            isAttackAnimaPlayed = true;

            if (distanceToP1 <= 1.1f && isPlayer1==true)
            {
                if (player1_Stats.defence > 0)
                {
                    player1_Stats.defence = player1_Stats.defence - enemyStats.damage;
                }
                if (player1_Stats.defence <= 0)
                {
                    player1_Stats.health = player1_Stats.health - enemyStats.damage;
                }
                isPlayer1 = false;
            }
            if (distanceToP2 <= 1.1f && isPlayer2 == true)
            {
                if (player2_Stats.defence > 0)
                {
                    player2_Stats.defence = player2_Stats.defence - enemyStats.damage;
                }
                if (player2_Stats.defence <= 0)
                {
                    player2_Stats.health = player2_Stats.health - enemyStats.damage;
                }
                isPlayer2 = false;
            }
        }
        else
        {isAttackAnimaPlayed = false;}
    }

    public void BossAbility()
    {
        BossAbilitySpeed = BossAbilitySpeed - Time.deltaTime;
        if (BossAbilitySpeed <= 0.3f)
        {
            BossAbilitySpeed = BossAbilityReset;
            EnemyAbilityAttackAnima();
            isAbilityAnimaPlayed = true;

            if (distanceToP1 <= 3.5f && isPlayer1 == true)
            {
                
                if (player1_Stats.defence > 0)
                {
                    player1_Stats.defence = player1_Stats.defence - enemyStats.damage * 3f;
                }
                if (player1_Stats.defence <= 0)
                {
                    player1_Stats.health = player1_Stats.health - enemyStats.damage * 3f;
                }
                isPlayer1 = false;
            }
            if (distanceToP2 <= 3.5f && isPlayer2 == true)
            {           
                if (player2_Stats.defence > 0)
                {
                    player2_Stats.defence = player2_Stats.defence - enemyStats.damage * 3f;
                }
                if (player2_Stats.defence <= 0)
                {
                    player2_Stats.health = player2_Stats.health - enemyStats.damage * 3f;
                }
                isPlayer2 = false;
            }
        }
        else
        { isAbilityAnimaPlayed = false; }
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
