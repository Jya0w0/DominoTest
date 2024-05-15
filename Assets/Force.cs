using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    private Vector3 add = new Vector3(300, 0, 0);
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Domino"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(add);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
