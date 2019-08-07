using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraScript : MonoBehaviour
{
    GameObject   _player1;
    GameObject   _player2;
    Vector3     _posCamLookAt;
    Vector3     _midPoint;

    public bool     _camPlayerPosStop =false;   // used to restrain player movement on screen edge
    public string     _playerActivated = "Null";       // used to restrain player movement on screen edge
    public float    _height=14f;
    float           _distanceBtPlayers;

    private void Awake()
    {
        _player1 = GameObject.FindGameObjectWithTag("Player1");
        _player2 = GameObject.FindGameObjectWithTag("Player2");
        Debug.Log("player:  " + _player1.ToString() + " and " + _player2.ToString() + "are found.");

        
        _playerActivated = "Null";

    }

    private void LateUpdate()
    {
        _midPoint = (_player1.transform.position + _player2.transform.position) / 2;
       _posCamLookAt = _midPoint;

       transform.position = _posCamLookAt +  new Vector3(0, _height, 0); ;
       transform.LookAt(_posCamLookAt);
       _distanceBtPlayers = Vector3.Distance(_player1.transform.position, _player2.transform.position);

        // make constraints for camera following.....................................
        float _diffOfPosion_Z = Mathf.Abs(_player1.transform.position.z - _player2.transform.position.z);
        Debug.Log("Z distance is " + _diffOfPosion_Z);
        float _diffOfPosion_X = Mathf.Abs(_player1.transform.position.x - _player2.transform.position.x);
        Debug.Log("X distance is " + _diffOfPosion_X);

       if (_diffOfPosion_Z >= 15.0f  )
       {
           //Player 1 at top, P2 at top
           if (_player1.transform.position.z > _player2.transform.position.z)
           {
               //stop the Player up movement 
               _playerActivated = "Top";
               
            }
           //Player 1 at bottom
           if (_player1.transform.position.z < _player2.transform.position.z )
           {
               //stop the Player down movement 
               _playerActivated = "Bottom";
               
           }
       }
       
       if (_diffOfPosion_X >= 28.0f)
       {
           //Player 1 at right boarder
           if (_player1.transform.position.x > _player2.transform.position.x)
           {
               //stop the Player right movement 
               _playerActivated = "Right";
               
           }
           //Player 1 at left boarder
           if (_player1.transform.position.x < _player2.transform.position.x)
           {
               //stop the Player left movement 
               _playerActivated = "Left";
               
           }
       }

       //When within screen zone
        if (_diffOfPosion_Z < 15.0f && _diffOfPosion_X < 28.0f)
        {
            _playerActivated = "Null";
            
        }

    }


}
