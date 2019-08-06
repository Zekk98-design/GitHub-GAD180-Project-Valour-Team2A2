using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camera : MonoBehaviour
{
    GameObject   _player1;
    GameObject   _player2;
    Vector3     _posCamLookAt;
    Vector3     _midPoint;
   
    float       _height=14f;
   

    private void Awake()
    {
        _player1 = GameObject.FindGameObjectWithTag("Player1");
        _player2 = GameObject.FindGameObjectWithTag("Player2");
        
    }


    private void LateUpdate()
    {
        if (true)
        {
            _midPoint = (_player1.transform.position + _player2.transform.position) / 2;

            _posCamLookAt = _midPoint;

            Debug.Log("Updating midPoint........................");
        }

        transform.position = _posCamLookAt +  new Vector3(0, _height, 0); ;
        transform.LookAt(_posCamLookAt);




    }





}
