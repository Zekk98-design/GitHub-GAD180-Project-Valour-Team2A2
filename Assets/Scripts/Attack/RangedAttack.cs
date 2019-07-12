using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    private int playerNo;
    [SerializeField] private GameObject arrow;
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("Player1"))
        {
            playerNo = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerNo == 1 & Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(arrow, transform.position, transform.rotation);
            arrow.GetComponent<Collider>().enabled = true;
        }
    }
}
