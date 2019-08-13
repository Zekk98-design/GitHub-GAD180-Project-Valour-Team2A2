using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class PickUpAudioControl : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip pickUp;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }


}
