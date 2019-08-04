using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterAnimations))]
[RequireComponent(typeof(Rigidbody))]

public class BasicMove : MonoBehaviour
{
    private CharacterAnimations playerAnimations;
    private Rigidbody rb;
    public float moveSpeed = 6.0f;
    Quaternion currentRotation = Quaternion.LookRotation(Vector3.up);
    public Vector3 movement;  // used in Character selection logic as well
   

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // fetch the AnimationController component
        playerAnimations = GetComponent<CharacterAnimations>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        WalkAnimation();
    }

    void Move()
    {
        switch (tag)
        {
            case "Player1" :
                //Read inputs from Player 1
                float mHorizontal = Input.GetAxisRaw("Horizontal");
                float mVertical = Input.GetAxisRaw("Vertical");
                movement = new Vector3(mHorizontal, 0.0f, mVertical);
                break;

            case "Player2":
                //Read inputs from Player 2
                float mHorizontal_2 = Input.GetAxisRaw("Horizontal_Player2");
                float mVertical_2 = Input.GetAxisRaw("Vertical_Player2");
                movement = new Vector3(mHorizontal_2, 0.0f, mVertical_2);
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
