using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraScript : MonoBehaviour
{
    private GameObject      _player1;
    private GameObject      _player2;

    public string           _playerActivated = "Null" ;          //used to restrain player movement on screen edge
    public string           _playerActivated_2 = "Null";
    public float            _height;

    private Vector3         _posCamLookAt;
    private Vector3         _midPoint;
    private float           _distanceBtPlayers;


    private void Start()
    {
        _player1 = GameObject.FindGameObjectWithTag("Player1");
        _player2 = GameObject.FindGameObjectWithTag("Player2");
        Debug.Log("player:  " + _player1.ToString() + " and " + _player2.ToString() + "are found.");

        _height = 18f;
    }

    private void LateUpdate()
    {
        _player1 = GameObject.FindGameObjectWithTag("Player1");
        _player2 = GameObject.FindGameObjectWithTag("Player2");

        _midPoint = (_player1.transform.position + _player2.transform.position) / 2;
       _posCamLookAt = _midPoint;

       transform.position = _posCamLookAt +  new Vector3(0, _height, 0); ;
       transform.LookAt(_posCamLookAt);
       _distanceBtPlayers = Vector3.Distance(_player1.transform.position, _player2.transform.position);

       // make constraints for camera following.....
       float _diffOfPosion_Z = Mathf.Abs(_player1.transform.position.z - _player2.transform.position.z);
  
       float _diffOfPosion_X = Mathf.Abs(_player1.transform.position.x - _player2.transform.position.x);

       if (_diffOfPosion_Z >= 15.0f  )
       {
           //Player 1 at top, P2 at bottom
           if (_player1.transform.position.z > _player2.transform.position.z)
           {
               //stop the Player1 up movement 
               _playerActivated = "Top";
                // stop P2 downward
                _playerActivated_2 = "Bottom";
            }
           //Player 1 at bottom, P2 Top
           if (_player1.transform.position.z < _player2.transform.position.z )
           {
               //stop the Player down movement 
               _playerActivated = "Bottom";
                // stop P2 Upwaed 
                _playerActivated_2 = "Top";
            }
       }
       
       if (_diffOfPosion_X >= 28.0f)
       {
           //Player 1 at right boarder
           if (_player1.transform.position.x > _player2.transform.position.x)
           {
               //stop the Player1 right movement 
               _playerActivated = "Right";
                //P2 at Left
                _playerActivated_2 = "Left";
            }
           //Player 1 at left boarder
           if (_player1.transform.position.x < _player2.transform.position.x)
           {
               //stop the Player1 left movement 
               _playerActivated = "Left";
                //P2 at Right
                _playerActivated_2 = "Right";
            }
        }

       //When within screen zone
       if (_diffOfPosion_Z < 15.0f && _diffOfPosion_X < 28.0f)
       {
           _playerActivated = "Null";
           _playerActivated_2 = "Null";
        }

    }


}
