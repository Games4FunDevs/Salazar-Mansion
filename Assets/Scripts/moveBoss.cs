using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBoss : MonoBehaviour
{
    public bool front = false;

    void Update()
    {
        if (front == true)
            transform.Translate(Vector3.forward * Time.deltaTime);
        else
            transform.Translate(Vector3.back * Time.deltaTime);
    }
}
