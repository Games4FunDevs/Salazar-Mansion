using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaiObj : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void OnTriggerEnter (Collider col)
    {
        if (col.CompareTag("P1") || col.CompareTag("P2"))
        {
            this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>().useGravity = true;
            Destroy(this.gameObject);
        }
    }
}
