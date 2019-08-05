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

    private void Start()
    {
        timer = upTimer;
        ego = GameObject.FindGameObjectsWithTag("EGO Pots").Length;
        gameObject.name = "EGO Pots";
    }

    void Update()
    {
        timer = timer - Time.deltaTime;
        if (start == true)
        {
            owner.SetActive(false);
            start = false;
        }
        if (timer <= 0)
        {
            owner.SetActive(true);
            Destroy(gameObject);
        }
    }
}
