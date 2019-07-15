using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionInfoDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contactPoint in collision.contacts)
        {
            print("Hit " + collision.gameObject.name + " At " + contactPoint.point);
        }
    }
}