using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Script to let P
/// layer character pick up game items
/// </summary>

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("HP Potion"))
        {
            // pick up the item
            Destroy(collision.gameObject);


            //itemIcon.enabled = true;
            //example: HpPotionImage.gameObject.SetActive(true);

            //play an audio
            //example: audioSource.PlayOneShot(myClip, 0.7f);
        }
    }
}
