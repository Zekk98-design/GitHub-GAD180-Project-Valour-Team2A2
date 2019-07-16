using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMove : MonoBehaviour
{
    public float moveSpeed = 6.0f;
    public float rotSpeed = 100.0f;
   
    Vector3 iniRotaVect = Vector3.zero;
    Quaternion currentRotation = Quaternion.LookRotation(Vector3.zero);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float mHorizontal = Input.GetAxisRaw("Horizontal") ;
        float mVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(mHorizontal, 0.0f, mVertical);

        if (movement == Vector3.zero)
        {
            transform.rotation = currentRotation;
            Debug.Log("There is no move Vector !!!!!!");

        }
        else
        {
            transform.rotation = Quaternion.LookRotation(movement);
            transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        }

        //transform.rotation = Quaternion.FromToRotation(transform.position, movement);
        //transform.rotation = Quaternion.Euler(new Vector3(0, mHorizontal*90f+mVertical*90f
        //    , 0));


        // when rotate to right, face right
        if (transform.eulerAngles.y == 90.0f)
        {
            currentRotation = Quaternion.LookRotation(Vector3.right);

            Debug.Log("give me Right currentRotation.y: " + transform.eulerAngles.y);
        }

        
        // when rotate to left, face left
        if (transform.eulerAngles.y == 270f)
        {
            currentRotation = Quaternion.LookRotation(Vector3.left);
            Debug.Log("give me Left currentRotation.y: " + transform.eulerAngles.y);
        }
       
        // when rotate to up, face it
        if (transform.eulerAngles.y == 0.0f)
        {
            currentRotation = Quaternion.LookRotation(Vector3.forward);

            Debug.Log("give me Up currentRotation.y: " + transform.eulerAngles.y);
        }
        
        // when rotate to down, face it
        if (transform.eulerAngles.y == 180f)
        {
            currentRotation = Quaternion.LookRotation(Vector3.back);
            Debug.Log("give me Down currentRotation.y: " + transform.eulerAngles.y);
        }









    }
}
