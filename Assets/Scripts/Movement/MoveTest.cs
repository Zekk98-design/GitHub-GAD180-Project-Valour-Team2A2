using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {
        

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
            rb.rotation = Quaternion.LookRotation(transform.right) ;
            //Move always to the forward vector
            rb.MovePosition(transform.position + transform.forward * moveSpeed* Time.deltaTime) ;
        }
        else if (mHorizontal < 0)
        {
            //Rotate to the left
            transform.rotation = Quaternion.LookRotation(-transform.right * Time.deltaTime);
            //Move always to the forward vector
            rb.MovePosition(transform.position + transform.forward * moveSpeed* Time.deltaTime);
        }

        if (mVertical > 0)
        {
            ////Rotate to the right
            //transform.rotation = Quaternion.LookRotation(transform.right);
            //Move always to the forward vector
            rb.MovePosition(transform.position + transform.forward * moveSpeed* Time.deltaTime);
        }
        else if(mVertical < 0)
        {
            ////Rotate to the left
            //transform.rotation = Quaternion.LookRotation(-transform.right);
            //Move always to the forward vector
            rb.MovePosition(transform.position + transform.forward*-1f * moveSpeed* Time.deltaTime);
        }




        //Vector3 movement = moveForward + turnDirection;
        //rb.MovePosition(rb.position + movement);
    }
    


}


