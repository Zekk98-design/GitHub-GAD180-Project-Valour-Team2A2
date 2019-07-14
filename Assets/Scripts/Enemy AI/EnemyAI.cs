using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject TargetWarrior;
    [SerializeField] private GameObject TargetRogue;
    [SerializeField] private GameObject TargetMage;
   
    [SerializeField] private float mSpeed= 5f; // enemy speed
    [SerializeField] private Rigidbody rb;

    private float curDistance = 1000f;


    // Start is called before the first frame update
    void Start()
    {   //find characters with matched tag
        TargetWarrior = GameObject.FindGameObjectWithTag("Warrior");
        TargetRogue = GameObject.FindGameObjectWithTag("Rogue");
        TargetMage = GameObject.FindGameObjectWithTag("Mage");

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance1 = Vector3.Distance(transform.position, TargetWarrior.transform.position); // get distance between Enemy and Character
        float distance2 = Vector3.Distance(transform.position, TargetRogue.transform.position);
        float distance3 = Vector3.Distance(transform.position, TargetMage.transform.position);

        //find if it is closest to Warrior
        if (distance1 < distance2 && distance1 < distance3) 
        {
            curDistance = distance1;
            transform.LookAt(TargetWarrior.transform);

            transform.Translate(Vector3.forward * mSpeed * Time.deltaTime);
            
        }
        //find if it is closest to Rogue
        if (distance2 < distance1 && distance2 < distance3)
        {
            curDistance = distance2;
            transform.LookAt(TargetRogue.transform);

            transform.Translate(Vector3.forward * mSpeed * Time.deltaTime);
            
        }
        //find if it is closest to Rogue
        if (distance2 < distance1 && distance2 < distance3)
        {
            curDistance = distance2;
            transform.LookAt(TargetRogue.transform);
            transform.Translate(Vector3.forward * mSpeed * Time.deltaTime);
        }
        //find if it is closest to Mage
        if (distance3 < distance1 && distance3 < distance2)
        {
            curDistance = distance3;
        }

        
    }

}
