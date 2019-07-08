using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMove : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float rotSpeed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float move = moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        float rot = rotSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.Translate(0, 0, move);
        transform.Rotate(0, rot, 0);
    }
}
