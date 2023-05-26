using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBoss : MonoBehaviour
{
    public bool front = false;

    void LateUpdate()
    {
        if (front == true)
            transform.Translate(Vector3.forward * Time.deltaTime * Time.timeScale);
        else
            transform.Translate(Vector3.back * Time.deltaTime * Time.timeScale);
    }
}
