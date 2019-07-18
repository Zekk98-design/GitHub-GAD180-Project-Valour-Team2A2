using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DeactivateOnCollision : MonoBehaviour
{
    [SerializeField] private GameObject objectToDeactivate;
    [SerializeField] private string objectTagName;
    [SerializeField] private string objectName;
    [SerializeField] private bool deactivateThisObject = false;
    private void Start()
    {
        if (deactivateThisObject)
        {
            objectToDeactivate = gameObject;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(objectTagName) || collision.gameObject.name == objectName)
        {
            objectToDeactivate.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag(objectTagName) || collider.gameObject.name == objectName)
        {
            objectToDeactivate.SetActive(false);
        }
    }
}