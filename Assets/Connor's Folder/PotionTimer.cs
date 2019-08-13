using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionTimer : MonoBehaviour
{
    public GameObject owner;
    public PotionDisabler disabler;
    public bool start = false;
    private int ego;
    [SerializeField] private float timer;
    [SerializeField] private float upTimer = 5;
    PickUpAudioControl pickUpAudioControl;

    private void Start()
    {
        //maxing timer
        timer = upTimer;
        //setting name to EGO Pots
        ego = GameObject.FindGameObjectsWithTag("EGO Pots").Length;
        gameObject.name = "EGO Pots";
        pickUpAudioControl = GameObject.Find("Game Manager").GetComponent<PickUpAudioControl>();
    }

    void Update()
    {
        //start timer
        timer = timer - Time.deltaTime;
        //get bool change to start countdown
        if (start == true)
        {
            owner.SetActive(false);
            start = false;
        }
        //re-enable owner, then destroy
        if (timer <= 0)
        {
            owner.SetActive(true);
            Destroy(gameObject);
            pickUpAudioControl.GetComponent<AudioSource>().PlayOneShot(pickUpAudioControl.pickUp);
        }
    }
}
