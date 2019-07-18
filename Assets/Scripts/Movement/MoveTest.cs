using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Movement script with rigidbody, only used for testing purpose atm
/// </summary>
public class MoveTest : MonoBehaviour
{
    public float moveSpeed = 7.0f;
    public float rotateSpeed = 10;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.constraints = RigidbodyConstraints.FreezeRotationY;

    }


    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        // Read inputs
        float mHorizontal = Input.GetAxis("Horizontal");
        float mVertical = Input.GetAxis("Vertical");

        //Vector3 moveForward = mVertical*  Vector3.forward* moveSpeed;
        //Vector3 turnDirection = mHorizontal * Vector3.right * moveSpeed ;

        if (mHorizontal > 0)
        {
            //Rotate to the right
            rb.MoveRotation(Quaternion.LookRotation(Vector3.right));
            //Move always to the forward vector
            rb.MovePosition(transform.position + transform.forward * moveSpeed* Time.deltaTime) ;
        }
        else if (mHorizontal < 0)
        {
            //Rotate to the left
            rb.MoveRotation(Quaternion.LookRotation(Vector3.left));
            //Move always to the forward vector
            rb.MovePosition(transform.position + transform.forward * moveSpeed * Time.deltaTime);
        }
            
        if (mVertical > 0)
        {
            //Rotate to the up
            rb.MoveRotation(Quaternion.LookRotation(Vector3.forward));
            //Move always to the forward vector
            rb.MovePosition(transform.position + transform.forward * moveSpeed * Time.deltaTime);
        }
        else if(mVertical < 0)
        {
            //Rotate to the down
            rb.MoveRotation(Quaternion.LookRotation(Vector3.back));
            //Move always to the forward vector
            rb.MovePosition(transform.position + transform.forward * moveSpeed * Time.deltaTime);
        }
    }
    


}


