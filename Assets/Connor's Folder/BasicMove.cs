using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMove : MonoBehaviour
{
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = speed * Input.GetAxis("Horizontal") * Time.deltaTime;
        float z = speed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Translate(x, 0, z);
    }
}
