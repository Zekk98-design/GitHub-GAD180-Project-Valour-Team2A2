using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionDisabler : MonoBehaviour
{
    public PotionTimer timer;
    public PotionTimer tempTimer;
    public GameObject temp;
    public GameObject pots;
    private int tempCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        GameObject egoPots = Instantiate(pots, transform.position, transform.rotation);
        temp = egoPots;
        int egoCount = GameObject.FindGameObjectsWithTag("EGO Pots").Length;
        //checking the temp object for a variable to be false
        for (int i = 0; i < egoCount; i++)
        {
            tempTimer = temp.GetComponent<PotionTimer>();
            //once found, start disabled timer
            if (tempTimer.start == false)
            {
                timer = tempTimer;
                timer.owner = gameObject;
                timer.disabler = gameObject.GetComponent<PotionDisabler>();
                timer.start = true;
            }
        }
    }
}
