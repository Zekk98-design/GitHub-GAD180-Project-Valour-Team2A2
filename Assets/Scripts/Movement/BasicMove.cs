using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterAnimations))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]

public class BasicMove : MonoBehaviour
{
    public MenuPauser           menu;
    public CameraScript         cameraScript;           // drag Main camera with Camerascript in 
    private CharacterAnimations playerAnimations;
    private Rigidbody           rb;

    public float                moveSpeed = 6.0f;
    public Vector3              movement;               // used in Character selection logic as well
    private Quaternion          currentRotation;

    void Start()
    {
        //setting menu script on EGO Spawn
        GameObject temp = GameObject.Find("Game Manager");
        menu = temp.GetComponent<MenuPauser>();

        rb = GetComponent<Rigidbody>();
        playerAnimations = GetComponent<CharacterAnimations>();
        currentRotation = Quaternion.LookRotation(Vector3.up);

        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
        cameraScript = cam.GetComponent<CameraScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (menu.pControl == true)
        {
            Move();
            WalkAnimation();
        }
    }

    void Move()
    {
        switch (tag)
        {
            case "Player1":
                //Read inputs from Player 1
                float mHorizontal = Input.GetAxisRaw("Horizontal");
                float mVertical = Input.GetAxisRaw("Vertical");
                
                //Player 1 at top boarder
                if (cameraScript._playerActivated == "Top")
                {
                    //stop Player1's upward movment
                    movement = new Vector3(mHorizontal, 0.0f, -1.0f);
                }
                //Player 1 at bottom boarder
                if (cameraScript._playerActivated == "Bottom")
                {
                    //stop Player1's downward movment
                    movement = new Vector3(mHorizontal, 0.0f, 1.0f);
                }
                //P1 at right
                if (cameraScript._playerActivated == "Right")
                {
                    //stop Player1's Right movment
                    movement = new Vector3(-1.0f, 0.0f, mVertical);
                }
                //P1 at Left
                if (cameraScript._playerActivated == "Left")
                {
                    //stop Player1's Left movment
                    movement = new Vector3(1.0f, 0.0f, mVertical);
                }
                // Normal movement 
                if (cameraScript._playerActivated == "Null")
                {
                    movement = new Vector3(mHorizontal, 0.0f, mVertical);
                }
                break;

            case "Player2":
                //Read inputs from Player 2
                float mHorizontal_2 = Input.GetAxisRaw("Horizontal_Player2");
                float mVertical_2 = Input.GetAxisRaw("Vertical_Player2");
                
                //Player 2 at Bottom boarder
                if (cameraScript._playerActivated_2 == "Bottom")
                {
                    //stop Player2's downward movment
                    movement = new Vector3(mHorizontal_2, 0.0f, 1.0f);
                }
                //Player 2 at Top boarder
                if (cameraScript._playerActivated_2 == "Top")
                {
                    //stop Player2's upwnward movment
                    movement = new Vector3(mHorizontal_2, 0.0f, -1.0f);
                }
                //P2 at Left
                if (cameraScript._playerActivated_2 == "Left")
                {
                    //stop Player2's left movment
                    movement = new Vector3(1.0f, 0.0f, mVertical_2);
                }
                //P2 at Right
                if (cameraScript._playerActivated_2 == "Right")
                {
                    //stop Player2's Right movment
                    movement = new Vector3(-1.0f, 0.0f, mVertical_2);
                }

                // Normal movement 
                if (cameraScript._playerActivated_2 == "Null")
                {
                    movement = new Vector3(mHorizontal_2, 0.0f, mVertical_2);
                }

                //movement = new Vector3(mHorizontal_2, 0.0f, mVertical_2);
                break;

            default:
                break;
        } //Chose player inputs based on Tag

        //When no inputs
        if (movement == Vector3.zero) { transform.rotation = currentRotation;}

        else
        {   transform.rotation = Quaternion.LookRotation(movement);
            transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
            //Debug.Log("Moving");
        }

        // when rotate to right, face right
        if (transform.eulerAngles.y == 90.0f)
        {
            currentRotation = Quaternion.LookRotation(Vector3.right);
            //Debug.Log("give me Right currentRotation.y: " + transform.eulerAngles.y);
        }
        // when rotate to left, face left
        if (transform.eulerAngles.y == 270f)
        {
            currentRotation = Quaternion.LookRotation(Vector3.left);
            //Debug.Log("give me Left currentRotation.y: " + transform.eulerAngles.y);
        }
        // when rotate to up, face it
        if (transform.eulerAngles.y == 0.0f)
        {
            currentRotation = Quaternion.LookRotation(Vector3.forward);

            //Debug.Log("give me Up currentRotation.y: " + transform.eulerAngles.y);
        }
        // when rotate to down, face it
        if (transform.eulerAngles.y == 180f)
        {
            currentRotation = Quaternion.LookRotation(Vector3.back);
            //Debug.Log("give me Down currentRotation.y: " + transform.eulerAngles.y);
        }
    }


    void WalkAnimation()
    {
        // when there is velocity, play Walk animation
        if (movement.sqrMagnitude != 0f)
        {
            playerAnimations.Walk(true);
        }
        else
            playerAnimations.Walk(false);
    }


}
